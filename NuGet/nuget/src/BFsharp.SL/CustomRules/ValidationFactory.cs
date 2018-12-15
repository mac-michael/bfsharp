using System;
using System.Reflection;

namespace BFsharp
{
    public static class ValidationFactory
    {
        public static MaxLengthValidation MaxLengthR(int maxLength)
        {
            return new MaxLengthValidation(maxLength);
        }

        public static EmailValidation Mail()
        {
            return new EmailValidation();
        }

        public static StringRequiredValidation Required()
        {
            return new StringRequiredValidation();
        }

        public static RequiredValidation<T> Required<T>() where T : class
        {
            return new RequiredValidation<T>();
        }

        public static RangeValidation<T> Range<T>(T low, T high, bool includeLow, bool includeHigh)
            where T : IComparable<T>
        {
            return new RangeValidation<T>(low, high, includeLow, includeHigh);
        }

        public static PatternValidation Pattern(string pattern)
        {
            return new PatternValidation(pattern);
        }

        public static EmailValidation Email()
        {
            return new EmailValidation();
        }

        public static Validation Compare<T>(string propertyName)
        {
            var propertyInfo = typeof (T).GetProperty(propertyName);
            return Compare(propertyInfo);
        }

        public static Validation Compare(PropertyInfo propertyName)
        {
            return new CompareValidation(propertyName);
        }
    }
}