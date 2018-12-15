namespace BFsharp
{
    public class DynamicPropertiesExtensionPointFactory : ExtensionPointFactory
    {
        public override ExtensionPoint<T> GetGextensions<T>()
        {
#if PHONE
            return new DynamicPropertiesExtensionPoint<T>();
#else
            return new PrecompiledDynamicPropertiesExtensionPoint<T>();
#endif
        }
    }
}