using System;
using System.Linq.Expressions;

namespace BFsharp
{
    class PrecompiledRuleDecoratorExtensionPoint<T> : ExtensionPoint<T>
    {
        public override void Init(ExtensionsOptions<T> options)
        {
            foreach (var method in ReflectionHelper.GetMethodsWithAttributeOfType<T,RuleDecoratorAttribute>())
            {
                if (ReflectionHelper.IsMethod(method, true, typeof(void), typeof(Rule)))
                {
                    var param = Expression.Parameter(typeof(Rule), "r");
                    var f = Expression.Lambda<Action<Rule>>(
                        Expression.Call(method, param), param);

                    options.Decorators.Add(f.Compile());
                }
                else
                    throw new InvalidOperationException("Invalid method signature.");
            }
        }
    }
}