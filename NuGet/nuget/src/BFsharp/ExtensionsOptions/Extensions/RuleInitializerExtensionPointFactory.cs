namespace BFsharp
{
    public class RuleInitializerExtensionPointFactory : ExtensionPointFactory
    {
        public override ExtensionPoint<T> GetGextensions<T>()
        {
#if PHONE
            return new RuleInitializerExtensionPoint<T>();
#else
            return new PrecompiledRuleInitializerExtensionPoint<T>();
#endif
        }
    }
}