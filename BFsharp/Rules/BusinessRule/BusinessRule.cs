using System;
using System.Linq;

namespace BFsharp
{
    public abstract class BusinessRule : ValidationRuleBase
    {
        internal const string TargetChangeTag = "target";

        public BusinessRuleStartupMode StartupMode { get; set; }
        public BusinessRuleMode Mode { set; get; }
        public BusinessRuleTargetChangeAction TargetChangeAction { get; set; }
        public bool DisableValidation { get; set; }

        protected BusinessRule()
        {
            StartupMode = BusinessRuleStartupMode.Validate;
            Mode = BusinessRuleMode.Evaluate;
            TargetChangeAction = BusinessRuleTargetChangeAction.Validate;
        }

        protected override void OnEnable()
        {
            if (StartupMode == BusinessRuleStartupMode.Evaluate)
                Evaluate();
            else if (StartupMode == BusinessRuleStartupMode.Validate && !DisableValidation)
                Validate();
        }

        public abstract void Evaluate(bool forceEvaluate = false);

        protected internal override void OnPropertyChanged(string tag)
        {
            if (tag == TargetChangeTag)
            {
                if (TargetChangeAction == BusinessRuleTargetChangeAction.Validate)
                    Validate();
                else if (TargetChangeAction == BusinessRuleTargetChangeAction.Override)
                    Evaluate();
            }
            else
            {
                if (Mode == BusinessRuleMode.Evaluate)
                    Evaluate();
                else if (Mode == BusinessRuleMode.Validate && !DisableValidation)
                    Validate();    
            }            
        }

        internal object _value;
        internal object _targetValue;
    }

    public class BusinessRule<TEntity, TValue> : BusinessRule, IRuleOwner<BusinessRule<TEntity,TValue>, TEntity>
    {
        private readonly Func<TEntity, TValue> _func;
        private readonly Func<TEntity, TValue> _targetGet;
        private readonly Action<TEntity, TValue> _targetSet;
        

        public BusinessRule(Func<TEntity,TValue> func, Func<TEntity,TValue> targetGet,
            Action<TEntity,TValue> targetSet)
        {
            _func = func;
            _targetGet = targetGet;
            _targetSet = targetSet;
        }

        public override void Evaluate(bool forceEvaluate = false)
        {
            if (!(forceEvaluate || Condition(Extensions.Target))) return;

            var parent = (TEntity) Extensions.Target;
            TValue value = default(TValue);

            RuleDebugger.Info("Evaluating rule " + Name);

            using (new RuleEvaluationContext(this))
            {
                bool exception = InvokeWithExceptionFilter(() =>
                                                               {
                                                                   Breakpoint();
                                                                   value = _func(parent);
                                                               });

                RuleDebugger.Info("Evaluation results: " + value);

                if (!exception)
                {
                    _targetSet(parent, value);
                    OnRuleRepaired();
                }
            }

            if (IsOneTime)
                Extensions.Rules.Remove(this);
        }

        protected override bool OnValidate()
        {
            if (DisableValidation) return true;

            var parent = (TEntity) Extensions.Target;
            using (new RuleEvaluationContext(this))
            {
                _value = default(TValue);
                _targetValue = _targetGet(parent);


                bool exception = InvokeWithExceptionFilter(() =>
                                                               {
                                                                   Breakpoint();
                                                                   _value = _func(parent);
                                                               });

                if (exception)
                    return true;

                // Prevent from null reference object
                // TODO: default(TEntity)?
                if (_targetValue == null)
                    return false;

                return _targetValue.Equals(_value);
            }
        }

        protected override BrokenRule GetBrokenRule()
        {
            var message = LocalizableMessageFunc != null ? LocalizableMessageFunc(this) : Message;

            return new BusinessRuleBrokenRule
                       {
                           Message = message,
                           Severity = Severity,
                           Owner = Owner,
                           Rule = this,
                       };
        }
    }
}