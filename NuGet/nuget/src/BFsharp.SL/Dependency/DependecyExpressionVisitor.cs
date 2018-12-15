using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BFsharp
{
    public class DependecyExpressionVisitor : ExpressionVisitor
    {
        private readonly List<List<string>> _members = new List<List<string>>();
        private List<string> _member = new List<string>();

        public List<List<string>> Members
        {
            get { return _members; }
        }

        internal List<PropertyPath> PropertyPaths
        {
            get { return _members.Select(p => new PropertyPath(p)).ToList(); }
        }

        private Expression _expression;
        public void Analyze(Expression expression)
        {
            _expression = expression;
            Visit(expression);
            _expression = null;
        }

        protected override Expression VisitConstant(ConstantExpression c)
        {
            RuleDebugger.CheckClosureWarning(c.Type, _expression);
            
            return base.VisitConstant(c);
        }

        protected override Expression Visit(Expression exp)
        {
            if (exp != null && exp.NodeType != ExpressionType.MemberAccess &&
                !(DependencyHelper.IsGetPropertyMethod(exp)))
            {
                if (_member.Count > 0)
                {
                    _member.Reverse();
                    Members.Add(_member);
                    _member = new List<string>();
                }
            }
            return base.Visit(exp);
        }

        protected override Expression VisitMemberAccess(MemberExpression m)
        {
            _member.Add(m.Member.Name);
            return base.VisitMemberAccess(m);
        }

        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            if (DependencyHelper.IsGetPropertyMethod(m))
                _member.Add((string)((ConstantExpression)m.Arguments[0]).Value);

            return base.VisitMethodCall(m);
        }
    }
}