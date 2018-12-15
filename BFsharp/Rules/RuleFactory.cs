using System;
using System.Linq.Expressions;
using BFsharp.Authoring;
using BFsharp.Formula;
#if PHONE
using ExpressionCompiler;
#endif

namespace BFsharp
{
    public class RuleFactory<T>
    {
        private FormulaCompiler _compiler;
        public FormulaCompiler Compiler
        {
            get
            {
                if (_compiler == null)
                    _compiler = FormulaCompiler.Instance;
                return _compiler;
            }
            set { _compiler = value; }
        }

        public ActionRule<T> CreateActionRule(Expression<Action<T>> action)
        {
            return new ActionRule<T>(action.GetFromCacheOrCompile())
                .AnalyzeDependencies(action)
                .WithDebugString(action);
        }

        public ActionRule<T> CreateActionRuleWithoutDependency(Action<T> action)
        {
            return new ActionRule<T>(action);
        }
        public BusinessRule<T, V> CreateBusinessRuleWithoutDependency<V>(
            Func<T, V> func, Func<T, V> getTarget, Action<T,V> setTarget)
        {
            var rule = new BusinessRule<T, V>(func, getTarget, setTarget);

            return rule;
        }

        public BusinessRule<T, V> CreateBusinessRule<V>(Expression<Func<T, V>> func, Expression<Func<T, V>> target)
        {
            var targetGet = target.GetFromCacheOrCompile();
            var targetSet = DependencyHelper.GetSetFromGet(target);
            var rule = new BusinessRule<T, V>(func.GetFromCacheOrCompile(), targetGet, targetSet);

            rule.AnalyzeDependencies(func);
            rule.AnalyzeDependencies(target, BusinessRule.TargetChangeTag);
            rule.WithDebugString(target.Body + " = " + func.Body);

            return rule;
        }

        public BusinessRule CreateBusinessRule(string formula)
        {
            var index = formula.IndexOf("=");
            var left = formula.Substring(0, index);
            var right = formula.Substring(index + 1);

            var get = Compiler.NewLambda()
                .WithThis<T>()
                .Returns<object>()
                .CompileToExpression(left);

            var func = Compiler.NewLambda()
                .WithThis<T>()
                .Returns<object>()
                .CompileToExpression(right);

            if (func == null)
                throw new FormatException(Compiler.BuildInfo.Message);

            return CreateBusinessRule(func, get);
        }

        public ValidationRule<T> CreateValidationRuleWithoutDependency(
            Func<T, bool> predicate)
        {
            return new ValidationRule<T>(predicate);
        }

        public ValidationRule<T> CreateValidationRule(Expression<Func<T, bool>> predicate)
        {
            var rule = new ValidationRule<T>(predicate.GetFromCacheOrCompile())
                .AnalyzeDependencies(predicate)
                .WithDebugString(predicate);

            if (rule._propertyDependency != null && rule._propertyDependency.Count == 1)
                rule.WithOwner(rule._propertyDependency[0].One);
            return rule;
        }

        public ValidationRule<T> CreateValidationRule(string formula)
        {
            var f = Compiler.NewLambda()
                .WithThis<T>()
                .Returns<bool>()
                .CompileToExpression(formula);

            if (f == null)
                throw new FormatException(Compiler.BuildInfo.Message);

            return CreateValidationRule(f);
        }

        public PredefinedValidationRule<T, TValidation> CreateValidationRule<V, TValidation>(Expression<Func<T, V>> selector, TValidation validation)
            where TValidation : Validation
        {
            var f = selector.GetFromCacheOrCompile();

            var rule = CreateValidationRuleWithoutDependency(f, validation)
                .AnalyzeDependencies(selector)
                .WithOwner(selector);

            return rule;
        }

        public PredefinedValidationRule<T, TValidation> CreateValidationRuleWithoutDependency<V, TValidation>(Func<T, V> selector, TValidation validation)
            where TValidation : Validation
        {
            var rule = new PredefinedValidationRule<T,TValidation>((e,v) => v.Validate(e, selector(e)), validation);

            return rule;
        }

        public SwitchRule<T, S> CreateSwitchableRule<S>(Expression<Func<T, S>> selector)
        {
            return CreateSwitchableRule(selector, true);
        }

        public SwitchRule<T, S> CreateSwitchableRule<S>(Expression<Func<T, S>> selector, bool reevaluate)
        {
            var f = selector.GetFromCacheOrCompile();

            var rule = new SwitchRule<T, S>(f)
                .WithDependencies(selector);

            return rule;
        }
    }
}