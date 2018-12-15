using System.Linq.Expressions;

namespace BFsharp.Authoring
{
    public static class RuleAuthoringExtensions
    {
        public static T AnalyzeDependencies<T>(this T rule, Expression expression)
            where T : Rule
        {
            return AnalyzeDependencies(rule, expression, "");
        }

        public static T AnalyzeDependencies<T>(this T rule, Expression expression, string tag)
            where T : Rule
        {
            var visitor = new DependecyExpressionVisitor();
            visitor.Analyze(expression);
            foreach (var propertyPath in visitor.Members)
                rule.AddPropertyDependency(propertyPath, tag);

            return rule;
        }

        public static T WithDebugString<T>(this T rule, string debugString)
            where T : Rule
        {
            rule.DebugString = debugString;
            return rule;
        }

        public static T WithDebugString<T>(this T rule, LambdaExpression expression)
            where T : Rule
        {
            rule.DebugString = expression.Body.ToString();
            return rule;
        }
    }
}