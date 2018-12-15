using System;
using System.Reflection;
using BFsharp.Localization;

namespace BFsharp
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLengthAttribute : PropertyValidationAttribute
    {
        public MaxLengthAttribute(int maxLength)
        {
            MaxLength = maxLength;
        }

        public MaxLengthAttribute()
        {
            
        }

        public int MaxLength { get; set; }
        protected internal override Validation GetValidation(PropertyInfo propertyInfo)
        {
            return ValidationFactory.MaxLengthR(MaxLength);
        }

        protected internal override Type[] GetValidPropertyTypes()
        {
            return new[] {typeof (string)};
        }
    }

    public class MaxLengthValidation : Validation<string>
    {
        public MaxLengthValidation(int maxLength)
        {
            MaxLength = maxLength;
            LocalizableMessageFunc = r => string.Format(LocalizationManager.GetString(LocalizationString.MaxLengthValidation_Message), MaxLength);
        }

        public int MaxLength { get; set; }

        public override bool Validate(string value)
        {
            if (string.IsNullOrEmpty(value)) return true;

            return value.Length <= MaxLength;
        }
    }
}