using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace BFsharp
{
    public sealed class BrokenRuleCollection : ObservableCollection<BrokenRule>
    {
        protected override void InsertItem(int index, BrokenRule item)
        {
            base.InsertItem(index, item);
            OnRuleBroken(item);
        }

        protected override void RemoveItem(int index)
        {
            var brokenRule = this[index];
            base.RemoveItem(index);
            OnRuleRepaired(brokenRule);
        }

        public event EventHandler<BrokenRuleEventArgs> RuleBroken;
        public event EventHandler<BrokenRuleEventArgs> RuleRepaired;

        private void OnRuleBroken(BrokenRule rule)
        {
            var e = RuleBroken;
            if (e != null)
                e(this, new BrokenRuleEventArgs(rule));
        }

        private void OnRuleRepaired(BrokenRule rule)
        {
            var e = RuleRepaired;
            if (e != null)
                e(this, new BrokenRuleEventArgs(rule));
        }

        protected override void SetItem(int index, BrokenRule item)
        {
            throw new InvalidOperationException();
        }
    }
}