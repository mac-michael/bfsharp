using System;
using System.Reflection;
using System.Text.RegularExpressions;
using BFsharp.Localization;

namespace BFsharp
{
    public class PatternAttribute : PropertyValidationAttribute
    {
        public PatternAttribute(string pattern) 
        {
            Pattern = pattern;
        }

        public string Pattern { get; private set; }

        protected internal override Validation GetValidation(PropertyInfo propertyInfo)
        {
            return ValidationFactory.Pattern(Pattern);
        }

        protected internal override Type[] GetValidPropertyTypes()
        {
            return new[] { typeof(string) };
        }
    }

    public class PatternValidation : Validation<string>
    {
        readonly Regex _regex;

        public PatternValidation(string regexPattern)
        {
            _regex = new Regex(regexPattern);
            LocalizableMessageFunc = r=> string.Format(LocalizationManager.GetString(LocalizationString.PatternValidation_Message));
        }

        public override bool Validate(string value)
        {
            return string.IsNullOrEmpty(value) || _regex.IsMatch(value);
        }
    }
}