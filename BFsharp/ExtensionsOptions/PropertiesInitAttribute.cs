using System;

namespace BFsharp
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class PropertiesInitAttribute : Attribute { }
}