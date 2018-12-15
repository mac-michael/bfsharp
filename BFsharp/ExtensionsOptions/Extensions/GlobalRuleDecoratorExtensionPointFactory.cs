using System;

namespace BFsharp
{
    public class GlobalRuleDecoratorExtensionPointFactory : ExtensionPointFactory
    {
        public Action<Rule> Decorator { get; set; }

        public GlobalRuleDecoratorExtensionPointFactory(Action<Rule> decorator)
        {
            Decorator = decorator;
        }

        public override ExtensionPoint<T> GetGextensions<T>()
        {
            return new GlobalRuleDecoratorExtensionPoint<T>(Decorator);
        }
    }
}