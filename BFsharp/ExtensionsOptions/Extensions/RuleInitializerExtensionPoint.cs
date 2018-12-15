namespace BFsharp
{
    class RuleInitializerExtensionPoint<T> : ExtensionPoint<T>
    {
        public override void Init(ExtensionsOptions<T> options)
        {
            options.RuleInitializers.Add(RuleInit);
        }

        private static void RuleInit(T target)
        {
            foreach (var method in ReflectionHelper.GetMethodsWithAttributeOfType<T,RuleInitAttribute>())
                if (ReflectionHelper.IsMethod(method, false, typeof (void)))
                    method.Invoke(target, null);
        }
    }
}