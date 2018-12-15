using System;
using System.Linq.Expressions;

namespace BFsharp
{
    class PrecompiledDynamicPropertiesExtensionPoint<T> : ExtensionPoint<T>
    {
        public override void Init(ExtensionsOptions<T> options)
        {
            foreach (var method in ReflectionHelper.GetMethodsWithAttributeOfType<T,PropertiesInitAttribute>())
            {
                if (ReflectionHelper.IsMethod(method, false, typeof(void)))
                {
                    // Properties init method
                    var param = Expression.Parameter(typeof(T), "t");
                    var f = Expression.Lambda<Action<T>>(
                        Expression.Call(param, method), param);
                    options.PropertyInitializers.Add(f.Compile());
                }
                else
                    throw new InvalidOperationException("Invalid method signature.");
            }
        }
    }
}