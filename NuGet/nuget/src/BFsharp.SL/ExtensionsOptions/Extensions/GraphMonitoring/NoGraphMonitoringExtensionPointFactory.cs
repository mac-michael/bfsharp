namespace BFsharp
{
    public class NoGraphMonitoringExtensionPointFactory : ExtensionPointFactory
    {
        public override ExtensionPoint<T> GetGextensions<T>()
        {
            return new NoGraphMonitoringExtensionPoint<T>();
        }
    }
}