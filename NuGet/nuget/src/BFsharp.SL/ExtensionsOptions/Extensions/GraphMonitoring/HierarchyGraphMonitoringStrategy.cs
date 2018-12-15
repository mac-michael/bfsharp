using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace BFsharp
{
    public class HierarchyGraphMonitoringStrategy : GraphMonitoringStrategy
    {
        public override void Initialize(EntityExtensions extensions)
        {
            if (!RuleDebugger.CheckNoNotifyPropertyChangedWarning(extensions.Target)) return;

            var r = new RecursionObject {Extensions = extensions, Strategy = this};

            // Wire notify property changed
            ((INotifyPropertyChanged)extensions.Target).PropertyChanged += r.OnPropertyChanged;

            // Wire notify collection changed
            foreach (var collection in GetCollections(extensions.Target))
            {
                if (RuleDebugger.CheckNoNotifyCollectionChangedWarning(collection))
                    ((INotifyCollectionChanged)collection).CollectionChanged += r.OnCollectionChanged;
            }

            // Set parent
            foreach (var childObject in GetAllChildObjects(extensions.Target))
                childObject.Parent = extensions;
        }

        internal class RecursionObject
        {
            private readonly Dictionary<string, object> _objects = new Dictionary<string, object>();
            internal EntityExtensions Extensions { get; set; }
            internal HierarchyGraphMonitoringStrategy Strategy { get; set; }

            internal void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                var extensions = Strategy.GetProperty(Extensions.Target, e.PropertyName);

                if (extensions != null)
                {
                    // Set parent to null
                    object oldValue;
                    _objects.TryGetValue(e.PropertyName, out oldValue);
                    if (oldValue != null)
                        ((IEntityExtensions) oldValue).Parent = null;

                    // Set parent to value
                    extensions.Parent = Extensions;
                    _objects[e.PropertyName] = extensions;
                }

                var collection = Strategy.GetCollection(Extensions.Target, e.PropertyName);

                if (RuleDebugger.CheckNoNotifyCollectionChangedWarning(collection))
                {
                    var ncc = (INotifyCollectionChanged) collection;

                    // Unwire collection
                    object oldValue;
                    if (_objects.TryGetValue(e.PropertyName, out oldValue))
                    {
                        var oldncc = (INotifyCollectionChanged) oldValue;
                        oldncc.CollectionChanged -= OnCollectionChanged;

                        // Set old to null
                        foreach (var element in Strategy.GetCollectionElements((IEnumerable)oldncc))
                            element.Parent = null;
                    }

                    // Wire new
                    ncc.CollectionChanged += OnCollectionChanged;

                    // Set child parent to value
                    foreach (var element in Strategy.GetCollectionElements(collection))
                        element.Parent = Extensions;
                }

                //// Todo: Item[]
            }

            internal void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    ((IEntityBase)e.NewItems[0]).Extensions.Parent = Extensions;
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    ((IEntityBase)e.OldItems[0]).Extensions.Parent = null;
                }
                else if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                    ((IEntityBase)e.OldItems[0]).Extensions.Parent = null;
                    ((IEntityBase)e.NewItems[0]).Extensions.Parent = Extensions;
                }
#if NET
                else if (e.Action == NotifyCollectionChangedAction.Move)
                {
                    // Do nothing
                }
#endif
                else if (e.Action == NotifyCollectionChangedAction.Reset)
                {
                    // TODO: Set Parent to null
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}