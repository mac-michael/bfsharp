using System;
using System.Reflection;
using BFsharp.Localization;

namespace BFsharp
{
    public class RequiredAttribute : PropertyValidationAttribute
    {
        protected internal override Validation GetValidation(PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType == typeof (string))
                return new StringRequiredValidation();
            return new RequiredValidation<object>();
        }

        protected internal override Type[] GetValidPropertyTypes()
        {
            return new[] { typeof(object) };
        }
    }

    public class RequiredValidation<TValue> : Validation<TValue> 
        where TValue : class 
    {
        public RequiredValidation()
        {
            LocalizableMessageFunc = r=> LocalizationManager.GetString(LocalizationString.RequiredValidation_Message);
        }

        public override bool Validate(TValue value)
        {
            return !value.Equals(default(TValue));
        }
    }
}