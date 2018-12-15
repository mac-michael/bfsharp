using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace BFsharp
{
    public sealed class RuleCollection : ObservableCollection<Rule>
    {
        private readonly EntityExtensions _extension;
        private readonly Action<Rule> _decorator;

        internal RuleCollection(EntityExtensions extension, Action<Rule> decorator )
        {
            _extension = extension;
            _decorator = decorator;
        }

        protected override void InsertItem(int index, Rule rule)
        {
            _decorator(rule);

            var state = rule.State;

            _extension.OnRuleAdded(rule);
            base.InsertItem(index, rule);

            if (state == RuleState.AbleToRun)
                rule.Enable();
            else
                rule.Disable();
        }

        public void Remove(string name)
        {
            Remove(this.Single(r => r.Name == name));
        }

        protected override void RemoveItem(int index)
        {
            var rule = this[index];
            _extension.OnRuleRemoved(rule);

            base.RemoveItem(index);
        }

        protected override void SetItem(int index, Rule item)
        {
            throw new NotSupportedException();
        }

        protected override void ClearItems()
        {
            foreach (var rule in this)
                _extension.OnRuleRemoved(rule);
            
            base.ClearItems();
        }

        public Rule this[string name]
        {
            get { return this.SingleOrDefault(r => r.Name == name); }
        }

        //public void Start()
        //{
        //    Start(r => true);
        //}

        //public void Start(string tag)
        //{
        //    Start(r=>r.Tag == tag);
        //}

        //public void Start(Func<Rule, bool> predicate)
        //{
        //    foreach (var item in Items)
        //    {
        //        if ( predicate(item))
        //            item.Enable();
        //    }
        //}
    }
}