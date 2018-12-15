using System;

namespace BFsharp
{
    public abstract class ActionRule : Rule
    {
        protected ActionRule()
        {
            StartupMode = ActionRuleStartupMode.None;
        }

        public ActionRuleStartupMode StartupMode { get; set; }
        public abstract void Invoke();

        protected override void OnEnable()
        {
            if (StartupMode == ActionRuleStartupMode.Invoke)
                Invoke();
        }
    }

    public class ActionRule<T> : ActionRule, IRuleOwner<ActionRule<T>,T>
    {
        private readonly Action<T> _action;
        public ActionRule(Action<T> action)
        {
            _action = action;
        }

        protected internal override void OnPropertyChanged(string tag)
        {
            Invoke();
        }

        public override void Invoke()
        {
            using (new RuleEvaluationContext(this))
                InvokeWithExceptionFilter(() =>
                                              {
                                                  Breakpoint();
                                                  _action((T) Extensions.Target);
                                              });

            if (IsOneTime)
                Extensions.Rules.Remove(this);
        }
    }
}
