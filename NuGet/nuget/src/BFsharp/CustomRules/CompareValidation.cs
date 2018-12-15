using System;
using System.Reflection;

namespace BFsharp
{
    public class CompareAttribute : PropertyValidationAttribute
    {
        private readonly string _propertyName;

        public CompareAttribute(string propertyName)
        {
            _propertyName = propertyName;
        }

        protected internal override Rule CreateRule<T>(PropertyInfo propertyInfo, RuleFactory<T> factory, Func<T, object> selector)
        {
            var rule = base.CreateRule<T>(propertyInfo, factory, selector);

            rule.WithDependencies(_propertyName);

            return rule;
        }

        protected internal override Validation GetValidation(PropertyInfo propertyInfo)
        {
            var compareTo = propertyInfo.DeclaringType.GetProperty(_propertyName);

            var validation = ValidationFactory.Compare(compareTo);
            return validation;
        }

        protected internal override Type[] GetValidPropertyTypes()
        {
            return new[] { typeof(object) };
        }    
    }
    
    public class CompareValidation : Validation
    {
        public CompareValidation(PropertyInfo propertyInfo)
        {
            _func = PrecompilationHelper.GetPropertySelector(propertyInfo);
        }

        private readonly Func<object, object> _func;

        public override bool Validate(object target, object value)
        {
            object compareTo = _func(target);
            if (value == null && compareTo == null)
                return true;
            if ( value == null)
                return false;
            return value.Equals(compareTo);
        }
    }
}