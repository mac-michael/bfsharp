using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BFsharp
{
    public class DataAnnotationsExtensionPoint<T> : ExtensionPoint<T>
    {
        public override void Init(ExtensionsOptions<T> options)
        {
            var f = new RuleFactory<T>();

            foreach (var p in ReflectionHelper.GetProperties<T>())
            {
                foreach (var a in p.GetCustomAttributes(typeof(ValidationAttribute), true))
                {
                    var selector = PrecompilationHelper.GetPropertySelector<T>(p);

                    var a2 = (ValidationAttribute) a;

                    var l = new List<ValidationResult>();
                    string name = p.Name;
                    var rule = f.CreateValidationRuleWithoutDependency(
                        t =>
                        Validator.TryValidateValue(selector(t),
                                                   new ValidationContext(t, null, null)
                                                       {MemberName = name, DisplayName = name}, l, new[] {a2}))
                        .WithDependencies(name);

                    rule.WithLocalizableMessage(t => l.First().ErrorMessage);

                    options.RulePrototypes.Add(rule);
                }
            }
        }
    }
}