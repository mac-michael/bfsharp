namespace BFsharp
{
    public class RuleDecoratorExtensionPointFactory : ExtensionPointFactory
    {
        public override ExtensionPoint<T> GetGextensions<T>()
        {
#if PHONE
            return new RuleDecoratorExtensionPoint<T>();
#else
            return new PrecompiledRuleDecoratorExtensionPoint<T>();
#endif
        }
    }
}