using System;

namespace BFsharp
{
    public class ValidationRule<T> : ValidationRule, IRuleOwner<ValidationRule<T>, T>
    {
        private readonly Func<T, bool> _evaluateFunc;

        public ValidationRule(Func<T,bool> evaluateFunc)
        {
            _evaluateFunc = evaluateFunc;
        }

        protected override bool OnValidateImplementation()
        {
            return _evaluateFunc((T) Extensions.Target);
        }
    }

    public abstract class ValidationRule : ValidationRuleBase
    {
        protected ValidationRule()
        {
            StartupMode = ValidationRuleStartupMode.Validate;
        }
        public ValidationRuleStartupMode StartupMode { get; set; }

        protected override void OnEnable()
        {
            if (StartupMode == ValidationRuleStartupMode.Validate)
                Validate();
        }

        protected internal override void OnPropertyChanged(string tag)
        {
            Validate();
        }

        protected sealed override bool OnValidate()
        {
            bool res = false;

            InvokeWithExceptionFilter(() =>
            {
                Breakpoint();
                res = OnValidateImplementation();
            });
            return res;
        }

        protected abstract bool OnValidateImplementation();
    }
}