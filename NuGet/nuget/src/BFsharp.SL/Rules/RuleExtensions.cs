using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BFsharp.DynamicProperties;
using BFsharp.Formula;

namespace BFsharp
{
#if NET || SILVERLIGHT
    public static class SampleRuleExtensions
    {
        public static ValidationRule<T> CreateConfirmPasswordRule<T>(this IEntityExtensions<T> extension, Expression<Func<T, string>> passwordSelector,
            Expression<Func<T,string>> confirmPasswordSelector )
        {
            var password = passwordSelector.Compile();
            var confirm = confirmPasswordSelector.Compile();
            var rule = extension.CreateValidationRule(p => password(p) == confirm(p) || string.IsNullOrEmpty(confirm(p)))
                .WithOwner(confirmPasswordSelector);

            return rule;
        }
    }
#endif
    public static class RuleExtensions
    {
        #region Basic

        public static T WithName<T>(this T rule, string name) where T : Rule
        {
            rule.Name = name;
            return rule;
        }

        public static T Start<T>(this T rule)
            where T : Rule
        {
            rule.Enable();
            return rule;
        }

        #endregion

        #region Priority
        public static T WithPriority<T>(this T rule, int priority)
            where T : Rule
        {
            rule.Priority = priority;
            return rule;
        }

        public static T WithPriority<T>(this T rule, RulePriority priority)
            where T: Rule
        {
            return rule.WithPriority((int) priority);
        }

        public static T WithHighPriority<T>(this T rule)
            where T: Rule
        {
            return rule.WithPriority(RulePriority.High);
        }

        public static T WithLowPriority<T>(this T rule)
            where T : Rule
        {
            return rule.WithPriority(RulePriority.Low);
        }

        #endregion

        #region BrokenRule

        public static T WithMessage<T>(this T rule, string message) where T : ValidationRuleBase
        {
            rule.Message = message;
            return rule;
        }

        public static T WithLocalizableMessage<T>(this T rule, Func<T,string> messageFunc) where T : ValidationRuleBase
        {
            rule.LocalizableMessageFunc = r => messageFunc((T) r);
            return rule;
        }

        public static T WithSeverity<T>(this T rule, BrokenRuleSeverity severity)
            where T : ValidationRuleBase
        {
            rule.Severity = severity;
            return rule;
        }

        public static TRule WithOwner<TRule, TOwner>(this IRuleOwner<TRule, TOwner> rule,
                                                     Expression<Func<TOwner, object>> propertySelector)
            where TRule : ValidationRuleBase
        {
            var r = (TRule) rule;

            var path = DependencyHelper.GetPropertyPath(propertySelector).ToArray();
            var propertyPath = string.Join(".", path);

            r.Owner = propertyPath;

            return r;
        }

        public static TRule WithOwner<TRule, TOwner, TValue>(this IRuleOwner<TRule, TOwner> rule,
                                                             Expression<Func<TOwner, TValue>> propertySelector)
            where TRule : ValidationRuleBase
        {
            var r = (TRule)rule;

            var path = DependencyHelper.GetPropertyPath(propertySelector).ToArray();
            var propertyPath = string.Join(".", path);

            r.Owner = propertyPath;

            return r;
        }

        public static T WithOwner<T>(this T rule, string propertyPath)
            where T : ValidationRuleBase
        {
            rule.Owner = propertyPath;
            return rule;
        }

        #endregion
        #region Mode

        public static T WithValidation<T>(this T rule) where T : BusinessRule
        {
            rule.Mode = BusinessRuleMode.Validate;
            return rule;
        }

        public static T WithMode<T>(this T rule, BusinessRuleMode mode) where T : BusinessRule
        {
            rule.Mode = mode;
            return rule;
        }

        public static T WithOverride<T>(this T rule)
            where T : BusinessRule
        {
            rule.TargetChangeAction = BusinessRuleTargetChangeAction.Override;
            return rule;
        }

        public static T WithDisableValidation<T>(this T rule)
            where T : BusinessRule
        {
            rule.DisableValidation = true;
            return rule;
        }

        public static T WithTargetChangeAction<T>(this T rule, BusinessRuleTargetChangeAction action)
            where T : BusinessRule
        {
            rule.TargetChangeAction = action;
            return rule;
        }

        public static T WithEvaluationAtStartup<T>(this T rule) 
            where T : BusinessRule
        {
            rule.StartupMode = BusinessRuleStartupMode.Evaluate;
            return rule;
        }

        public static T WithModeAtStartup<T>(this T rule, BusinessRuleStartupMode startupMode)
            where T : BusinessRule
        {
            rule.StartupMode = startupMode;
            return rule;
        }

        public static T WithModeAtStartup<T>(this T rule, ActionRuleStartupMode startupMode)
            where T : ActionRule
        {
            rule.StartupMode = startupMode;
            return rule;
        }

        public static T WithInvokeAtStartup<T>(this T rule)
            where T : ActionRule
        {
            rule.WithModeAtStartup(ActionRuleStartupMode.Invoke);
            return rule;
        }

        public static T WithModeAtStartup<T>(this T rule, ValidationRuleStartupMode startupMode)
            where T : ValidationRule
        {
            rule.StartupMode = startupMode;
            return rule;
        }

        #endregion
        #region Exception

        public static ActionRule WithException<TException>(this ActionRule rule, string message,
                                                           BrokenRuleSeverity severity)
            where TException : Exception
        {
            return WithException<ActionRule, TException>(rule, message, severity);
        }

        public static Rule WithException<TException>(this Rule rule, string message,
                                                     BrokenRuleSeverity severity)
            where TException : Exception
        {
            return WithException<Rule, TException>(rule, message, severity);
        }

        public static Rule WithException<TException>(this Rule rule, string message,
                                                     BrokenRuleSeverity severity, string owner)
            where TException : Exception
        {
            return WithException<Rule, TException>(rule, message, severity, owner);
        }

        public static BusinessRule WithException<TException>(this BusinessRule rule, string message,
                                                             BrokenRuleSeverity severity)
            where TException : Exception
        {
            return WithException<BusinessRule, TException>(rule, message, severity);
        }

        public static ValidationRuleBase WithException<TException>(this ValidationRuleBase rule, string message,
                                                                   BrokenRuleSeverity severity)
            where TException : Exception
        {
            return WithException<ValidationRuleBase, TException>(rule, message, severity);
        }

        public static T WithException<T, TException>(this T rule, string message,
                                                     BrokenRuleSeverity severity)
            where T : Rule
            where TException : Exception
        {
            return WithException<T, TException>(rule, message, severity, null);
        }

        public static T WithException<T, TException>(this T rule, string message,
                                                     BrokenRuleSeverity severity, string owner)
            where T : Rule
            where TException : Exception
        {
            rule.ExceptionActions.Add(new RuleExceptionFilter
                                          {
                                              ExceptionType = typeof(TException),
                                              Message = message,
                                              Severity = severity,
                                              Owner = owner
                                          });
            return rule;
        }

        public static T WithNonRecoverableExceptionFilter<T>(this T rule)
            where T : Rule
        {
            rule.ExceptionActions.Add(new NonRecoverableRuleExceptionFilter());

            return rule;
        }
        
        #endregion
        #region Dependency

        public static T WithDependencies<T>(this T rule, params string[] dependencyPath)
            where T : Rule
        {
            foreach (var path in dependencyPath)
                rule.AddPropertyDependency(path.Split('.').ToList());

            return rule;
        }

        public static T ResetDependecies<T>(this T rule )
            where T : Rule
        {
            throw new NotImplementedException();
            //return rule;
        }


        public static TRule WithDependencies<TRule, TOwner, TType>(this IRuleOwner<TRule, TOwner> rule,
                                                            params Expression<Func<TOwner, TType>>[] propertySelectors)
            where TRule : Rule
        {
            var r = (TRule) rule;

            foreach (var selector in propertySelectors)
            {
                var propertyPath = DependencyHelper.GetPropertyPath(selector);

                r.AddPropertyDependency(propertyPath.ToList());
            }

            return r;
        }

        public static TRule WithCollectionDependencies<TRule, TOwner, TItem>(
            this IRuleOwner<TRule, TOwner> rule,
            Expression<Func<TOwner, IEnumerable<TItem>>> collectionSelector,
            params Expression<Func<TItem, object>>[] propertySelectors)
            where TRule : Rule
        {
            var r = (TRule)rule;
            var enumerable = DependencyHelper.GetPropertyPath(collectionSelector);
            var p = new PropertyPath(enumerable);
            foreach (var selector in propertySelectors)
            {
                var propertyPath = new PropertyPath( DependencyHelper.GetPropertyPath(selector) );
                r.AddPropertyDependency( p + "$" + propertyPath);
            }

            return r;
        }
        
        #endregion
        #region Suppression

        public static T Suppresses<T>(this T rule, Rule rule2)
            where T : Rule
        {
            if (string.IsNullOrEmpty(rule.Name))
            {
                rule.Name = "tempName_" + Guid.NewGuid();
                RuleDebugger.Warning("Rule was given a temporary name for the sake of suppression.");
            }

            rule2.SuppressedRules.Add(rule.Name);
            return rule;
        }

        public static T MutuallySuppressedBy<T>(this T rule, Rule rule2)
            where T : Rule
        {
            rule.Suppresses(rule2);
            rule2.Suppresses(rule);

            return rule;
        }

        public static T DisableRecursion<T>(this T rule)
            where T: Rule
        {
            rule.Suppresses(rule);
            return rule;
        }

        //public static T SuppressNextNInvocation<T>(this T rule, int n)
        //    where T : Rule
        //{
        //    return rule;
        //}

        #endregion
 
        public static T AddBrokenRule<T>(this T extension, BrokenRule brokenRule)
            where T : IEntityExtensions
        {
            extension.BrokenRules.Add(brokenRule);
            return extension;
        }

        #region AddRules

        public static T AddRule<T>(this IEntityExtensions extension, T rule)
            where T : Rule
        {
            extension.Rules.Add(rule);
            return rule;
        }

        public static T AddRuleFromPrototype<T>(this IEntityExtensions extension, T rule)
            where T : Rule
        {
            var copy = (T)rule.Copy();
            extension.Rules.Add(copy);
            return copy;
        }
        #endregion
        #region AddRules non-generic
        public static BusinessRule<T,V> CreateBusinessRuleWithoutDependency<T,V>(this IEntityExtensions<T> extensions,
                                                                                 Func<T,V> func, Func<T,V> getTarget, Action<T,V> setTarget )
        {
            var factory = new RuleFactory<T>();
            var rule = factory.CreateBusinessRuleWithoutDependency(func, getTarget,setTarget);

            extensions.Rules.Add(rule);
            return rule;
        }

        public static BusinessRule<object, object> CreateBusinessRule(this IEntityExtensions extension,
                                                                   Expression<Func<object, object>> func, Expression<Func<object, object>> target)
        {
            var factory = new RuleFactory<object>();
            var rule = factory.CreateBusinessRule(func, target);

            extension.Rules.Add(rule);
            return rule;
        }

        public static ValidationRule CreateValidationRuleWithoutDependency(this IEntityExtensions extension,
                                                                   Func<object, bool> predicate)
        {
            var factory = new RuleFactory<object>();
            var rule = factory.CreateValidationRuleWithoutDependency(predicate);

            extension.Rules.Add(rule);
            return rule;
        }

        public static ValidationRule CreateValidationRule(this IEntityExtensions extension, Expression<Func<object, bool>> predicate)
        {
            var factory = new RuleFactory<object>();
            var rule = factory.CreateValidationRule(predicate);
            
            extension.Rules.Add(rule);
            return rule;
        }

        public static PredefinedValidationRule<object, Validation> CreateValidationRuleWithoutDependency<V>(this IEntityExtensions extension,
                                                                  Func<object, V> selector, Validation validation)
        {
            var factory = new RuleFactory<object>();
            var rule = factory.CreateValidationRuleWithoutDependency(selector, validation);

            extension.Rules.Add(rule);
            return rule;
        }

        public static PredefinedValidationRule<object, Validation> CreateValidationRule<V>(this IEntityExtensions extension,
                                                                  Expression<Func<object, V>> selector,Validation validation)
        {
            var factory = new RuleFactory<object>();
            var rule = factory.CreateValidationRule(selector, validation);

            extension.Rules.Add(rule);
            return rule;
        }

        public static ActionRule<object> CreateActionRule(this IEntityExtensions extension, 
                                                       Expression<Action<object>> action)
        {
            var factory = new RuleFactory<object>();
            var rule = factory.CreateActionRule(action);

            extension.Rules.Add(rule);
            return rule;
        }

        public static ActionRule<object> CreateActionRuleWithoutDependency(this IEntityExtensions extension,
                                                      Action<object> action)
        {
            var factory = new RuleFactory<object>();
            var rule = factory.CreateActionRuleWithoutDependency(action);

            extension.Rules.Add(rule);
            return rule;
        }

        public static SwitchRule<T, object> CreateSwitchableRule<T>(this IEntityExtensions<T> extensions, Expression<Func<T, object>> selector)
        {
            return CreateSwitchableRule(extensions, selector, true);
        }

        public static SwitchRule<T, object> CreateSwitchableRule<T>(this IEntityExtensions<T> extensions,
            Expression<Func<T, object>> selector, bool reevaluate)
        {
            var factory = new RuleFactory<T>();
            var rule = factory.CreateSwitchableRule(selector, reevaluate);

            extensions.Rules.Add(rule);
            return rule;
        }
        #endregion
        #region AddRules generic

        public static ActionRule<T> CreateActionRule<T>(this IEntityExtensions<T> extension, Expression<Action<T>> action)
        {
            var factory = new RuleFactory<T>();
            var rule = factory.CreateActionRule(action);

            extension.Rules.Add(rule);
            return rule;
        }
      
        public static ActionRule<T> CreateActionRuleWithoutDependency<T>(this IEntityExtensions<T> extension, Action<T> action)
        {
            var factory = new RuleFactory<T>();
            var rule = factory.CreateActionRuleWithoutDependency(action);

            extension.Rules.Add(rule);
            return rule;
        }
      
        public static BusinessRule<T, V> CreateBusinessRule<T, V>(this IEntityExtensions<T> extension, Expression<Func<T, V>> func, Expression<Func<T, V>> target)
        {
            var factory = new RuleFactory<T>();
            var rule = factory.CreateBusinessRule(func, target);

            extension.Rules.Add(rule); 
            return rule;
        }

        private static FormulaCompiler CreateCompiler(IEntityExtensions extensions)
        {
            Type thisType = extensions.Target.GetType();

            var compiler = new FormulaCompiler();
            compiler.With(new TypeCallProvider(thisType));

            compiler.WithDynamicEntity(thisType, extensions.DynamicProperties.AllowDynamicProperties,
                extensions.DynamicProperties.PropertiesMetadata);

            return compiler;
        }

        public static BusinessRule CreateBusinessRule<T>(this IEntityExtensions<T> extension, string formula)
        {
            var factory = new RuleFactory<T>();
            factory.Compiler = CreateCompiler(extension);

            var rule = factory.CreateBusinessRule(formula);
            
            extension.Rules.Add(rule); 
            return rule;
        }

        public static ValidationRule<T> CreateValidationRule<T>(this IEntityExtensions<T> extension, Expression<Func<T, bool>> predicate)
        {
            var factory = new RuleFactory<T>();
            var rule = factory.CreateValidationRule(predicate);
            
            extension.Rules.Add(rule);
            return rule;
        }

        public static PredefinedValidationRule<T, TValidation> CreateValidationRule<T,V, TValidation>(this IEntityExtensions<T> extension, Expression<Func<T, V>> selector, TValidation validation)
            where TValidation : Validation
        {
            var factory = new RuleFactory<T>();
            var rule = factory.CreateValidationRule(selector, validation);

            extension.Rules.Add(rule);
            return rule;
        }

        public static ValidationRule<T> CreateValidationRule<T>(this IEntityExtensions<T> extension, string formula)
        {
            var factory = new RuleFactory<T>();
            factory.Compiler = CreateCompiler(extension);

            var rule = factory.CreateValidationRule(formula);

            extension.Rules.Add(rule); 
            return rule;
        }

        public static ValidationRule<T> CreateValidationRuleWithoutDependency<T>(this IEntityExtensions<T> extension, Func<T, bool> predicate)
        {
            var factory = new RuleFactory<T>();
            var rule = factory.CreateValidationRuleWithoutDependency(predicate);

            extension.Rules.Add(rule);
            return rule;
        }

        #endregion

        

        #region Rule Misc

        public static T WithOneTime<T>(this T rule)
            where T : Rule
        {
            rule.IsOneTime = true;
            return rule;
        }

        public static T WithBreakpoint<T>(this T rule)
            where T : Rule
        {
            rule.BreakpointEnabled = true;
            return rule;
        }

        public static IEntityExtensions<T> GetTypeSafe<T>(this IEntityExtensions extensions)
        {
            if (!(extensions.Target is T))
                throw new InvalidOperationException(string.Format("Type {0} cannot be casted to {1}.", extensions.Target.GetType(), typeof(T)));

            if (extensions is IGetInternalEntityExtensions)
                extensions = ((IGetInternalEntityExtensions) extensions).GetExtensions();

            return new EntityExtensions<T>(extensions);
        }

        #endregion

        #region Switch
        public static T WithSwitch<T>(this T rule, object @switch)
           where T : Rule
        {
            rule.Switch = @switch;
            return rule;
        }

        public static SwitchRule<T, S> CreateSwitchableRule<T, S>(this IEntityExtensions<T> extensions, Expression<Func<T, S>> selector)
        {
            return CreateSwitchableRule(extensions, selector, true);
        }

        public static SwitchRule<T, S> CreateSwitchableRule<T, S>(this IEntityExtensions<T> extensions,
            Expression<Func<T, S>> selector, bool reevaluate)
        {
            var factory = new RuleFactory<T>();
            var rule = factory.CreateSwitchableRule(selector, reevaluate);

            extensions.Rules.Add(rule);
            return rule;
        }
        #endregion

        #region Tag
       
        public static void EnableByTag(this IEntityExtensions extensions, object tag)
        {
            EnableByTag(extensions, tag, true);
        }

        public static void EnableByTag(this IEntityExtensions extensions, object tag, bool enable)
        {
            foreach (var rule in extensions.Rules.Where(r => r.Tag != null && r.Tag.Equals(tag)))
            {
                if (enable)
                    rule.Enable();
                else
                    rule.Disable();
            }
        }
        
        public static void SwitchRulesByTag(this IEntityExtensions extensions, object tag)
        {
            extensions.GetImplementation().SafeRecursiveAction(e =>
                {
                    foreach (var rule in e.Rules.Where(r => r.Tag != null && r.Tag.GetType() == tag.GetType()))
                    {
                        if (rule.Tag.Equals(tag) && rule.State == RuleState.Disabled)
                            rule.Enable();
                        else if (!rule.Tag.Equals(tag) && rule.State == RuleState.Enabled)
                            rule.Disable();
                    }
                });
        }

        public static void ReevaluateRulesByTag(this IEntityExtensions extensions, object tag)
        {
            extensions.GetImplementation().SafeRecursiveAction(e =>
                {
                    foreach (var rule in e.Rules.Where(r => r.Tag != null && r.Tag.Equals(tag)))
                    {
                        if (rule is ActionRule)
                            ((ActionRule)rule).Invoke();
                        else if (rule is BusinessRule)
                            ((BusinessRule)rule).Evaluate();
                    }
                });
        }

        #endregion

        #region Client/Server side
        public static T WithClientSide<T>(this T rule, Action<T> action)
           where T : Rule
        {
            rule.StartupActions.Add(r =>
            {
                if (RuleContext.State == RuleContextState.Client)
                    action((T)r);
            });
            return rule;
        }

        public static T WithServerSide<T>(this T rule, Action<T> action)
            where T : Rule
        {
            rule.StartupActions.Add(r =>
            {
                if (RuleContext.State == RuleContextState.Server)
                    action((T)r);
            });
            return rule;
        }

        public static T ValidateOnlyOnServerSide<T>(this T rule)
            where T : BusinessRule
        {
            rule.WithServerSide(r =>
            {
                if (r.Mode == BusinessRuleMode.Evaluate)
                    r.Mode = BusinessRuleMode.Validate;

                if (r.StartupMode == BusinessRuleStartupMode.Evaluate)
                    r.StartupMode = BusinessRuleStartupMode.Validate;

                if (r.TargetChangeAction == BusinessRuleTargetChangeAction.Override)
                    r.TargetChangeAction = BusinessRuleTargetChangeAction.Validate;
            });

            return rule;
        }
        #endregion

        #region DynamicProperties

        public static T AllowDynamicProperties<T>(this T extension) 
            where T : IEntityExtensions
        {
            extension.DynamicProperties.AllowDynamicProperties = true;
            return extension;
        }

        public static IEntityExtensions AddProperty<TValue>(this IEntityExtensions extension, string name )
        {
            return AddProperty(extension, name, typeof(TValue), DynamicPropertyMetadataOptions.Save);
        }

        public static IEntityExtensions AddProperty<TValue>(this IEntityExtensions extension, string name, DynamicPropertyMetadataOptions options)
        {
            return AddProperty(extension, name, typeof(TValue), options);
        }

        public static T AddProperty<T> (this T extension, string name, Type type)
            where T : IEntityExtensions

        {
            return AddProperty<T>(extension, name, type, DynamicPropertyMetadataOptions.Save);
        }

        public static T AddProperty<T> (this T extension, string name, Type type, DynamicPropertyMetadataOptions options)
            where T : IEntityExtensions

        {
            extension.DynamicProperties.PropertiesMetadata.Add(new DynamicPropertyMetadata(name, type)
                                                                   {Options = options});
            return extension;
        }

        #endregion

        #region EntityPrototype
        public static void ApplyPrototype(this IEntityExtensions extensions,
                                          IEntityExtensions prototype)
        {
            foreach (var rule in prototype.Rules)
                extensions.AddRuleFromPrototype(rule);

            extensions.DynamicProperties.AllowDynamicProperties = prototype.DynamicProperties.AllowDynamicProperties;
            foreach (var p in prototype.DynamicProperties.PropertiesMetadata
                .Where(x=>!x.SaveTypeInfo))
            {
                extensions.DynamicProperties.PropertiesMetadata.Add(new DynamicPropertyMetadata(p.Name,p.Type));
            }

            if ( prototype.IsDirtyTrackingStarted)
                extensions.StartDirtyTracking();

            if (prototype.RuleInitialized)
                extensions.InitializeRules();
        }
        #endregion
    }
}
