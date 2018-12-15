using System;
using System.Globalization;

namespace BFsharp
{
    public abstract class Validation<TValue> : Validation
    {
        public abstract bool Validate(TValue value);
        public override bool Validate(object target, object value)
        {
            if (!(value is TValue))
                value = (TValue) Convert.ChangeType(value, typeof (TValue), CultureInfo.InvariantCulture);

            return Validate((TValue) value);
        }
    }
    
    public abstract class Validation
    {
        public Validation()
        {
            Severity = BrokenRuleSeverity.Error;
        }

        public abstract bool Validate(object target, object value);

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                _localizableMessageFunc = null;
            }
        }

        private Func<Rule, string> _localizableMessageFunc;
        public Func<Rule, string> LocalizableMessageFunc
        {
            get { return _localizableMessageFunc; }
            set
            {
                _localizableMessageFunc = value;
                _message = null;
            }
        }

        public BrokenRuleSeverity Severity { get; set; }

        internal protected virtual Validation Copy()
        {
            return (Validation) MemberwiseClone();
        }
    }
}