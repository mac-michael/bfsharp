using System;
using BFsharp.Localization;

namespace BFsharp
{
    public abstract class ValidationRuleBase : Rule
    {
        protected ValidationRuleBase()
        {
            Message = LocalizationManager.GetString(LocalizationString.ValidationRuleBase_Message);
            Severity = BrokenRuleSeverity.Error;
        }

        protected abstract bool OnValidate();

        public bool Validate(bool forceValidate = false)
        {
            if (!(forceValidate || Condition(Extensions.Target))) return BrokenRule == null;

            RuleDebugger.Info("Validating rule " + Name);

            bool status;
            using (new RuleEvaluationContext(this))
                status = OnValidate();

            if (!status )
            {
                if (BrokenRule == null)
                    OnRuleBroke();
                else
                    UpdateBrokenRule(BrokenRule);
            }
            else if (status && BrokenRule != null)
                OnRuleRepaired();

            RuleDebugger.Info("Validation status: " + (status ? "valid" : "failed"));

            return status;
        }

        protected void OnRuleRepaired()
        {
            Extensions.BrokenRules.Remove(BrokenRule);
            BrokenRule = null;
        }

        protected void OnRuleBroke()
        {
            BrokenRule = GetBrokenRule();
            Extensions.BrokenRules.Add(BrokenRule);
        }

        protected override void OnDisable()
        {
            OnRuleRepaired();
        }

        protected virtual void UpdateBrokenRule(BrokenRule brokenRule)
        {
            var message = LocalizableMessageFunc != null ? LocalizableMessageFunc(this) : Message;

            brokenRule.Message = message;
            brokenRule.Owner = Owner;
            brokenRule.Severity = Severity;
        }

        protected virtual BrokenRule GetBrokenRule()
        {
            var message = LocalizableMessageFunc != null ? LocalizableMessageFunc(this) : Message;

            return new BrokenRuleWithSource {Message = message, Severity = Severity, Owner = Owner, Rule = this};
        }

        public BrokenRule BrokenRule { get; private set; }

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
        public string Owner { get; set; }

        protected override void CopyInternal(Rule r)
        {
            var r2 = (ValidationRuleBase) r;
            r2.BrokenRule = null;

            base.CopyInternal(r);
        }
    }
}