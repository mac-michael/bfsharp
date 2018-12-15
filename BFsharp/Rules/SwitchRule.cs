using System;
using System.Linq;

namespace BFsharp
{
    public abstract class SwitchRule : Rule
    {
        public SwitchRule()
        {
            Reevaluate = true;
        }

        public abstract Type SwitchType { get; }
        public abstract object GetSwitch();
        public bool Reevaluate { get; set; }
    }

    public class SwitchRule<T,S> : SwitchRule, IRuleOwner<SwitchRule<T,S>, T>
    {
        private readonly Func<T, S> _switchSelector;

        public SwitchRule(Func<T, S> switchSelector )
        {
            _switchSelector = switchSelector;
        }

        protected internal override void OnPropertyChanged(string tag)
        {
            Invoke();
        }

        public override object GetSwitch()
        {
            return _switchSelector((T) Extensions.Target);
        }

        public override Type SwitchType
        {
            get { return typeof(S); }
        }

        public void Invoke(bool forceInvoke = false)
        {
            if (!(forceInvoke || Condition(Extensions.Target))) return;

            var @switch = GetSwitch();
            SwitchRules(@switch);
            
            if (Reevaluate)
                ReevaluateRules(@switch);
        }

        protected override void OnEnable()
        {
            Invoke();
        }

        private void SwitchRules( object @switch)
        {
            Extensions.DoClusterAction(e =>
                        {
                            foreach (var rule in e.Rules.Where(r => r.Switch != null && r.Switch.GetType() == @switch.GetType()))
                            {
                                if (rule.Switch.Equals(@switch) && rule.State == RuleState.Disabled)
                                    rule.Enable();
                                else if (!rule.Switch.Equals(@switch) && rule.State == RuleState.Enabled)
                                    rule.Disable();
                            }
                        });
        }

        private void ReevaluateRules(object @switch)
        {
            Extensions.DoClusterAction(e =>
                        {
                            foreach (var rule in e.Rules.Where(r => r.Switch != null && r.Switch.Equals(@switch)))
                            {
                                if (rule is ActionRule)
                                    ((ActionRule)rule).Invoke();
                                else if (rule is BusinessRule)
                                {
                                    var businessRule = (BusinessRule) rule;
                                    if (businessRule.Mode == BusinessRuleMode.Evaluate)
                                        businessRule.Evaluate();
                                    else if (businessRule.Mode == BusinessRuleMode.Validate)
                                        businessRule.Validate();
                                }
                            }
                        });
        }
    }
}