using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using BFsharp.Localization;

namespace BFsharp
{
    public class EmailAttribute : PropertyValidationAttribute
    {
        public bool AllowEmpty { get; set; }
        protected internal override Validation GetValidation(PropertyInfo propertyInfo)
        {
            var validation = ValidationFactory.Email();
            validation.AllowEmpty = AllowEmpty;
            return validation;
        }

        protected internal override Type[] GetValidPropertyTypes()
        {
            return new[] {typeof (string)};
        }
    }
    
    public class EmailValidation : Validation<string>
    {
        static Regex _regex;
        static EmailValidation()
        {
            const string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            SetEmailPattern(pattern);
        }

        public static void SetEmailPattern(string pattern)
        {
#if !SILVERLIGHT
            const RegexOptions options = RegexOptions.Compiled;
#else
            const RegexOptions options = RegexOptions.None;
#endif
            _regex = new Regex(pattern, options);
        }

        public EmailValidation()
        {
            LocalizableMessageFunc = r => LocalizationManager.GetString(LocalizationString.EmailValidation_Message);
        }

        public bool AllowEmpty { get; set; }

        public override bool Validate(string value)
        {
            if (string.IsNullOrEmpty(value))
                return AllowEmpty;

            return _regex.IsMatch(value);
        }
    }
}