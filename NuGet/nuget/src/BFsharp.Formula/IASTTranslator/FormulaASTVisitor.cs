using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using Antlr.Runtime.Tree;
using System.Diagnostics;
using System.Collections.Generic;

namespace BFsharp.Formula
{
    public class FormulaASTVisitor : AbstractASTVisitor
    {
        static readonly Dictionary<string,Type> _aliases 
            = new Dictionary<string, Type>();

        static FormulaASTVisitor()
        {
            _aliases.Add("int", typeof(int));
            _aliases.Add("long", typeof(long));
            _aliases.Add("string", typeof(string));
            _aliases.Add("bool", typeof(bool));
            _aliases.Add("char", typeof(char));
        }

        protected override Expression<T> TranslateInternal<T>(CommonTree lambdaTree)
        {
            var bodyExpression = Visit(lambdaTree);
            
            if (Definition.ReturnedType != bodyExpression.Type 
                && Definition.ReturnedType.IsAssignableFrom(bodyExpression.Type))
                bodyExpression = Expression.Convert(bodyExpression, Definition.ReturnedType);

            var ex = Expression.Lambda<T>(bodyExpression, Parameters);

            BuildInfo.Log(ex.ToString(), FormulaCompilerBuildInfoLevels.Expression);

            return ex;
        }

        protected virtual Expression Visit(CommonTree tree)
        {
            switch (tree.Type)
            {
                case FormulaLexer.MINUS:
                    if (tree.ChildCount == 2)
                        return VisitBinary(tree);
                    if (tree.ChildCount == 1)
                        return VisitUnary(tree);
                    throw new InvalidOperationException("Invalid AST tree");

                case FormulaLexer.PLUS:
                case FormulaLexer.MULTIPLY:
                case FormulaLexer.DIVIDE:
                case FormulaLexer.MODULO:
                case FormulaLexer.AND:
                case FormulaLexer.OR:
                case FormulaLexer.EQUALS:
                case FormulaLexer.NOTEQUALS:
                case FormulaLexer.LESSOREQUALS:
                case FormulaLexer.LESS:
                case FormulaLexer.GREATEROREQUALS:
                case FormulaLexer.GREATER:
                    return VisitBinary(tree);
                case FormulaLexer.IntegerLiteral:
                case FormulaLexer.DecimalLiteral:
                case FormulaLexer.StringLiteral:
                case FormulaLexer.BooleanLiteral:
                    return VisitLiteral(tree);
                case FormulaLexer.CALL:
                    return VisitCall(tree);
                case FormulaLexer.METHOD:
                    return VisitMethod(tree, null);
                case FormulaLexer.LAMBDA:
                    return VisitLambda(tree);
                default:
                    throw new InvalidOperationException("Unknown AST node.");
            }
        }

        protected Type GetType(ITree tree)
        {
            Type type = null;
            string typeName;
            if (tree.ChildCount == 1)
            {
                typeName = tree.GetChild(0).Text;

                if (!_aliases.TryGetValue(typeName, out type))
                    type = Type.GetType(typeName, true);
            }
            else
            {
                var parts = new string[tree.ChildCount - 1];

                for (int i = 0; i < tree.ChildCount - 1; i++)
                    parts[i] = tree.GetChild(i).Text;

                typeName = string.Join(".", parts);
            }

            if (type == null)
                Type.GetType(typeName, true, true);

            return type;
        }

        protected IDisposable LocalCallProvider(ICallProvider callProvider)
        {
            var old = CallProvider;
            return Helpers.Disposable(
                () => CallProvider = new AggregateCallProvider()
                                         .Register(new AggregateCallProvider()
                                                       .Register(callProvider)
                                                       .Register(CallProvider)),
                () => CallProvider = old);
        }

        protected virtual Expression VisitLambda(CommonTree tree)
        {
            // Build params
            var parameters = new ParameterExpression[tree.ChildCount-1];
            for (int i = 0; i < parameters.Length; i++)
            {
                var paramType = GetType(tree.GetChild(i).GetChild(0));
                var paramName = tree.GetChild(i).GetChild(1).Text;

                parameters[i] = Expression.Parameter(paramType, paramName);
            }

            Expression body;
            using( LocalCallProvider(new LambdaParameterCallProvider(parameters)))
            {
                // Build expression
                body = Visit((CommonTree) tree.GetChild(tree.ChildCount - 1));
            }

            return Expression.Lambda(body, parameters);
        }

        protected virtual Expression VisitCall(CommonTree tree)
        {
            var left = Visit((CommonTree)tree.Children[0]);

            var right = (CommonTree) tree.Children[1];
            if (right.Type == FormulaLexer.METHOD)
            {
                Expression expression = VisitMethod(right, left);
                if (expression == null && (tree.Parent == null || tree.Parent.Type != FormulaLexer.CALL))
                    throw new MethodNotFoundException(
                        string.Format("Method with name '{0}' does not exist.", GetMethodName(right, left == null)));

                return expression;
            }

            throw new InvalidOperationException("Left subtree of CALL must be METHOD.");
        }

        protected virtual Expression VisitMethod(CommonTree tree, Expression inner)
        {
            // Calc param types
            var parameters = new Expression[tree.ChildCount - 1];
            var types = new Type[parameters.Length];
            for (int i = 1; i < tree.ChildCount; i++)
            {
                parameters[i - 1] = Visit((CommonTree) tree.Children[i]);
                types[i - 1] = parameters[i - 1].Type;
            }

            var methodName = GetMethodName(tree, inner == null);

            Member member=null;
            Expression callOn = null;
            if (inner == null)
            {
                // Parameters
                var param = Parameters.Where(p => p.Name == methodName).FirstOrDefault();
                if (param != null)
                    return param;

                // Find method on this
                if (This != null)
                {
                    member = CallProvider.FindMethod(This.Type, methodName, types);
                    if (member != null) callOn = This;
                }

                // Static method
                if (member == null)
                    member= CallProvider.FindMethod(null, methodName, types);
            }
            else
            {
                // Instance method
                member = CallProvider.FindMethod(inner.Type, methodName, types);
                if (member != null) callOn = inner;
            }

            if (member == null)
            {
                if (tree.Parent == null || tree.Parent.Type != FormulaLexer.CALL)
                    throw new MethodNotFoundException(
                        string.Format("Method with name '{0}' does not exist.", methodName));

                return null;
            }

            return member.CreateExpression(callOn, parameters);
        }

        private static string GetMethodName(ITree tree, bool recursive)
        {
            string name = "";
            if (tree.Type == FormulaLexer.METHOD)
                name = tree.GetChild(0).Text;

            if (recursive)
            {
                if (tree.Parent != null && tree.Parent.Type == FormulaLexer.CALL)
                {
                    ITree subtree = tree.Parent.GetChild(0);
                    if (subtree != tree)
                    {
                        if (subtree.Type == FormulaLexer.CALL)
                            subtree = subtree.GetChild(1);

                        var rec = GetMethodName(subtree, true);

                        if (!string.IsNullOrEmpty(rec))
                            name = rec + "." + name;
                    }
                }
            }

            return name;
        }

        protected virtual Expression VisitLiteral(CommonTree tree)
        {
            if (tree.Type == FormulaLexer.IntegerLiteral)
                return Expression.Constant(int.Parse(tree.Text.TrimEnd('l','L')));
            if (tree.Type == FormulaLexer.DecimalLiteral)
                return Expression.Constant(decimal.Parse(tree.Text.TrimEnd('d','D','f','F'),
                    NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture));
            if (tree.Type == FormulaLexer.StringLiteral)
                return Expression.Constant(tree.Text.Substring(1, tree.Text.Length - 2));
            if (tree.Type == FormulaLexer.BooleanLiteral)
                return Expression.Constant(bool.Parse(tree.Text));

            throw new InvalidOperationException("Invalid literal.");
        }

        protected virtual Expression VisitUnary(CommonTree tree)
        {
            if (tree.Type == FormulaLexer.MINUS)
                return Expression.Negate(Visit((CommonTree) tree.Children[0]));

            throw new InvalidOperationException("Invalid AST tree.");
        }

        protected virtual Expression VisitBinary(CommonTree tree)
        {
            ExpressionType type;

            switch (tree.Type)
            {
                case FormulaLexer.PLUS:
                    type = ExpressionType.Add;
                    break;
                case FormulaLexer.MINUS:
                    type = ExpressionType.Subtract;
                    break;
                case FormulaLexer.MULTIPLY:
                    type = ExpressionType.Multiply;
                    break;
                case FormulaLexer.DIVIDE:
                    type = ExpressionType.Divide;
                    break;
                case FormulaLexer.MODULO:
                    type = ExpressionType.Modulo;
                    break;
                case FormulaLexer.AND:
                    type = ExpressionType.And;
                    break;
                case FormulaLexer.OR:
                    type = ExpressionType.Or;
                    break;
                case FormulaLexer.EQUALS:
                    type = ExpressionType.Equal;
                    break;
                case FormulaLexer.NOTEQUALS:
                    type = ExpressionType.NotEqual;
                    break;
                case FormulaLexer.LESSOREQUALS:
                    type = ExpressionType.LessThanOrEqual;
                    break;
                case FormulaLexer.LESS:
                    type = ExpressionType.LessThan;
                    break;
                case FormulaLexer.GREATEROREQUALS:
                    type = ExpressionType.GreaterThanOrEqual;
                    break;
                case FormulaLexer.GREATER:
                    type = ExpressionType.GreaterThan;
                    break;

                default:
                    throw new InvalidOperationException("Invalid AST tree.");
            }

            var arg1 = Visit((CommonTree) tree.Children[0]);
            var arg2 = Visit((CommonTree) tree.Children[1]);


            // TEMP:
            if (arg1.Type == typeof(decimal) && arg2.Type == typeof(int))
                arg2=Expression.Convert(arg2, typeof (decimal));
            else if (arg1.Type == typeof(int) && arg2.Type == typeof(decimal))
                arg1= Expression.Convert(arg1, typeof(decimal));

            if (arg1.Type == typeof(string) && arg2.Type == typeof(string) && type == ExpressionType.Add)
                return Expression.Add(arg1, arg2,
                                      typeof (string).GetMethod("Concat", new[] {typeof (string), typeof (string)}));


            // AndAlso
            return Expression.MakeBinary(type, arg1, arg2);
        }
    }
}