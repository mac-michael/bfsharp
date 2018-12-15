using System.Diagnostics;

namespace BFsharp
{
    [DebuggerDisplay("Property: {Property}, Type: {Type}")]
    public struct PropertyPathElement
    {
        public string Property { get; set; }
        public PropertyPathElementType Type { get; set; }

        public bool IsAll { get { return Property == PropertyPath.All; } }
        public bool IsProperty { get { return Type == PropertyPathElementType.Property; } }
        public bool IsCollectionElement { get { return Type == PropertyPathElementType.CollectionElement; } }

        public static implicit operator PropertyPathElement(string propertyPath)
        {
            var p = new PropertyPathElement();
            if (propertyPath.Length>0 && propertyPath[0]==PropertyPath.CollectionSeparator)
            {
                p.Type = PropertyPathElementType.CollectionElement;
                p.Property = propertyPath.Substring(1);
            }
            else if (propertyPath.Length>0 && propertyPath[0]==PropertyPath.PropertySeparator)
            {
                p.Type = PropertyPathElementType.Property;
                p.Property = propertyPath.Substring(1);
            }
            else
            {
                p.Type = PropertyPathElementType.Property;
                p.Property = propertyPath;
            }

            return p;
        }

        public static implicit operator string(PropertyPathElement propertyPath)
        {
            if (propertyPath.Type == PropertyPathElementType.CollectionElement)
                return PropertyPath.CollectionSeparator + propertyPath.Property;
            
            return propertyPath.Property;
        }

        public override string ToString()
        {
            return this;
        }

        public override int GetHashCode()
        {
            return Property.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PropertyPathElement))
                return false;

            var e = (PropertyPathElement)obj;

            return Property == e.Property && Type == e.Type;
        }
    }
}