using System;

namespace BFsharp
{
    public class AttributeRulesExtensionPointFactory : ExtensionPointFactory
    {
        public override ExtensionPoint<T> GetGextensions<T>()
        {
            return new AttributeRulesExtensionPoint<T>();
        }
    }
}