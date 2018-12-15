using System;

namespace BFsharp.DynamicProperties
{
    public class DynamicPropertyMetadata
    {
        public DynamicPropertyMetadata(string name, Type type) : this(name, type, DynamicPropertyMetadataOptions.Save)
        {
        }

        public DynamicPropertyMetadata(string name, Type type, DynamicPropertyMetadataOptions options)
        {
            Name = name;
            Type = type;
            Options = options;
        }

        public string Name { get; private set; }
        public Type Type { get; private set; }
        internal bool SaveTypeInfo { get; set; }
        public DynamicPropertyMetadataOptions Options { get; set; }
    }

    [Flags]
    public enum DynamicPropertyMetadataOptions
    {
        None = 0,
        Save = 0x1,
        //SaveTypeInfo,
        //Inherited,
    }
}
