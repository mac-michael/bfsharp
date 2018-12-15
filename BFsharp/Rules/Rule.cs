using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace BFsharp
{
    public enum RuleBreakpoint
    {
        None,
        Break,
        BreakIfBroken,
    }

    public abstract class Rule
    {
        public RuleState State { get; private set; }
        public string Name { get; set; }
        public object Tag { get; set; }
        public object Switch { get; set; }

        internal EntityExtensions Extensions { get; private set; }
        public int Priority { get; set; }
        public bool IsOneTime { get; set; }
        public bool BreakpointEnabled { get; set; }

        public string DebugString { get; set; }

        [Conditional("DEBUG")]
        protected void Breakpoint()
        {
            if (BreakpointEnabled)
                Debugger.Break();
        }
        
        #region RuleSuppression

        private List<string> _suppressedRules;
        public List<string> SuppressedRules
        {
            get
            {
                if (_suppressedRules == null)
                    _suppressedRules = new List<string>();
                return _suppressedRules;
            }
        }

        internal bool IsRuleSuppressed(Rule rule)
        {
            return (_suppressedRules != null && _suppressedRules.Contains(rule.Name));
        }

        #endregion

        #region ExceptionFilter

        private List<RuleExceptionFilterBase> _exceptionActions;
        private BrokenRuleToken _brokenRuleToken;

        public List<RuleExceptionFilterBase> ExceptionActions
        {
            get
            {
                if (_exceptionActions == null)
                    _exceptionActions = new List<RuleExceptionFilterBase>();
                return _exceptionActions;
            }
        }

        protected bool InvokeWithExceptionFilter(Action action)
        {
            _brokenRuleToken.Cancel();

            try
            {
                action();
            }
            catch (Exception e)
            {
                if (ExceptionHelper.IsNonrecoverableException(e))
                    throw;

                if (_exceptionActions != null)
                {
                    foreach (var exceptionAction in _exceptionActions)
                    {
                        var brokenRules = exceptionAction.Process(e);
                        if (brokenRules == null) continue;

                        _brokenRuleToken = BrokenRuleToken.Create(Extensions, brokenRules);

                        return true; // Handled
                    }
                }

                throw;
            }

            return false;
        }

        #endregion

        #region Dependencies
        internal List<Pair<PropertyPath, string>> _propertyDependency;
        internal void AddPropertyDependency(PropertyPath propertyPath)
        {
            AddPropertyDependency(propertyPath, "");
        }

        internal void AddPropertyDependency(PropertyPath propertyPath, string tag)
        {
            if (_propertyDependency == null)
                _propertyDependency = new List<Pair<PropertyPath, string>>();

            _propertyDependency.Add(new Pair<PropertyPath, string>(propertyPath, tag));

            if (Extensions != null)
                Extensions.AddPropertyDependency(this, propertyPath, tag);
        }

        internal void OnInternalDependencyChanged(string tag)
        {
            if (State == RuleState.Enabled)
            {
                var context = RuleEvaluationContext.Current;
                if (context != null && context.IsRuleSuppressed(this))
                    return;

                OnPropertyChanged(tag);
            }
        }

        internal protected virtual void OnPropertyChanged(string tag) { }
        #endregion

        #region StateMachine management

        internal void OnRuleAdded(EntityExtensions extension)
        {
            Extensions = extension;
            State = RuleState.Added;
            if (_propertyDependency != null)
            {
                foreach (var propertyPath in _propertyDependency)
                    Extensions.AddPropertyDependency(this, propertyPath.One, propertyPath.Two);
            }
        }

        internal void OnRuleRemoved()
        {
            Disable();
            Extensions = null;
            State = RuleState.Disposed;
        }
        
        public void Enable()
        {
            if (State == RuleState.Created)
            {
                State = RuleState.AbleToRun;
                return;
            }

            if (State != RuleState.Added && State != RuleState.Disabled )
                throw new InvalidOperationException("Rule can only be enabled in Added or Disabled state.");

            // Check if to enable rule - switch
            if ( Switch != null )
            {
                var switchRule = FindSwitch(Extensions);
                if (switchRule == null || switchRule.GetSwitch() == null || !switchRule.GetSwitch().Equals(Switch))
                    return;
            }

            if (_startupActions != null)
                foreach (var startupAction in _startupActions)
                    startupAction(this);

            State = RuleState.Enabled;
            OnEnable();
        }

        private SwitchRule FindSwitch(IEntityExtensions extensions)
        {
            var rule = extensions.Rules.OfType<SwitchRule>().FirstOrDefault(r => r.SwitchType == Switch.GetType());
            if (rule != null)
                return rule;

            if (extensions.Parent != null)
                return FindSwitch(extensions.Parent);

            return null;
        }

        private List<Action<Rule>> _startupActions;
        public List<Action<Rule>> StartupActions
        {
            get
            {
                if (_startupActions == null)
                    _startupActions = new List<Action<Rule>>();
                return _startupActions;
            }
        }

        protected virtual void OnEnable() {}

        public void Disable()
        {
            if (State != RuleState.Enabled && State != RuleState.Added )
                throw new InvalidOperationException("Rule can only be disabled in Enabled or Added state.");

            OnDisable();
            State = RuleState.Disabled;
        }

        protected virtual void OnDisable() {}

        #endregion

        private Func<object, bool> _condition = r => true;
        public Func<object, bool> Condition
        {
            get
            {
                return _condition;
            }
            set
            {
                _condition = value;
                if (value == null)
                    _condition = t => true;
            }
        }

        public override string ToString()
        {
            var b = new StringBuilder();
            if (!string.IsNullOrEmpty(Name))
                b.AppendFormat("Name={0}", Name);
            if (!string.IsNullOrEmpty(DebugString))
            {
                if (!string.IsNullOrEmpty(Name))
                    b.Append(",");
                b.AppendFormat("DebugString={0}", DebugString);
            }

            return b.Length > 0 ? b.ToString() : base.ToString();
        }

        #region Prototypes
        internal Rule Copy()
        {
            var rule = (Rule)MemberwiseClone();

            rule.CopyInternal(this);
            if (rule.State == RuleState.AbleToRun || rule.State == RuleState.Enabled)
                rule.State = RuleState.AbleToRun;
            else
                rule.State = RuleState.Created;

            return rule;
        }

        protected virtual void CopyInternal(Rule r)
        {
            if (r._propertyDependency==null) return;

            _propertyDependency = new List<Pair<PropertyPath, string>>(r._propertyDependency.Count);

            foreach (var list in r._propertyDependency)
                _propertyDependency.Add(new Pair<PropertyPath, string>(new PropertyPath(list.One), list.Two));
        }
        #endregion
    }
}