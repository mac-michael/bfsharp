using System;

namespace BFsharp
{
    public class EntityBaseGraphMonitoringExtensionPoint<T> : ExtensionPoint<T>
    {
        public override void Init(ExtensionsOptions<T> options)
        {
#if PHONE
           // throw new NotImplementedException("EntityBaseGraphMonitoringExtensionPoint reflection");
#else
            options.GraphMonitoringStrategy = new EntityBaseGraphMonitoringStrategy<T>();
#endif
        }
    }
}