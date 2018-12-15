using System;
using System.Linq.Expressions;

namespace BFsharp.Formula
{
    public abstract class Member
    {
        public Type[] Parameteres { get; set; }
        public string Name { get; set; }

        public abstract Expression CreateExpression(Expression @this, Expression[] arguments);
    }
}