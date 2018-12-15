using System;

namespace BFsharp
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false, Inherited=true)]
    public class IgnoreTraversalAttribute : Attribute { }
}