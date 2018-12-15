using System;

namespace BFsharp.AOP
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class NotifiedByAttribute : Attribute
    {
        public string[] Properties { get; set; }


        public NotifiedByAttribute(params string[] properties)
        {
            Properties = properties;
        }
    }
}