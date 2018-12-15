using System;

namespace BFsharp
{
    class DynamicPropertiesExtensionPoint<T> : ExtensionPoint<T>
    {
        public override void Init(ExtensionsOptions<T> options)
        {
            options.PropertyInitializers.Add(PropertyInit);
        }

        private static void PropertyInit(T target)
        {
            foreach (var method in ReflectionHelper.GetMethodsWithAttributeOfType<T,PropertiesInitAttribute>())
            {
                if (ReflectionHelper.IsMethod(method, false, typeof(void)))
                    method.Invoke(target, null);
                else
                    throw new InvalidOperationException("Invalid method signature.");
            }
        }
    }
}