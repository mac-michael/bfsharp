using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace BFsharp.Formula
{
    public class Method : Member
    {
        public Method(MemberInfo method)
        {
            if (method is MethodInfo)
                Parameteres = ((MethodInfo) method).GetParameters().Select(p => p.ParameterType).ToArray();
            else if (method is PropertyInfo)
                Parameteres = new Type[0];
            else
                throw new ArgumentException("method argument should be of type MethodInfo or PropertyInfo");
         
            MethodInfo = method;
        }

        private MemberInfo _methodInfo;
        public MemberInfo MethodInfo
        {
            get { return _methodInfo; }
            private set
            {
                _methodInfo = value;
                Name = _methodInfo.Name;
            }
        }

        public override Expression CreateExpression(Expression @this, Expression[] arguments)
        {
            if (MethodInfo is PropertyInfo)
                return Expression.Property(@this, (PropertyInfo)MethodInfo);
            if (MethodInfo is MethodInfo)
                return Expression.Call(@this, (MethodInfo)MethodInfo, arguments);

            throw new InvalidOperationException("Unreachable code.");
        }

        public static implicit operator Method(MethodInfo methodInfo)
        {
            return new Method(methodInfo);
        }

        public static implicit operator Method(PropertyInfo propertyInfo)
        {
            return new Method(propertyInfo);
        }
    }
}