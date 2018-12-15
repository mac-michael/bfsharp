using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace BFsharp.Formula
{
    internal class ExtensionMethod : Member
    {
        public MethodInfo Method { get; set; }

        public ExtensionMethod(MethodInfo method)
        {
            Method = method;
            Parameteres = method.GetParameters().Skip(1).Select(p => p.ParameterType).ToArray();
        }

        public override Expression CreateExpression(Expression @this, Expression[] arguments)
        {
            return Expression.Call(Method, Helpers.Combine(@this, arguments));
        }
    }
}