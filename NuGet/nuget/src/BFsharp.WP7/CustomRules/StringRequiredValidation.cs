using System;
using BFsharp.Localization;

namespace BFsharp
{
    public class StringRequiredValidation : Validation<string>
    {
        public StringRequiredValidation()
        {
            LocalizableMessageFunc = r=> LocalizationManager.GetString(LocalizationString.StringRequiredValidation_Message);
        }

        public override bool Validate(string value)
        {
            if (value == null) return false;
            return value.Trim().Length > 0;
        }
    }

    public class RangeValidation<T> : Validation<T>
        where T : IComparable<T>
    {
        private T _low;
        public T Low
        {
            get { return _low; }
            set
            {
                _low = value;
                CheckLow = true;
            }
        }

        private T _high;
        public T High
        {
            get { return _high; }
            set
            {
                _high = value;
                CheckHigh = true;
            }
        }

        public bool IncludeLow { get; set; }
        public bool IncludeHigh { get; set; }
        public bool CheckLow { get; private set; }
        public bool CheckHigh { get; private set; }

        public RangeValidation(object low, object high, bool includeLow, bool includeHigh)
        {
            if ((low != null && !(low is T)) ||
                (high != null && !(high is T)))
                throw new InvalidOperationException("Low and High should be of type T.");

            if (low != null)
            {
                Low = (T)low;
                CheckLow = true;
            }
            if ( high != null)
            {
                High = (T) high;
                CheckHigh = true;
            }
            
            IncludeLow = includeLow;
            IncludeHigh = includeHigh;
            
            LocalizableMessageFunc = r=> string.Format(LocalizationManager.GetString(LocalizationString.RangeValidation_Message), low, high);
        }

        public override bool Validate(T value)
        {
            if (CheckLow && !(IncludeLow ? value.CompareTo(Low) >= 0 : value.CompareTo(Low) > 0))
                return false;

            if (CheckHigh && !(IncludeHigh ? value.CompareTo(High) <= 0 : value.CompareTo(High) < 0))
                return false;

            return true;
        }
    }
}