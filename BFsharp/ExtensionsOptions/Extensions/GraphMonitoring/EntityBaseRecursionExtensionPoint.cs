using System;

namespace BFsharp
{
    public class EntityBaseRecursionExtensionPoint<T> : ExtensionPoint<T>
    {
        public override void Init(ExtensionsOptions<T> options)
        {
#if PHONE
           // throw new NotImplementedException("EntityBaseRecursiveStrategy reflection");
#else
            options.RecursiveStrategy = new EntityBaseRecursiveStrategy<T>();
#endif
        }
    }
}