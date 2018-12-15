using System;

namespace BFsharp
{
    public abstract class PredefinedValidationRule : ValidationRule
    {
        public Validation ValidationStrategy { get; protected set; }

        protected override void CopyInternal(Rule r)
        {
            base.CopyInternal(r);
            ValidationStrategy = ((PredefinedValidationRule) r).ValidationStrategy.Copy();
        }
    }

    public class PredefinedValidationRule<T, V> : PredefinedValidationRule, 
        IRuleOwner<PredefinedValidationRule<T,V>, T>
        where V : Validation
    {
        private readonly Func<T, V, bool> _evaluateFunc;

        public PredefinedValidationRule(Func<T, V, bool> evaluateFunc, V validationStrategy)
        {
            ValidationStrategy = validationStrategy;
            if (ValidationStrategy.Message != null)
                Message = ValidationStrategy.Message;
            if (ValidationStrategy.LocalizableMessageFunc != null)
                LocalizableMessageFunc = ValidationStrategy.LocalizableMessageFunc;
            Severity = ValidationStrategy.Severity;

            _evaluateFunc = evaluateFunc;
        }

        protected override bool OnValidateImplementation()
        {
            return _evaluateFunc((T)Extensions.Target, (V) ValidationStrategy);
        }
    }
}