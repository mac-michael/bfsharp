using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BFsharp
{
    public class PropertyPath : IEnumerable<PropertyPathElement>
    {
        public const string AllProperties = "p*";
        public const string AllCollections = "c*";
        public const string All = "*";
        public const char CollectionSeparator = '$';
        public const char PropertySeparator = '.';

        private List<PropertyPathElement> Path { get; set; }

        public PropertyPathElement this[int index]
        {
            get { return Path[index]; }
        }

        public int Count { get { return Path.Count; } }  

        public IEnumerator<PropertyPathElement> GetEnumerator()
        {
            return Path.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static implicit operator PropertyPath(string propertyPath)
        {
            return new PropertyPath(propertyPath);
        }

        public static implicit operator PropertyPath(List<string> propertyPath)
        {
            return new PropertyPath(propertyPath);
        }

        public static implicit operator PropertyPath(string[] propertyPath)
        {
            return new PropertyPath(propertyPath);
        }

        public static implicit operator string(PropertyPath propertyPath)
        {
            if (propertyPath.Count == 0) return "";

            var b = new StringBuilder();
            if (propertyPath[0].Type == PropertyPathElementType.CollectionElement )
                b.Append(CollectionSeparator);
            b.Append(propertyPath[0]);

            for (int i = 1; i < propertyPath.Path.Count; i++)
            {
                var propertyPathElement = propertyPath.Path[i];
                b.AppendFormat("{0}{1}",
                               propertyPathElement.Type == PropertyPathElementType.Property
                                   ? PropertySeparator : CollectionSeparator,
                               propertyPathElement.Property);
            }

            return b.ToString();
        }

        public PropertyPath(string propertyPath)
        {
            Path = Split(propertyPath);
        }

        public PropertyPath(IEnumerable<string> propertyPath)
        {
            string s = PropertySeparator.ToString();

            Path = Split(string.Join(s, propertyPath.ToArray()));
        }

        private static List<PropertyPathElement> Split(string propertyPath)
        {
            var list = new List<PropertyPathElement>();

            int start = propertyPath[0] == CollectionSeparator ? 1 : 0;
            for (int i = start; i < propertyPath.Length; i++)
            {
                if ( propertyPath[i] == PropertySeparator || 
                    propertyPath[i] == CollectionSeparator || i+1 == propertyPath.Length )
                {
                    if (i + 1 == propertyPath.Length) i++;

                    var property = propertyPath.Substring(start, i - start);
                    var type = PropertyPathElementType.Property;
                    if ( start > 0 )
                    {
                        if ( propertyPath[start-1] == CollectionSeparator )
                            type = PropertyPathElementType.CollectionElement;
                        else if ( propertyPath[start-1] == PropertySeparator )
                            type = PropertyPathElementType.Property;
                    }
                    
                    list.Add(new PropertyPathElement{ Property = property, Type = type});

                    start = i + 1;
                }
            }

            return list;
        }

        public override string ToString()
        {
            return (string) this;
        }
    }
}