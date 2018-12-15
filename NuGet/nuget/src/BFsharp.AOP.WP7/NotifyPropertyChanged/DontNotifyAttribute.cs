using System;

namespace BFsharp.AOP
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
    public class DontNotifyAttribute : Attribute
    {
    }
}