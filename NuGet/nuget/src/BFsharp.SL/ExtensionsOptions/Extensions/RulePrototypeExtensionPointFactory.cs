namespace BFsharp
{
    public class RulePrototypeExtensionPointFactory : ExtensionPointFactory
    {
        public override ExtensionPoint<T> GetGextensions<T>()
        {
            return new RulePrototypeExtensionPoint<T>();
        }
    }
}