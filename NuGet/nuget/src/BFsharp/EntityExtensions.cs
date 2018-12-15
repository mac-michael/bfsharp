using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using BFsharp.DynamicProperties;
using BFsharp.Formula;

namespace BFsharp
{
    public class EntityExtensions : IEntityExtensions, INotifyPropertyChanged
    {
        protected EntityExtensions(object parent)
        {
            Target = parent;
            Initializer.GraphMonitoringStrategy.Initialize(this);
        }
        
        public object Target { get; private set; }
        
        private IEntityExtensions _parent;
        public IEntityExtensions Parent
        {
            get { return _parent; }
            set
            {
                RuleDebugger.CheckParentChanged(Target, _parent, value);

                if (_parent != null && value == null)
                {
                    var entityExtensions = ((EntityExtensions) _parent);
                    entityExtensions.RaisePropertyChange("IsValid", true);
                    if (IsDirtyTrackingStarted)
                        entityExtensions.IsDirty = true;
                }
                
                _parent = value;
                if (_parent == null)
                    return;

                // Access exactly the base class
                if (_parent is IGetInternalEntityExtensions)
                    _parent = ((IGetInternalEntityExtensions) _parent).GetExtensions();
                
                if (_parent.RuleInitialized && !RuleInitialized)
                    InitializeRules();

                if (_parent.IsDirtyTrackingStarted)
                {
                    StartDirtyTracking();
                    IsDirty = true;
                }
                if ( !IsValid && Parent.IsValid)
                    RaisePropertyChange("IsValid", true);

            }
        }
        
#if !PHONE
        public ICallProvider CompilerCallProvider { get; set; }
#endif
        #region Rules

        private RuleCollection _rules; 
        public RuleCollection Rules
        {
            get
            {
                if (_rules == null)
                    _rules = new RuleCollection(this, Initializer.DecorateRules);
                return _rules;
            }
        }

        private BrokenRuleCollection _brokenRules;
        public BrokenRuleCollection BrokenRules
        {
            get
            {
                if (_brokenRules == null)
                {
                    _brokenRules = new BrokenRuleCollection();

                    _brokenRules.RuleBroken += OnRuleBroken;
                    _brokenRules.RuleRepaired += OnRuleRepaired;
                }
                return _brokenRules;
            }
        }

        void OnRuleBroken(object sender, BrokenRuleEventArgs e)
        {
            if (BrokenRules.Where(b => b.Severity == BrokenRuleSeverity.Error).Count() == 1)
                RaisePropertyChange("IsValid",true);
        }

        void OnRuleRepaired(object sender, BrokenRuleEventArgs e)
        {
            if (BrokenRules.Where(b=>b.Severity == BrokenRuleSeverity.Error).Count() == 0)
                RaisePropertyChange("IsValid", true);
        }

        private DependencyNode _dependency;
        private DependencyNode Dependency
        {
            get
            {
                if (_dependency == null)
                {
                    _dependency = new DependencyNode();
                    _dependency.Subscribe(Target);
                }
                return _dependency;
            }
        }

        

        internal void OnRuleAdded(Rule rule)
        {
            rule.OnRuleAdded(this);
        }

        internal void OnRuleRemoved(Rule rule)
        {
            Dependency.RemoveDependency(rule.OnInternalDependencyChanged);
            rule.OnRuleRemoved();
        }

        internal void AddPropertyDependency(Rule rule, PropertyPath propertyPath, string tag)
        {
            var actionWithTag = new DependencyNode.ActionWithTag(rule.OnInternalDependencyChanged, tag);
            actionWithTag.Priority = () => rule.Priority;

            Dependency.AddPropertyDependency(propertyPath, actionWithTag);
        }

        private IExtensionOptions _initializer;

        protected internal IExtensionOptions Initializer
        {
            get
            {
                if (_initializer == null)
                    _initializer = ExtensionsOptions.GetExtensionsOptions(Target.GetType());

                return _initializer;
            }
            private set
            {
                _initializer = value;
            }
        }

        private bool _ruleInitialized;
        public bool RuleInitialized
        {
            get { return _ruleInitialized; }
            private set
            {
                if (_ruleInitialized == value)
                    return;

                _ruleInitialized = value;
                RaisePropertyChange("RuleInitialized", true);
            }
        }

        public void InitializeRules()
        {
            SafeRecursiveAction(e =>
                                    {
                                        if (e.RuleInitialized) return;

                                        e.Initializer.InitializeRules(e);
                                        e.RuleInitialized = true;
                                    });
        }


        protected void SafeRecursiveAction( Action<EntityExtensions> action, Dictionary<object, object> visited)
        {
            if (visited.ContainsKey(this))
                return;
            visited.Add(this, null);

            action(this);

            foreach (var childEntityExtension in Initializer.GraphMonitoringStrategy.GetAllChildObjects(Target))
            {
                var entityExtension = (EntityExtensions)childEntityExtension;
                action(entityExtension);
                entityExtension.SafeRecursiveAction(action, visited);
            }
        }

        internal void SafeRecursiveAction( Action<EntityExtensions> action )
        {
            var visited = new Dictionary<object, object>(ObjectReferenceEqualityComparerer<object>.Default);
            SafeRecursiveAction(action, visited);
        }

        public bool IsValid
        {
            get
            {
                bool isValid = true;
                SafeRecursiveAction(e =>
                                        {
                                            isValid &= e.BrokenRules.Where(r => r.Severity == BrokenRuleSeverity.Error).
                                                           FirstOrDefault() == null;

                                        });

                return isValid;
            }
        }

        public bool Validate()
        {
            return Validate(ValidationMode.OnlyErrors);
        }

        public bool Validate(ValidationMode mode)
        {
            bool valid = true;

            SafeRecursiveAction(e =>
                                    {
                                        // Remove OneTime BrokenRules
                                        for (int i = 0; i < e.BrokenRules.Count; i++)
                                        {
                                            if (e.BrokenRules[i].Mode == BrokenRuleRevocationStrategy.Validate)
                                            {
                                                e.BrokenRules.RemoveAt(i);
                                                i--;
                                            }
                                        }

                                        // Validate ValidationRules with Error severity
                        foreach (var rule in e.Rules.OfType<ValidationRuleBase>().Where(r => r.State == RuleState.Enabled))
                        {
                            if (mode == ValidationMode.OnlyErrors && rule.Severity != BrokenRuleSeverity.Error)
                                continue;

                            bool res = rule.Validate();
                            if (rule.Severity == BrokenRuleSeverity.Error)
                                valid &= res;
                        }
                    });

            return valid;
        }

        #endregion

        #region IsDirty

        public void StartDirtyTracking()
        {
            SafeRecursiveAction(
                ex =>
                    {
                        var actionWithTag = new DependencyNode.ActionWithTag(s => ex.IsDirty = true, "");
                        ex.Dependency.AddPropertyDependency("*", actionWithTag);
                        ex.IsDirtyTrackingStarted = true;
                    }
                );
        }

        public void ClearIsDirty()
        {
            SafeRecursiveAction(ex => { ex.IsDirty = false; });
        }

        public bool IsDirtyTrackingStarted { get; private set; }

        private bool _isDirty;

        public bool IsDirty
        {
            get
            {
                bool isDirty = false;
                SafeRecursiveAction(ex => { isDirty |= ex._isDirty; });

                return isDirty;
            }
            set
            {
                if (_isDirty == value)
                    return;

                _isDirty = value;
                RaisePropertyChange("IsDirty", true);
            }
        }

        #endregion

        #region ExtendedProperties

        private DynamicPropertyCollection _dynamicProperties;

        public DynamicPropertyCollection DynamicProperties
        {
            get
            {
                if (_dynamicProperties == null)
                {
                    _dynamicProperties = new DynamicPropertyCollection();
                    Initializer.InitializeProperties(this);
                }
                return _dynamicProperties;
            }
        }

        #endregion

        #region RegisterObject

        public static IEntityExtensions RegisterObject(object target)
        {
            return RegisterObject(target, null);
        }

        public static IEntityExtensions RegisterObject(object target, IExtensionOptions initializer)
        {
            if (target == null) throw new ArgumentNullException("target");

            var entityExtensions = new EntityExtensions(target);
            entityExtensions.Initializer = initializer;

            return entityExtensions;
        }

        public static IEntityExtensions<T> RegisterTypedObject<T>(T target)
        {
            return RegisterObject(target, null).GetTypeSafe<T>();
        }

        public static IEntityExtensions<T> RegisterTypedObject<T>(T target, IExtensionOptions initializer)
        {
            return RegisterObject(target, initializer).GetTypeSafe<T>();
        }

        #endregion

        #region NotifyPropertyChanged

        public void RaisePropertyChange(string propertyName)
        {
            RaisePropertyChange(propertyName, false);
        }

        public void RaisePropertyChange(string propertyName, bool notifyParent)
        {
            var h = PropertyChanged;
            if (h != null)
                h(this, new PropertyChangedEventArgs(propertyName));

            if (notifyParent && Parent != null)
                ((EntityExtensions) Parent).RaisePropertyChange(propertyName, true);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public override string ToString()
        {
            return "Target=" + Target + ", IsValid=" + IsValid +
                   ", IsDirty=" + (IsDirtyTrackingStarted ? IsDirty.ToString() : "not started");
        }
    }

    internal interface IGetInternalEntityExtensions
    {
        IEntityExtensions GetExtensions();
    }

    public class EntityExtensions<T> : IEntityExtensions<T>, INotifyPropertyChanged, IGetInternalEntityExtensions
    {
        private readonly IEntityExtensions _extensions;

        public static implicit operator EntityExtensions<T>(EntityExtensions e)
        {
            return (EntityExtensions<T>) e.GetTypeSafe<T>();
        }

        internal EntityExtensions(IEntityExtensions extensions)
        {
            ((EntityExtensions) extensions).PropertyChanged += ExtensionsPropertyChanged;
            _extensions = extensions;
        }

        public RuleCollection Rules
        {
            get { return _extensions.Rules; }
        }

        public BrokenRuleCollection BrokenRules
        {
            get { return _extensions.BrokenRules; }
        }

        public bool IsValid
        {
            get { return _extensions.IsValid; }
        }

        public DynamicPropertyCollection DynamicProperties
        {
            get { return _extensions.DynamicProperties; }
        }

        public void StartDirtyTracking()
        {
            _extensions.StartDirtyTracking();
        }

        public bool IsDirty
        {
            get { return _extensions.IsDirty; }
            set { _extensions.IsDirty = value; }
        }

        public bool IsDirtyTrackingStarted
        {
            get { return _extensions.IsDirtyTrackingStarted; }
        }

        public void ClearIsDirty()
        {
            _extensions.ClearIsDirty();
        }

        public bool Validate()
        {
            return _extensions.Validate();
        }

        public bool Validate(ValidationMode mode)
        {
            return _extensions.Validate(mode);
        }

        public bool RuleInitialized
        {
            get { return _extensions.RuleInitialized; }
        }

        public void InitializeRules()
        {
            _extensions.InitializeRules();
        }

#if !PHONE
        public ICallProvider CompilerCallProvider
        {
            get { return _extensions.CompilerCallProvider; }
            set { _extensions.CompilerCallProvider = value; }
        }
#endif

        public object Target
        {
            get { return _extensions.Target; }
        }

        public IEntityExtensions Parent
        {
            get { return _extensions.Parent; }
            set { _extensions.Parent = value; }
        }

        public IEntityExtensions GetExtensions()
        {
            return _extensions;
        }

        private void ExtensionsPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var p = PropertyChanged;
            if (p != null)
                p(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
