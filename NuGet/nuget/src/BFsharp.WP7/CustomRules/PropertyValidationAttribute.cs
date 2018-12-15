using System;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace BFsharp
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class PropertyValidationAttribute : Attribute
    {
        protected internal abstract Validation GetValidation(PropertyInfo propertyInfo);
        protected internal virtual Rule CreateRule<T>(PropertyInfo propertyInfo, RuleFactory<T> factory, Func<T, object> selector )
        {
            var validation = GetValidation(propertyInfo);
            if (Message != null)
                validation.Message = Message;
            if (MessageResourceName != null && MessageResourceType != null)
            {
                ResourceManager rm = new ResourceManager(MessageResourceType);
                validation.LocalizableMessageFunc = r => rm.GetString(MessageResourceName);
            }

            if (_severity.HasValue)
                validation.Severity = _severity.Value;

            var rule = factory.CreateValidationRuleWithoutDependency(
                selector, validation)
                .WithDependencies(propertyInfo.Name)
                .WithOwner(propertyInfo.Name);

            return rule;
        }

        protected internal virtual void ValidatePropertyUsage(PropertyInfo propertyInfo)
        {
            foreach (var validPropertyType in GetValidPropertyTypes())
            {
                if (validPropertyType.IsAssignableFrom(propertyInfo.PropertyType))
                    return;
            }

            throw new InvalidOperationException(
                string.Format("{2} rule is not valid on {3} properties: {0}.{1}", propertyInfo.DeclaringType.Name,
                              propertyInfo.Name,
                              GetType().Name.EndsWith("Attribute")
                                  ? GetType().Name.Substring(0, GetType().Name.Length - 9)
                                  : GetType().Name, propertyInfo.PropertyType.Name));
        }

        internal BrokenRuleSeverity? _severity;
        public BrokenRuleSeverity Severity
        {
            set { _severity = value; }
            get
            {
                if (!_severity.HasValue)
                    throw new InvalidOperationException("Severity was not set so cannot be returned.");

                return _severity.Value;
            }
        }
        public string Message { get; set; }
        public Type MessageResourceType { get; set; }
        public string MessageResourceName { get; set; }

        protected internal virtual Type[] GetValidPropertyTypes()
        {
            return new Type[0];
        }
    }
}