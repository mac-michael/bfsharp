using System;
using System.Reflection;

namespace BFsharp
{
    class RuleDecoratorExtensionPoint<T> : ExtensionPoint<T>
    {
        public override void Init(ExtensionsOptions<T> options)
        {
            options.Decorators.Add(Decorator);
        }

        private static void Decorator(Rule rule)
        {
            foreach (var method in ReflectionHelper.GetMethodsWithAttributeOfType<T, RuleDecoratorAttribute>())
            {
                if (ReflectionHelper.IsMethod(method, true, typeof (void), typeof (Rule)))
                    method.Invoke(null, new[] {rule});
                else
                    throw new InvalidOperationException("Invalid method signature.");
            }
        }
    }
}