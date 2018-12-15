using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using BFsharp.Localization;

namespace BFsharp
{
    public abstract class StringTypePropertyValidationAttribute : PropertyValidationAttribute
    {
        protected object GetPropertyValue(object value, PropertyInfo propertyInfo)
        {
            if (value == null) return null;

            if (value.GetType() != propertyInfo.PropertyType)
            {
                if (value.GetType() == typeof(string))
                {
                    value = Parse(propertyInfo.PropertyType, (string)value);
                }
                    // Build in conversions
                else if (value is int && propertyInfo.PropertyType == typeof(decimal))
                    value = (decimal) (int)value;
                else
                    throw new InvalidOperationException();
            }
            return value;
        }

        private static object Parse(Type type, string s)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Decimal:
                    return decimal.Parse(s, System.Globalization.CultureInfo.InvariantCulture);
                case TypeCode.Boolean:
                    return bool.Parse(s);
                case TypeCode.Byte:
                    return byte.Parse(s);
                case TypeCode.Char:
                    return s[0];
                case TypeCode.DateTime:
                    return DateTime.Parse(s, System.Globalization.CultureInfo.InvariantCulture);
            }

            throw new InvalidOperationException();
        }
    }

    public class ShouldBeAttribute : StringTypePropertyValidationAttribute
    {
        public object Value { get; set; }
        public ShouldBeAttribute(object value)
        {
            Value = value;
        }

        protected internal override Validation GetValidation(PropertyInfo propertyInfo)
        {
            object value = GetPropertyValue(Value, propertyInfo);

            return (Validation)Activator.CreateInstance(
                typeof(ShouldBeValidation<>).MakeGenericType(propertyInfo.PropertyType),
                value);
        }

        protected internal override void ValidatePropertyUsage(PropertyInfo propertyInfo)
        {
            // All types are supported
        }
    }

    public class ShouldBeValidation<T> : Validation<T>
    {
        public ShouldBeValidation(T value)
        {
            Value = value;
            LocalizableMessageFunc = r => string.Format(LocalizationManager.GetString(LocalizationString.ShouldBeValidation_Message), value.ToString());
        }

        public T Value { get; set; }
        public override bool Validate(T value)
        {
            if ( Value == null && value == null)
                return true;
            if (Value == null || value == null)
                return false;
            else
                return Value.Equals(value);
        }
    }

    public class RangeAttribute : StringTypePropertyValidationAttribute
    {
        public object Low { get; set; }
        public object High { get; set; }

        public bool IncludeLow { get; set; }
        public bool IncludeHigh { get; set; }

        public RangeAttribute()
        {
            IncludeLow = true;
            IncludeHigh = true;
        }

        public RangeAttribute(int low, int high)
            : this()
        {
            Low = low;
            High = high;
        }

        public RangeAttribute(long low, long high)
            : this()
        {
            Low = low;
            High = high;
        }

        public RangeAttribute(string low, string high)
            : this()
        {
            Low = low;
            High = high;
        }
        
        protected internal override Validation GetValidation(PropertyInfo propertyInfo)
        {
            object low = GetPropertyValue(Low, propertyInfo);
            object high = GetPropertyValue(High, propertyInfo);
           
            //var type = typeof(Nullable<>).MakeGenericType(propertyInfo.PropertyType);

            return (Validation) Activator.CreateInstance(
                typeof (RangeValidation<>).MakeGenericType(propertyInfo.PropertyType),
                low, high, IncludeLow, IncludeHigh);
        }
         
        protected internal override void ValidatePropertyUsage(PropertyInfo propertyInfo)
        {
            if (!typeof (IComparable).IsAssignableFrom(propertyInfo.PropertyType))
                throw new InvalidOperationException(string.Format(
                    "Property type have to implement IComparable: {0}.{1}", propertyInfo.DeclaringType.Name,
                    propertyInfo.Name));
        }
    }
}