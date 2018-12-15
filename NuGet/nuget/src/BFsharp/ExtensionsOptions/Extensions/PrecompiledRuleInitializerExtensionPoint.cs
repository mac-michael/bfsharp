using System;
using System.Linq.Expressions;

namespace BFsharp
{
    class PrecompiledRuleInitializerExtensionPoint<T> : ExtensionPoint<T>
    {
        public override void Init(ExtensionsOptions<T> options)
        {
            foreach (var method in ReflectionHelper.GetMethodsWithAttributeOfType<T,RuleInitAttribute>())
            {
                if (ReflectionHelper.IsMethod(method, false, typeof(void)))
                {
                    // Rule init method
                    var param = Expression.Parameter(typeof (T), "t");
                    var f = Expression.Lambda<Action<T>>(
                        Expression.Call(param, method), param);
                    options.RuleInitializers.Add(f.Compile());
                }
            }
        }
    }
}