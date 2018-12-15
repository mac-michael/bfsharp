using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace BFsharp
{
    public class DependencyNode
    {
        #region Data
        public struct ActionWithTag
        {
            public ActionWithTag(Action<string> action, string tag) : this()
            {
                Action = action;
                Tag = tag;
                Priority = () => 0;
            }

            public Action<string> Action { get; set; }
            public string Tag { get; set; }
            public Func<int> Priority { get; set; }
        }

        private Dictionary<PropertyPathElement, DependencyNode> _subtreeDependency;
        protected Dictionary<PropertyPathElement, DependencyNode> SubtreeDependency
        {
            get
            {
                if (_subtreeDependency == null)
                    _subtreeDependency = new Dictionary<PropertyPathElement, DependencyNode>();
                return _subtreeDependency;
            }
        }
        private Dictionary<PropertyPathElement, List<ActionWithTag>> _dependency;
        protected Dictionary<PropertyPathElement, List<ActionWithTag>> Dependency
        {
            get
            {
                if (_dependency == null)
                    _dependency = new Dictionary<PropertyPathElement, List<ActionWithTag>>();
                return _dependency;
            }
        }

        private Dictionary<object, HashSet<object>> _targets;
        protected Dictionary<object, HashSet<object>> Targets
        {
            get
            {
                if (_targets == null)
                    _targets = new Dictionary<object, HashSet<object>>();
                return _targets;
            }
        }

        #endregion

        public void AddPropertyDependency(PropertyPath propertyPath, Action<string> action, string tag)
        {
            AddPropertyDependency(propertyPath, new ActionWithTag(action, tag));
        }

        public void AddPropertyDependency(PropertyPath propertyPath, ActionWithTag actionWithTag)
        {
            AddPropertyDependencyInternal(propertyPath, actionWithTag);
            Resubscribe(Targets[_nullObject], _nullObject);
        }

        private void AddPropertyDependencyInternal(IEnumerable<PropertyPathElement> propertyPath,
            ActionWithTag actionWithTag)
        {
            var propertyName = propertyPath.First();

            // Add property dependency
            PropertyPathElement propertyPathElement = propertyName;
            Dependency.GetOrAdd(propertyPathElement).Add(actionWithTag);

            if (propertyPath.Count() > 1)
            {
                var dp = SubtreeDependency.GetOrAdd(propertyPathElement);
                dp.AddPropertyDependencyInternal(propertyPath.Skip(1), actionWithTag);
            }
        }

        public bool RemoveDependency(Action<string> action)
        {
            return RemoveDependencyInternal(action);
        }

        private bool RemoveDependencyInternal(Action<string> action)
        {
            var toRemove = new List<PropertyPathElement>();
            foreach (var value in Dependency)
            {
                var propertyRules = value.Value;
                for (int j = 0; j < propertyRules.Count; j++)
                {
                    if (propertyRules[j].Action == action)
                    {
                        propertyRules.RemoveAt(j);
                        j--;
                    }
                }

                if (propertyRules.Count == 0)
                    toRemove.Add(value.Key);
            }
            
            foreach (var key in toRemove)
                Dependency.Remove(key);

            foreach (var kp in SubtreeDependency)
            {
                var node = kp.Value;
                if (node.RemoveDependency(action))
                    toRemove.Add(kp.Key);
            }

            foreach (var key in toRemove)
                SubtreeDependency.Remove(key);

            if (Dependency.Count == 0)
            {
                // Unsubscribe from event
                foreach (var target in Targets.Values)
                {
                    foreach (var t in target)
                    {
                        UnwireObject(t);
                        UnwireCollectionObject(t);
                    }
                }
            }

            return SubtreeDependency.Count == 0 && Dependency.Count == 0;
        }

        private void UnwireCollectionObject(object collection)
        {
            var ncc = collection as INotifyCollectionChanged;
            if (ncc != null)
            {
                ncc.CollectionChanged -= OnCollectionChanged;
                var enumerable = ncc as IEnumerable;
                foreach (var e in enumerable)
                    UnwireCollectionElement(e);
            }
        }

        private void Unsubscribe(object parent)
        {
            HashSet<object> targets;
            if ( Targets.TryGetValue(parent, out targets) )
            {
                Targets.Remove(parent);
                foreach (var target in targets)
                {
                    var n1 = target as INotifyCollectionChanged;
                    if (n1 != null)
                    {
                        n1.CollectionChanged -= OnCollectionChanged;
                        var enumerable = n1 as IEnumerable;
                        foreach (var e in enumerable)
                        {
                            UnwireCollectionElement(e);

                            foreach (var node in SubtreeDependency)
                                node.Value.Unsubscribe(e);
                        }
                    }

                    UnwireObject(target);

                    if (target != null)
                        foreach (var node in SubtreeDependency)
                            node.Value.Unsubscribe(target);
                }
            }
        }

        private void UnwireObject(object e)
        {
            var a = e as INotifyPropertyChanged;

            if (a != null)
                a.PropertyChanged -= OnPropertyChanged;
        }
        private void UnwireCollectionElement(object e)
        {
            var a = e as INotifyPropertyChanged;

            if (a != null)
                a.PropertyChanged -= OnCollectionElementChanged;
        }

        readonly object _nullObject = new object();
        public void Subscribe(object target)
        {
            Subscribe(new[] { target }, _nullObject);
        }

        public void Unsubscribe()
        {
            Unsubscribe(_nullObject);
        }
        
        private void Resubscribe(IEnumerable targets, object parent)
        {
            Unsubscribe(parent);
            Subscribe(targets, parent);
        }

        private void Subscribe(IEnumerable targets, object parent)
        {
            foreach (var target in targets)
            {
                if (target != null)
                {
                    // Add target
                    Targets.GetOrAdd(parent).Add(target);

                    if ( ShouldWireCollection() )
                    {
                        var n1 = target as INotifyCollectionChanged;
                        var enumerable = target as IEnumerable;
                        if (n1 != null && enumerable != null)
                        {
                            n1.CollectionChanged += OnCollectionChanged;
                            foreach (var e in enumerable)
                            {
                                WireCollectionElement(e);

                                foreach (var node in SubtreeDependency)
                                    node.Value.Subscribe(
                                        enumerable.Cast<object>().Select(obj => GetPropertyObject(obj, node.Key.Property)), e);
                            }
                        }
                    }
                    if ( ShouldWireObject() )
                    {
                        if (WireObject(target))
                        {
                            foreach (var node in SubtreeDependency)
                                node.Value.Subscribe(new[] { GetPropertyObject(target, node.Key) }, target);
                        }
                    }
                }
            }
        }

        private bool ShouldWireCollection()
        {
            return Dependency.Keys.Any(p => p.IsCollectionElement || p.IsAll);
        }

        private bool ShouldWireObject()
        {
            return Dependency.Keys.Any(p => p.IsProperty || p.IsAll);            
        }
        
        private bool WireObject(object obj)
        {
            var npc = obj as INotifyPropertyChanged;
            if (npc != null)
            {
                npc.PropertyChanged += OnPropertyChanged;
                return true;
            }

            var message = string.Format(
                "{0}: \"{1}\" doesn't imlement INotifyPropertyChanged",
                obj.GetType().Name, obj);
            RuleDebugger.CheckInternal(RuleDebugger.NoNotifyPropertyChangedWarning, message);
            
            return false;
        }

        private bool WireCollectionElement(object obj)
        {
            var npc = obj as INotifyPropertyChanged;
            if (npc != null)
            {
                npc.PropertyChanged += OnCollectionElementChanged;
                return true;
            }

            var message = string.Format(
                "{0}: \"{1}\" doesn't imlement INotifyCollectionChanged.",
                obj.GetType().Name, obj);
            RuleDebugger.CheckInternal(RuleDebugger.NoNotifyPropertyChangedWarning, message);

            return false;
        }

        private static object GetPropertyObject(object target, string propertyName)
        {
            // Special case
            PropertyInfo property;
            if (propertyName == "Extensions" && target is EntityBase)
                property = typeof (EntityBase).GetProperty(propertyName);
            else
                property = target.GetType().GetProperty(propertyName);
            if (property == null) return null;

            var g = property.GetGetMethod(true);
            if (g == null) return null;
            var obj = g.Invoke(target, new object[0]);
            return obj;
        }

        private void NotifyRules()
        {
            foreach (var name in Dependency.Keys)
                NotifyRules(name);
        }

        private void NotifyRules(string propertyName)
        {
            IEnumerable<ActionWithTag> actions = Enumerable.Empty<ActionWithTag>();
            List<ActionWithTag> list;
            if (Dependency.TryGetValue(propertyName, out list))
                actions = actions.Union(list);
            if (Dependency.TryGetValue("*", out list))
                actions = actions.Union(list);

            foreach (ActionWithTag ruleWithTag in actions.OrderByDescending(r=>r.Priority()).ToArray())
                ruleWithTag.Action(ruleWithTag.Tag);
        }

        void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyRules(e.PropertyName);

            DependencyNode property;
            if (SubtreeDependency.TryGetValue(e.PropertyName, out property))
                property.Resubscribe(new[] {GetPropertyObject(sender, e.PropertyName)}, sender);
        }

        void OnCollectionElementChanged(object sender, PropertyChangedEventArgs e)
        {
            var propertyName = "$" + e.PropertyName;

            NotifyRules(propertyName);

            DependencyNode property;
            if (SubtreeDependency.TryGetValue(propertyName, out property))
                property.Resubscribe(new[] {GetPropertyObject(sender, e.PropertyName)}, sender);
        }

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyRules();
            if ( e.Action == NotifyCollectionChangedAction.Add )
            {
                // TODO: Collection of collections
                foreach (var item in e.NewItems)
                {
                    WireCollectionElement(item);

                    foreach (var node in SubtreeDependency)
                        node.Value.Resubscribe(e.NewItems.Cast<object>().Select(obj => GetPropertyObject(obj, node.Key.Property)),
                                             sender);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Reset)
            {
                foreach (var item in e.OldItems)
                {
                    UnwireCollectionElement(item);
                    
                    foreach (var node in SubtreeDependency)
                        node.Value.Unsubscribe(item);
                }
            }
            else
                throw new NotImplementedException();
        }
    }
}