using System;
using System.Collections.Generic;

namespace BFsharp
{
    class RulePrototypeExtensionPoint<T> : ExtensionPoint<T>
    {
        public override void Init(ExtensionsOptions<T> options)
        {
            foreach (var method in ReflectionHelper.GetMethodsWithAttributeOfType<T, RuleInitAttribute>())
            {
                if (ReflectionHelper.IsMethod(method, true, typeof(IEnumerable<Rule>), typeof(Type)))
                {
                    // Rule prototype
                    var res = (IEnumerable<Rule>)method.Invoke(null, new[] { typeof(T) });
                    foreach (var rule in res)
                        options.RulePrototypes.Add(rule);
                }
            }
        }
    }
}