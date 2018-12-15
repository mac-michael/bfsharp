using System;

namespace BFsharp
{
    public class GlobalRuleDecoratorExtensionPoint<T> : ExtensionPoint<T>
    {
        public Action<Rule> Decorator { get; set; }

        public GlobalRuleDecoratorExtensionPoint(Action<Rule> decorator)
        {
            Decorator = decorator;
        }

        public override void Init(ExtensionsOptions<T> options)
        {
            options.Decorators.Add(Decorator);
        }
    }
}