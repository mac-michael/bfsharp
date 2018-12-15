using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using BFsharp.DynamicProperties;
#if PHONE
using ExpressionCompiler;
#endif

namespace BFsharp
{
    public class DependencyHelper
    {
        internal static bool IsGetPropertyMethod(Expression expression)
        {
            if (expression.NodeType == ExpressionType.Call)
            {
                var methodCall = (MethodCallExpression) expression;
                if ((methodCall.Method.IsGenericMethod &&
                     methodCall.Method.GetGenericMethodDefinition()
                     == typeof (DynamicPropertyCollection).GetMethod("GetProperty")) ||
                    methodCall.Method == typeof (DynamicPropertyCollection).GetMethod("get_Item"))
                {
                    if (methodCall.Arguments[0] is ConstantExpression)
                        return true;
                }
            }
            return false;
        }

        public static Action<T,V> GetSetFromGet<T,V>(Expression<Func<T,V>> expression)
        {
            var ex = IgnoreConvert(expression.Body);

            ParameterExpression param = Expression.Parameter(typeof(V), "value");
            MethodCallExpression call;
            if (ex.NodeType == ExpressionType.MemberAccess)
            {
                var root = ((MemberExpression) ex);

                MethodInfo method = ((PropertyInfo) root.Member).GetSetMethod(true);
                call = Expression.Call(root.Expression,
                                       method, 
                                       Expression.Convert(param, method.GetParameters()[0].ParameterType));
            }
            else if (IsGetPropertyMethod(ex))
            {
                var m = (MethodCallExpression)ex;
                var root = ((MethodCallExpression) ex);
                call = Expression.Call(root.Object, "SetProperty", new[] {typeof (V)},
                                       (ConstantExpression)m.Arguments[0], param); // BUG
            }
            else
                throw new InvalidOperationException();

            var setExpression = Expression.Lambda<Action<T, V>>(
                call, expression.Parameters.Single(), param);

            return setExpression.GetFromCacheOrCompile();
        }

        public static IEnumerable<string> GetPropertyPath<T,TReturn>
            (Expression<Func<T,TReturn>> expression)
        {
            var dependency = new List<string>();

            Expression ex = expression.Body;
            
            while (true)
            {
                // Ignore convert
                ex = IgnoreConvert(ex);

                if (ex.NodeType == ExpressionType.MemberAccess)
                {
                    var me = (MemberExpression)ex;

                    if (me.Member is PropertyInfo)
                        dependency.Insert(0, me.Member.Name);
                    else
                        throw new InvalidOperationException("Invalid expression");
                    ex = me.Expression;
                }
                else if (IsGetPropertyMethod(ex))
                {
                    var m = (MethodCallExpression)ex;
                    var name = (string)((ConstantExpression)m.Arguments[0]).Value;
                    dependency.Insert(0, name);

                    ex = m.Object;
                }
                else if (ex.NodeType == ExpressionType.Parameter)
                    break;
                else
                    throw new InvalidOperationException("Invalid expression");
            }

            return dependency;
        }

        private static Expression IgnoreConvert(Expression ex) 
        {
            if (ex.NodeType == ExpressionType.Convert)
                ex = ((UnaryExpression) ex).Operand;
            return ex;
        }
    }
}