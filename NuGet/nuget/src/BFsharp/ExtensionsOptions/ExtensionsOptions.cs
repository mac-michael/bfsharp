using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace BFsharp
{
    internal interface IExtensionsOptionsVersion
    {
        bool IsNewest { get; }
    }
    public class ExtensionsOptions<T> : IExtensionOptions, IExtensionsOptionsVersion
    {
        protected ExtensionsOptions()
        {
            Reset();
        }

        #region IExtensionOptions

        public void InitializeRules(IEntityExtensions entityExtensions)
        {
            foreach (var ruleInitializer in RuleInitializers)
                ruleInitializer((T) entityExtensions.Target);

            foreach (var rulePrototype in RulePrototypes)
                entityExtensions.AddRuleFromPrototype(rulePrototype).Start();
        }

        public void DecorateRules(Rule rule)
        {
            foreach (var decorator in Decorators)
                decorator(rule);
        }

        public void InitializeProperties(IEntityExtensions entityExtensions)
        {
            foreach (var propertyInitializer in PropertyInitializers)
                propertyInitializer((T) entityExtensions.Target);
        }

        #endregion

        public GraphMonitoringStrategy GraphMonitoringStrategy { get; set; }

        public List<Action<T>> RuleInitializers { get; private set; }
        public List<Action<Rule>> Decorators { get; private set; }
        public List<Action<T>> PropertyInitializers { get; private set; }
        public List<Rule> RulePrototypes { get; private set; }

        public bool IsNewest { get { return ExtensionsOptions.Version == Version; } }
        public int Version { get; set; }
        static ExtensionsOptions<T> _instance;

        public static ExtensionsOptions<T> Instance
        {
            get
            {
                if (_instance == null || !_instance.IsNewest)
                    _instance = new ExtensionsOptions<T> {Version = ExtensionsOptions.Version};

                return _instance;
            }
        }

        #region Fluent

        public ExtensionsOptions<T> WithRulePrototype()
        {
            new RulePrototypeExtensionPointFactory().GetGextensions<T>().Init(this);
            return this;
        }

        public ExtensionsOptions<T> WithPrototypes(Func<IEnumerable<Rule>> prototypeFactory)
        {
            new GlobalRulePrototypeExtensionPointFactory(prototypeFactory).GetGextensions<T>().Init(this);
            return this;
        }

        public ExtensionsOptions<T> WithPrototypes(IEnumerable<Rule> prototypes)
        {
            new GlobalRulePrototypeExtensionPointFactory(prototypes).GetGextensions<T>().Init(this);
            return this;
        }

        public ExtensionsOptions<T> WithDynamicProperties()
        {
            new DynamicPropertiesExtensionPointFactory().GetGextensions<T>().Init(this);
            return this;
        }

        public ExtensionsOptions<T> Reset()
        {
            RuleInitializers = new List<Action<T>>();
            Decorators = new List<Action<Rule>>();
            PropertyInitializers = new List<Action<T>>();
            RulePrototypes = new List<Rule>();
            GraphMonitoringStrategy = NoGraphMonitoringStrategy.Instance;

            foreach (var extension in ExtensionsOptions.Global.Extensions)
            {
                extension.GetGextensions<T>()
                    .Init(this);
            }
            return this;
        }

        public ExtensionsOptions<T> WithRuleInitializer()
        {
            new RuleInitializerExtensionPointFactory().GetGextensions<T>().Init(this);
            return this;
        }

        public ExtensionsOptions<T> WithAttributeRules()
        {
            new AttributeRulesExtensionPointFactory().GetGextensions<T>().Init(this);
            return this;
        }

        public ExtensionsOptions<T> WithDecorator()
        {
            new RuleDecoratorExtensionPointFactory().GetGextensions<T>().Init(this);
            return this;
        }

        public ExtensionsOptions<T> WithDecorator(Action<Rule> decorator)
        {
            new GlobalRuleDecoratorExtensionPointFactory(decorator).GetGextensions<T>().Init(this);
            return this;
        }

#if SILVERLIGHT
        public ExtensionsOptions<T> WithDataAnnotations()
        {
            new DataAnnotationsExtensionPointFactory().GetGextensions<T>().Init(this);
            return this;
        }
#endif

#if !PHONE
        public ManualIEntityBaseGraphMonitoringStrategy<T> WithManualGraphMonitoringStrategy()
        {
            var strategy = new ManualIEntityBaseGraphMonitoringStrategy<T>();
            GraphMonitoringStrategy = strategy;
            return strategy;
        }
#endif

        public ExtensionsOptions<T> WithBuiltInGraphMonitoringStrategy(PredefinedGraphMonitoringStrategy strategy)
        {
            switch (strategy)
            {
                case PredefinedGraphMonitoringStrategy.No:
                    GraphMonitoringStrategy = NoGraphMonitoringStrategy.Instance;
                    break;
                case PredefinedGraphMonitoringStrategy.IEntityBase:
#if PHONE
                    throw new NotImplementedException("EntityBaseRecursiveStrategy reflection");

#else
                    GraphMonitoringStrategy = new EntityBaseGraphMonitoringStrategy<T>();
#endif
                    break;
                default:
                    throw new ArgumentOutOfRangeException("strategy");
            }
            return this;
        }

        #endregion
    }

    public sealed class ExtensionsOptions
    {
        private ExtensionsOptions()
        {
            Extensions = new ObservableCollection<ExtensionPointFactory>();
            Extensions.CollectionChanged += OnCollectionChanged;

            WithRulePrototype()
                .WithAttributeRules()
                .WithDecorator()
                .WithRuleInitializer()
                .WithDynamicProperties()
                .WithBuiltInRecursiveStrategy(PredefinedGraphMonitoringStrategy.IEntityBase);
        }

        void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Version++;
        }

        public ObservableCollection<ExtensionPointFactory> Extensions { get; private set; }

        public static bool CacheLambdas { get; set; }
        #region Global

        internal static int Version { get; private set; }

        static readonly ExtensionsOptions _global = new ExtensionsOptions();
        public static ExtensionsOptions Global
        {
            get { return _global; }
        }

        #region Factory

        static readonly MethodInfo _method;
        static ExtensionsOptions()
        {
            _method = typeof(ExtensionsOptions).GetMethod("GetExtensionsOptionsInternal", BindingFlags.Static | BindingFlags.NonPublic);
        }
        
// ReSharper disable UnusedMember.Local
        // Used by reflection
        private static IExtensionOptions GetExtensionsOptionsInternal<T>()
// ReSharper restore UnusedMember.Local
        {
            return ExtensionsOptions<T>.Instance;
        }

        private static readonly Dictionary<Type, IExtensionOptions> _cache = new Dictionary<Type, IExtensionOptions>();
        public static IExtensionOptions GetExtensionsOptions(Type type)
        {
            try
            {
                Func<Type, IExtensionOptions> factory = t => (IExtensionOptions) _method.MakeGenericMethod(type).Invoke(null, null);
                var initializer = _cache.GetOrAdd(type, factory);
                if (!((IExtensionsOptionsVersion)initializer).IsNewest)
                {
                    initializer = factory(type);
                    _cache[type] = initializer;
                }

                return initializer;
            }
            catch (MemberAccessException)
            {
                string message = string.Format("Class {0} is not accessible from BusinessFramework assembly. Make it public or use InternalsVisibleToAttribute.",
                                               type.GetType().Name);
                throw new InvalidOperationException(message);
            }
        }

        #endregion


        #endregion
        
        #region Fluent

        public ExtensionsOptions Reset()
        {
            Extensions.Clear();
            return this;
        }

        private ExtensionsOptions WithDynamicProperties()
        {
            Extensions.Add(new DynamicPropertiesExtensionPointFactory());
            return this;
        }

        public ExtensionsOptions WithRuleInitializer()
        {
            Extensions.Add(new RuleInitializerExtensionPointFactory());
            return this;
        }

        public ExtensionsOptions WithAttributeRules()
        {
            Extensions.Add(new AttributeRulesExtensionPointFactory());
            return this;
        }

        public ExtensionsOptions WithDecorator()
        {
            Extensions.Add(new RuleDecoratorExtensionPointFactory());
            return this;
        }

        public ExtensionsOptions WithDecorator(Action<Rule> decorator)
        {
            Extensions.Add(new GlobalRuleDecoratorExtensionPointFactory(decorator));
            return this;   
        }

        public ExtensionsOptions WithRulePrototype()
        {
            Extensions.Add(new RulePrototypeExtensionPointFactory());
            return this;
        }

        public ExtensionsOptions WithPrototypes(Func<IEnumerable<Rule>> prototypeFactory)
        {
            Extensions.Add(new GlobalRulePrototypeExtensionPointFactory(prototypeFactory));
            return this;
        }

        public ExtensionsOptions WithPrototypes(IEnumerable<Rule> prototypes)
        {
            Extensions.Add(new GlobalRulePrototypeExtensionPointFactory(prototypes));
            return this;
        }

        public ExtensionsOptions WithBuiltInRecursiveStrategy(PredefinedGraphMonitoringStrategy strategy)
        {
            switch (strategy)
            {
                case PredefinedGraphMonitoringStrategy.No:
                    Extensions.Add(new NoGraphMonitoringExtensionPointFactory());
                    break;
                case PredefinedGraphMonitoringStrategy.IEntityBase:
                    Extensions.Add(new EntityBaseGraphMonitoringExtensionPointFactory());
                    break;
                default:
                    throw new ArgumentOutOfRangeException("strategy");
            }
            return this;
        }

        public ExtensionsOptions WithAspNetValidationBehaviour()
        {
            Extensions.Add( new GlobalRuleDecoratorExtensionPointFactory(AspNetValidationBehaviour));

            return this;
        }

        private static void AspNetValidationBehaviour(Rule rule)
        {
            if (rule is ValidationRule)
                ((ValidationRule) rule).WithModeAtStartup(ValidationRuleStartupMode.None);
        }

        #endregion
    }
}
