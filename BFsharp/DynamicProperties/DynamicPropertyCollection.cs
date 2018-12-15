using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace BFsharp.DynamicProperties
{
    public class DynamicPropertyCollection : INotifyPropertyChanged
    {
        public T GetProperty<T>(string name)
        {
            object value;
            if ( Dictionary.TryGetValue(name, out value) ) 
                return (T) value;

            var p = PropertiesMetadata.FirstOrDefault(v => v.Name == name);
            if (p != null)
                return (T) (p.Type.IsValueType ? Activator.CreateInstance(p.Type) : null);
            if (AllowDynamicProperties)
                return default(T);

            throw new InvalidPropertyException();
        }
        public void SetProperty<T>(string name, T value)
        {
            var p = PropertiesMetadata.FirstOrDefault(v => v.Name == name);
            if ( p != null )
            {
                // Type should match
                if (p.Type != value.GetType())
                    throw new InvalidCastException();
            }
            else
            {
                if (AllowDynamicProperties)
                {
                    p = new DynamicPropertyMetadata(name, value.GetType());
                    p.SaveTypeInfo = true;
                    PropertiesMetadata.Add(p);
                }
                else throw new InvalidPropertyException();
            }

            Dictionary[name] = value;
            RaisePropertyChanged(name);
        }
        public object this[string name]
        {
            get
            {
                return GetProperty<object>(name);
            }
            set
            {
                SetProperty(name, value);
            }
        }

        public bool AllowDynamicProperties { get; set; }
#if !PHONE
        internal void RefreshProxy()
        {
            if (_proxy != null)
            {
                _proxy = null;
                // Create proxy
                var typedProxy = TypedProxy;
                RaisePropertyChanged("TypedProxy");
            }
        }
        
        private TypedProxyBase _proxy;
        public object TypedProxy
        {
            get
            {
                if (_proxy == null )
                    _proxy = DynamicObjectEmitter.Emitter.CreateDynamicObjectCreator(PropertiesMetadata)(this);
                return _proxy;
            }
        }
#endif
        private DynamicPropertyMetadataCollection _propertiesMetadata;
        public DynamicPropertyMetadataCollection PropertiesMetadata
        {
            get
            {
                if (_propertiesMetadata == null)
                    _propertiesMetadata = new DynamicPropertyMetadataCollection(this);
                return _propertiesMetadata;
            }
        }

        private Dictionary<string, object> _dictionary;
        protected internal Dictionary<string, object> Dictionary
        {
            get
            {
                if (_dictionary == null)
                    _dictionary = new Dictionary<string, object>();
                return _dictionary;
            }
        }  

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            var p = PropertyChanged;
            if (p != null)
                p(this, new PropertyChangedEventArgs(propertyName));
#if !PHONE

            if (_proxy != null)
                _proxy.RaisePropertyChanged(propertyName);
#endif
        }
#if !PHONE
        public string Save()
        {
            var sb = new StringBuilder();
            using (var xw = XmlWriter.Create(sb, new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                ConformanceLevel = ConformanceLevel.Fragment,
                Indent = true
            }))
            {
                foreach (var o in Dictionary)
                {
                    var propertyDefinition = PropertiesMetadata.Single(x => x.Name == o.Key);

                    if ((propertyDefinition.Options & DynamicPropertyMetadataOptions.Save) == DynamicPropertyMetadataOptions.None)
                        continue;

                    var s = new DataContractSerializer(o.Value.GetType(), null);

                    xw.WriteStartElement(o.Key);

                    if (propertyDefinition.SaveTypeInfo)
                        xw.WriteAttributeString("t", GetTypeFullName(propertyDefinition.Type));

                    object content = o.Value;
                    if (content is DateTime)
                        content = DateTime.SpecifyKind((DateTime) content, DateTimeKind.Unspecified);

                    if (ShouldWriteContent(o.Value.GetType()))
                        s.WriteObjectContent(xw, content);
                    else
                        s.WriteObject(xw, content);

                    xw.WriteEndElement();
                }
            }

            return sb.ToString();
        }

        private static string GetTypeFullName(Type type)
        {
            if (type == typeof(string))
                return "string";
            if (type == typeof(int))
                return "int";
            if (type == typeof(decimal))
                return "decimal";

            return type.AssemblyQualifiedName;
        }

        private static Type GetType(string type)
        {
            if (type == "string")
                return typeof (string);
            if (type == "int")
                return typeof(int);
            if (type == "decimal")
                return typeof(decimal);

            return Type.GetType(type, true);
        }

        private static bool ShouldWriteContent(Type t)
        {
            return t.IsPrimitive || t == typeof(DateTime) || t == typeof(string)
                || t == typeof(decimal);
        }

        public void Load(string xml)
        {
            var root = XElement.Parse("<a>" + xml + "</a>");
            Dictionary.Clear();

            var b = new StringBuilder();
            foreach (var element in root.Elements())
            {
                Type type =null;

                var typeAttribute = element.Attribute("t");
                if (typeAttribute != null)
                    type = GetType(typeAttribute.Value);
                else
                {
                    var dynamicPropertyMetadata =
                        PropertiesMetadata.FirstOrDefault(x => x.Name == element.Name.LocalName);
                    if (dynamicPropertyMetadata == null)
                        throw new InvalidPropertyException();
                    type = dynamicPropertyMetadata.Type;
                }

                var s = new DataContractSerializer(type);

                using (var reader = ShouldWriteContent(type)
                                        ? element.CreateReader()
                                        : element.Elements().Single().CreateReader())
                {
                    var obj = s.ReadObject(reader, false);
                    SetProperty(element.Name.LocalName, obj);
                }
            }

            RefreshProxy();
        }
#endif
    }
}