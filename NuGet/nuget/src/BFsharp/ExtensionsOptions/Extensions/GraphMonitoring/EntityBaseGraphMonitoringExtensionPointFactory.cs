namespace BFsharp
{
    public class EntityBaseGraphMonitoringExtensionPointFactory : ExtensionPointFactory
    {
        public override ExtensionPoint<T> GetGextensions<T>()
        {
            return new EntityBaseGraphMonitoringExtensionPoint<T>();
        }
    }
}