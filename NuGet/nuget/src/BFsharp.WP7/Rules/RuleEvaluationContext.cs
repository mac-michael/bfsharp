using System;

namespace BFsharp
{
    internal class RuleEvaluationContext : IDisposable
    {
        [ThreadStatic]
        static RuleEvaluationContext _current;
        readonly RuleEvaluationContext _prev;

        internal static RuleEvaluationContext Current
        {
            get { return _current; }
            set { _current = value; }
        }

        readonly Rule _rule;

        public RuleEvaluationContext(Rule rule)
        {
            _rule = rule;
            _prev = Current;
            Current = this;
        }

        public void Dispose()
        {
            Current = _prev;
        }

        internal bool IsRuleSuppressed(Rule rule)
        {
            var s = rule.IsRuleSuppressed(_rule);

            return s;
        }
    }
}