using BFsharp;
using BFsharp.Formula;
using Rules.Entities;
using BFsharp.Authoring;

namespace Rules
{
    public static class RuleEx
    {
        public static BusinessRule<T, object> AddRuleWithParam<T>(this T item, string formula)
            where T : EntityBase<T>
        {
            var index = formula.IndexOf("=");
            var left = formula.Substring(0, index);
            var right = formula.Substring(index + 1);
            var compiler = new FormulaCompiler()
                .WithType<T>().WithType<User>();

            var get = compiler.NewLambda()
                .WithThis<T>()
                .Returns<object>()
                .CompileToExpression(left);

            var func = compiler.NewLambda()
                .WithThis<T>()
                .WithParam<User>("User")
                .Returns<object>()
                .CompileToExpression(right);
            var f = func.Compile();
            var r = new RuleFactory<T>();

            var rule = r.CreateBusinessRule(e => f(e, User.Current), get)
                .WithModeAtStartup(BusinessRuleStartupMode.None)
                .AnalyzeDependencies(func);
            item.Extensions.Rules.Add(rule);
            return rule;
        }
    }
}