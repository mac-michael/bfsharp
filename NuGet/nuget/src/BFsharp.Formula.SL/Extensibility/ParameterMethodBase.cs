using System.Linq.Expressions;
using System.Reflection;

namespace BFsharp.Formula
{
    class ParameterMethodBase : Member
    {
        public ParameterExpression Parameter { get; set; }

        public override Expression CreateExpression(Expression @this, Expression[] arguments)
        {
            return Parameter;
        }
    }
}