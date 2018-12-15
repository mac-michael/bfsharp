using System;

namespace BFsharp
{
    public class NoGraphMonitoringExtensionPoint<T> : ExtensionPoint<T>
    {
        public override void Init(ExtensionsOptions<T> options)
        {
            options.GraphMonitoringStrategy = NoGraphMonitoringStrategy.Instance;
        }
    }
}