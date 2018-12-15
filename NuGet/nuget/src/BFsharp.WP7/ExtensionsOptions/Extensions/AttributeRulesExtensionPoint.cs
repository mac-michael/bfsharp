using System.Resources;

namespace BFsharp
{
    class AttributeRulesExtensionPoint<T> : ExtensionPoint<T>
    {
        public override void Init(ExtensionsOptions<T> options)
        {
            var f = new RuleFactory<T>();

            foreach (var p in ReflectionHelper.GetProperties<T>())
            {
                foreach (PropertyValidationAttribute attribute in p.GetCustomAttributes(typeof(PropertyValidationAttribute), true))
                {
                    attribute.ValidatePropertyUsage(p);

                    // optimize
                    var selector = PrecompilationHelper.GetPropertySelector<T>(p);

                    var rule = attribute.CreateRule(p, f, selector);
                    
                    options.RulePrototypes.Add(rule);
                }
            }
        }
    }
}