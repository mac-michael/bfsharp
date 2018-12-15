using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BFsharp
{
    //internal class DependencyTreeNode
    //{
    //    struct RuleWithTag
    //    {
    //        public RuleWithTag(Rule rule, string tag)
    //            : this()
    //        {
    //            Rule = rule;
    //            Tag = tag;
    //        }

    //        public Rule Rule { get; set; }
    //        public string Tag { get; set; }
    //    }

    //    private Dictionary<string, DependencyTreeNode> _subtreeDependency;
    //    public Dictionary<string, DependencyTreeNode> SubtreeDependency
    //    {
    //        get
    //        {
    //            if (_subtreeDependency == null)
    //                _subtreeDependency = new Dictionary<string, DependencyTreeNode>();
    //            return _subtreeDependency;
    //        }
    //    }
    //    private List<RuleWithTag> _propertyDependency;
    //    private List<RuleWithTag> PropertyDependency
    //    {
    //        get
    //        {
    //            if (_propertyDependency == null)
    //                _propertyDependency = new List<RuleWithTag>();
    //            return _propertyDependency;
    //        }
    //    }

    //    public bool RemoveRuleDependency(Rule rule)
    //    {
    //        PropertyDependency.RemoveAll(r => r.Rule == rule);

    //        foreach (var kp in SubtreeDependency.Select(s=>s).ToList())
    //        {
    //            var node = kp.Value;
    //            if (node.RemoveRuleDependency(rule))
    //                SubtreeDependency.Remove(kp.Key);
    //        }

    //        if (SubtreeDependency.Count == 0)
    //        {
    //            // Unsubscribe from event
    //            var n = Target as INotifyPropertyChanged;
    //            if (n != null)
    //                n.PropertyChanged -= OnPropertyChange;
    //        }

    //        return SubtreeDependency.Count == 0 && PropertyDependency.Count == 0;
    //    }

    //    private DependencyTreeNode AddPropertyDependency(string propertyName, Rule rule, string tag, bool subscribe)
    //    {
    //        DependencyTreeNode node;
    //        if (!SubtreeDependency.TryGetValue(propertyName, out node))
    //        {
    //            node = new DependencyTreeNode();
    //            SubtreeDependency.Add(propertyName, node);
    //            if (subscribe)
    //                node.Subscribe(GetPropertyObject(propertyName));
    //        }
    //        node.PropertyDependency.Add(new RuleWithTag(rule, tag));

    //        return node;
    //    }

    //    private object GetPropertyObject(string propertyName)
    //    {
    //        if (Target == null) return null;

    //        var property = Target.GetType().GetProperty(propertyName);
    //        if (property == null) return null;

    //        var g = property.GetGetMethod(true);
    //        if (g == null) return null;
    //        var obj = g.Invoke(Target, new object[0]);
    //        return obj;
    //    }

    //    internal void AddPropertyDependency(Rule rule, List<string> propertyPath, string tag)
    //    {
    //        var node = this;
    //        for (int i = 0; i < propertyPath.Count; i++)
    //        {
    //            var memberPart = propertyPath[i];
    //            node = node.AddPropertyDependency(memberPart, rule, tag, i+1<propertyPath.Count);
    //        }
    //    }

    //    private bool IsContainer
    //    {
    //        get { return _subtreeDependency != null && _subtreeDependency.Count > 0; }
    //    }

    //    private object Target { get; set; }

    //    internal void Subscribe(object target)
    //    {
    //        // Unsubscribe
    //        var npc = Target as INotifyPropertyChanged;
    //        if (npc != null)
    //            npc.PropertyChanged -= OnPropertyChange;

    //        // Subscribe
    //        Target = target;

    //        if (Target != null)
    //        {
    //            var n = Target as INotifyPropertyChanged;
    //            if (n == null)
    //                RuleDebugger.Warning(string.Format("{0}: \"{1}\" doesn't implement INotifyPropertyChanged.",
    //                                              Target.GetType().Name, Target));
    //            else
    //                n.PropertyChanged += OnPropertyChange;
    //        }

    //        // Recursive
    //        foreach (var node in SubtreeDependency)
    //        {
    //            if (node.Value.IsContainer)
    //            {
    //                object obj = null;
    //                if (target != null)
    //                    obj = GetPropertyObject(node.Key);

    //                node.Value.Subscribe(obj);
    //            }
    //        }
    //    }

    //    private void OnPropertyChange(object sender, PropertyChangedEventArgs e)
    //    {
    //        DependencyTreeNode property;
    //        if ( SubtreeDependency.TryGetValue(e.PropertyName, out property))
    //        {
    //            // Subscribe events
    //            if ( property.IsContainer )
    //                property.Subscribe(GetPropertyObject(e.PropertyName));
                
    //            // Notify rules
    //            foreach (RuleWithTag ruleWithTag in property.PropertyDependency.OrderBy(r=>r.Rule.Priority))
    //                ruleWithTag.Rule.OnInternalDependencyChanged(ruleWithTag.Tag);
    //        }
    //    }
    //}
}