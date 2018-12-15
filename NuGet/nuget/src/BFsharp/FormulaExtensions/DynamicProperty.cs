using System;
using System.Linq.Expressions;
using System.Reflection;
using BFsharp.Formula;

namespace BFsharp.FormulaExtensions
{
    public class DynamicProperty : Member
    {
        public Type ReturnedType { get; set; }
        private PropertyInfo _extensions = typeof(IEntityBase).GetProperty("Extensions");
        
        public override Expression CreateExpression(Expression @this, Expression[] arguments)
        {
            return Expression.Call(
                Expression.Property(
                    Expression.Property(@this, _extensions), "DynamicProperties"),
                "GetProperty", new[] {ReturnedType}, Expression.Constant(Name));
        }
    }
}