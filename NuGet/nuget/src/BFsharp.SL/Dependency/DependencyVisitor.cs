using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace BFsharp
{
    public class DependencyVisitor
    {
        public class DependencyInfo
        {
            public string[] Methods { get; set; }
            public DependencyAction Action { get; set; }
        }

        public class DependencyAction
        {
            public DependencyAction(int selectorIndex)
            {
                SelectorIndex = selectorIndex;
            }

            public DependencyAction() : this(-1) { }
            public bool Restore { get; set; }
            public int SelectorIndex { get; set; }
        }

        public Dictionary<MethodInfo, DependencyAction> GetLinqDef()
        {
            var defintion = new[]
                          {
                              new DependencyInfo
                                  {
                                      Methods = new[]
                                                    {
                                                        "System.Nullable`1[System.Int32] Max[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Nullable`1[System.Int32]])"
                                                        ,
                                                        "System.Nullable`1[System.Int64] Max[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Nullable`1[System.Int64]])"
                                                        ,
                                                        "System.Nullable`1[System.Single] Max[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Nullable`1[System.Single]])"
                                                        ,
                                                        "System.Nullable`1[System.Double] Max[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Nullable`1[System.Double]])"
                                                        ,
                                                        "System.Nullable`1[System.Decimal] Max[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Nullable`1[System.Decimal]])"
                                                        ,
                                                        "Int32 Max[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Int32])"
                                                        ,
                                                        "Int64 Max[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Int64])"
                                                        ,
                                                        "Single Max[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Single])"
                                                        ,
                                                        "Double Max[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Double])"
                                                        ,
                                                        "System.Decimal Max[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Decimal])"
                                                        ,
                                                        "TResult Max[TSource,TResult](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,TResult])"
                                                        ,
                                                    },
                                      Action = new DependencyAction(1)
                                  },
                              new DependencyInfo
                                  {
                                      Methods = new[]
                                                    {
                                                        "Single Max(System.Collections.Generic.IEnumerable`1[System.Single])"
                                                        ,
                                                        "System.Nullable`1[System.Double] Max(System.Collections.Generic.IEnumerable`1[System.Nullable`1[System.Double]])"
                                                        ,
                                                        "System.Nullable`1[System.Single] Max(System.Collections.Generic.IEnumerable`1[System.Nullable`1[System.Single]])"
                                                        ,
                                                        "System.Decimal Max(System.Collections.Generic.IEnumerable`1[System.Decimal])"
                                                        ,
                                                        "TSource Max[TSource](System.Collections.Generic.IEnumerable`1[TSource])"
                                                        ,
                                                        "Int32 Max(System.Collections.Generic.IEnumerable`1[System.Int32])"
                                                        ,
                                                        "Int64 Max(System.Collections.Generic.IEnumerable`1[System.Int64])"
                                                        ,
                                                        "Double Max(System.Collections.Generic.IEnumerable`1[System.Double])"
                                                        ,
                                                        "System.Nullable`1[System.Int32] Max(System.Collections.Generic.IEnumerable`1[System.Nullable`1[System.Int32]])"
                                                        ,
                                                        "System.Nullable`1[System.Int64] Max(System.Collections.Generic.IEnumerable`1[System.Nullable`1[System.Int64]])"
                                                        ,
                                                        "System.Nullable`1[System.Decimal] Max(System.Collections.Generic.IEnumerable`1[System.Nullable`1[System.Decimal]])"
                                                    },
                                      Action = new DependencyAction(),
                                  },

                                  new DependencyInfo
                                  {
                                      Methods = new[]
                                                    {
                                                        "Int32 Sum(System.Collections.Generic.IEnumerable`1[System.Int32])",
                                                        "System.Nullable`1[System.Int32] Sum(System.Collections.Generic.IEnumerable`1[System.Nullable`1[System.Int32]])",
                                                        "Int64 Sum(System.Collections.Generic.IEnumerable`1[System.Int64])",
                                                        "System.Nullable`1[System.Int64] Sum(System.Collections.Generic.IEnumerable`1[System.Nullable`1[System.Int64]])",
                                                        "Single Sum(System.Collections.Generic.IEnumerable`1[System.Single])",
                                                        "System.Nullable`1[System.Single] Sum(System.Collections.Generic.IEnumerable`1[System.Nullable`1[System.Single]])",
                                                        "Double Sum(System.Collections.Generic.IEnumerable`1[System.Double])",
                                                        "System.Nullable`1[System.Double] Sum(System.Collections.Generic.IEnumerable`1[System.Nullable`1[System.Double]])",
                                                        "System.Decimal Sum(System.Collections.Generic.IEnumerable`1[System.Decimal])",
                                                        "System.Nullable`1[System.Decimal] Sum(System.Collections.Generic.IEnumerable`1[System.Nullable`1[System.Decimal]])",
                                                    },
                                      Action = new DependencyAction(),
                                  },

                                  new DependencyInfo
                                  {
                                      Methods = new[]
                                                    {
                                                        "Int32 Sum[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Int32])",
                                                        "System.Nullable`1[System.Int32] Sum[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Nullable`1[System.Int32]])",
                                                        "Int64 Sum[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Int64])",
                                                        "System.Nullable`1[System.Int64] Sum[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Nullable`1[System.Int64]])",
                                                        "Single Sum[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Single])",
                                                        "System.Nullable`1[System.Single] Sum[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Nullable`1[System.Single]])",
                                                        "Double Sum[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Double])",
                                                        "System.Nullable`1[System.Double] Sum[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Nullable`1[System.Double]])",
                                                        "System.Decimal Sum[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Decimal])",
                                                       "System.Nullable`1[System.Decimal] Sum[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Nullable`1[System.Decimal]])",
                                                    },
                                      Action = new DependencyAction(1),
                                  },
                                  new DependencyInfo
                                  {
                                      Methods = new[]
                                                    {
                                                        "System.Collections.Generic.IEnumerable`1[TResult] Select[TSource,TResult](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,TResult])",
                                                        "System.Collections.Generic.IEnumerable`1[TResult] Select[TSource,TResult](System.Collections.Generic.IEnumerable`1[TSource], System.Func`3[TSource,System.Int32,TResult])",

                                                    },
                                      Action = new DependencyAction(1),
                                  },
                                  new DependencyInfo
                                  {
                                      Methods = new[]
                                                    {
                                                        "Int32 Min(System.Collections.Generic.IEnumerable`1[System.Int32])",
                                                        "System.Nullable`1[System.Int32] Min(System.Collections.Generic.IEnumerable`1[System.Nullable`1[System.Int32]])",
                                                        "Int64 Min(System.Collections.Generic.IEnumerable`1[System.Int64])",
                                                        "System.Nullable`1[System.Int64] Min(System.Collections.Generic.IEnumerable`1[System.Nullable`1[System.Int64]])",
                                                        "Single Min(System.Collections.Generic.IEnumerable`1[System.Single])",
                                                        "System.Nullable`1[System.Single] Min(System.Collections.Generic.IEnumerable`1[System.Nullable`1[System.Single]])",
                                                        "Double Min(System.Collections.Generic.IEnumerable`1[System.Double])",
                                                        "System.Nullable`1[System.Double] Min(System.Collections.Generic.IEnumerable`1[System.Nullable`1[System.Double]])",
                                                        "System.Decimal Min(System.Collections.Generic.IEnumerable`1[System.Decimal])",
                                                        "System.Nullable`1[System.Decimal] Min(System.Collections.Generic.IEnumerable`1[System.Nullable`1[System.Decimal]])",
                                                        "TSource Min[TSource](System.Collections.Generic.IEnumerable`1[TSource])",
                                                         },
                                      Action = new DependencyAction(),
                                  },
                                  new DependencyInfo
                                  {
                                      Methods = new[]
                                                    {
                                                        "Int32 Min[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Int32])",
                                                        "System.Nullable`1[System.Int32] Min[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Nullable`1[System.Int32]])",
                                                        "Int64 Min[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Int64])",
                                                        "System.Nullable`1[System.Int64] Min[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Nullable`1[System.Int64]])",
                                                        "Single Min[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Single])",
                                                        "System.Nullable`1[System.Single] Min[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Nullable`1[System.Single]])",
                                                        "Double Min[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Double])",
                                                        "System.Nullable`1[System.Double] Min[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Nullable`1[System.Double]])",
                                                        "System.Decimal Min[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Decimal])",
                                                        "System.Nullable`1[System.Decimal] Min[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,System.Nullable`1[System.Decimal]])",
                                                        "TResult Min[TSource,TResult](System.Collections.Generic.IEnumerable`1[TSource], System.Func`2[TSource,TResult])",
                                                    },
                                      Action = new DependencyAction(1),
                                  },
                          };

            var dic = new Dictionary<MethodInfo, DependencyAction>();
            var r = from i in defintion
                    from m in i.Methods
                    join method in typeof(Enumerable).GetMethods() on m equals method.ToString()
                    select new { method, i.Action };

            var res = r.ToDictionary(k=>k.method,v=>v.Action);

            return res;
        }

        private Queue<string> _root = new Queue<string>();

        public void Visit(Expression expression)
        {
            VisitInternal(expression);

            if (!string.IsNullOrEmpty(c))
                Debug.WriteLine(c);
        }

        protected void VisitInternal(Expression exp)
        {
            if (exp == null) return;

            if (exp.NodeType != ExpressionType.MemberAccess &&
                exp.NodeType != ExpressionType.Call && !string.IsNullOrEmpty(c)) 
            {
                Debug.WriteLine(c);
                c = "";
            }

            switch (exp.NodeType)
            {
                case ExpressionType.Negate:
                case ExpressionType.NegateChecked:
                case ExpressionType.Not:
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                case ExpressionType.ArrayLength:
                case ExpressionType.Quote:
                case ExpressionType.TypeAs:
                    VisitUnary((UnaryExpression)exp);
                    break;
                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                case ExpressionType.Divide:
                case ExpressionType.Modulo:
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.Coalesce:
                case ExpressionType.ArrayIndex:
                case ExpressionType.RightShift:
                case ExpressionType.LeftShift:
                case ExpressionType.ExclusiveOr:
                    VisitBinary((BinaryExpression)exp);
                    break;
                case ExpressionType.TypeIs:
                    VisitTypeIs((TypeBinaryExpression)exp);
                    break;
                case ExpressionType.Conditional:
                    VisitConditional((ConditionalExpression)exp);
                    break;
                case ExpressionType.Constant:
                    VisitConstant((ConstantExpression)exp);
                    break;
                case ExpressionType.Parameter:
                    VisitParameter((ParameterExpression)exp);
                    break;
                case ExpressionType.MemberAccess:
                    VisitMemberAccess((MemberExpression)exp);
                    break;
                case ExpressionType.Call:
                    VisitMethodCall((MethodCallExpression)exp);
                    break;
                case ExpressionType.Lambda:
                    VisitLambda((LambdaExpression)exp);
                    break;
                case ExpressionType.New:
                    VisitNew((NewExpression)exp);
                    break;
                case ExpressionType.NewArrayInit:
                case ExpressionType.NewArrayBounds:
                    VisitNewArray((NewArrayExpression)exp);
                    break;
                case ExpressionType.Invoke:
                    VisitInvocation((InvocationExpression)exp);
                    break;
                case ExpressionType.MemberInit:
                    VisitMemberInit((MemberInitExpression)exp);
                    break;
                case ExpressionType.ListInit:
                    VisitListInit((ListInitExpression)exp);
                    break;
                default:
                    throw new Exception(string.Format("Unhandled expression type: '{0}'", exp.NodeType));
            }
        }

        protected virtual void VisitBinding(MemberBinding binding)
        {
            switch (binding.BindingType)
            {
                case MemberBindingType.Assignment:
                    VisitMemberAssignment((MemberAssignment)binding);
                    break;
                case MemberBindingType.MemberBinding:
                    VisitMemberMemberBinding((MemberMemberBinding)binding);
                    break;
                case MemberBindingType.ListBinding:
                    VisitMemberListBinding((MemberListBinding)binding);
                    break;
                default:
                    throw new Exception(string.Format("Unhandled binding type '{0}'", binding.BindingType));
            }
        }

        protected virtual void VisitElementInitializer(ElementInit initializer)
        {
            VisitExpressionList(initializer.Arguments);
        }

        protected virtual void VisitUnary(UnaryExpression u)
        {
            VisitInternal(u.Operand);
        }

        protected virtual void VisitBinary(BinaryExpression b)
        {
            VisitInternal(b.Left);
            VisitInternal(b.Right);
            VisitInternal(b.Conversion);
        }

        protected virtual void VisitTypeIs(TypeBinaryExpression b)
        {
            VisitInternal(b.Expression);
        }

        protected virtual void VisitConstant(ConstantExpression c)
        {
        }

        protected virtual void VisitConditional(ConditionalExpression c)
        {
            VisitInternal(c.Test);
            VisitInternal(c.IfTrue);
            VisitInternal(c.IfFalse);
        }

        private string c;
        protected virtual void VisitParameter(ParameterExpression p)
        {
            c = _map.GetOrDefault(p, p.Name);
        }

        protected virtual void VisitMemberAccess(MemberExpression m)
        {
            VisitInternal(m.Expression);
            c = c + "." + m.Member.Name;
        }

        protected virtual void VisitMethodCall(MethodCallExpression m)
        {
            var d = GetLinqDef();
            var method = m.Method.IsGenericMethod ? m.Method.GetGenericMethodDefinition() : m.Method;

            DependencyAction action;
            if (d.TryGetValue(method,out action))
            {
                VisitInternal(m.Arguments[0]);

                if (!string.IsNullOrEmpty(c) && c[c.Length - 1] != '$' )
                    c += "$";
                if (action.SelectorIndex > -1)
                {
                    _map.Add(((LambdaExpression)m.Arguments[action.SelectorIndex]).Parameters[0], c);
                    c = "";

                    VisitInternal(m.Arguments[action.SelectorIndex]);
                }
            }
            else if (m.Method.Name == "Where")
            {
                VisitInternal(m.Arguments[0]);
                if (!string.IsNullOrEmpty(c) && c[c.Length-1] != '$' )
                    c += "$";
                _map.Add(((LambdaExpression) m.Arguments[1]).Parameters[0], c);
                var co = c;
                c = "";
                VisitInternal(m.Arguments[1]);
                c = co;
            }
            else
            {
                VisitInternal(m.Object);
                VisitExpressionList(m.Arguments);
            }
        }

        protected virtual void VisitExpressionList(ReadOnlyCollection<Expression> original)
        {
            for (int i = 0; i < original.Count; i++)
                VisitInternal(original[i]);
        }

        protected virtual void VisitMemberAssignment(MemberAssignment assignment)
        {
            VisitInternal(assignment.Expression);
        }

        protected virtual void VisitMemberMemberBinding(MemberMemberBinding binding)
        {
            VisitBindingList(binding.Bindings);
        }

        protected virtual void VisitMemberListBinding(MemberListBinding binding)
        {
            VisitElementInitializerList(binding.Initializers);
        }

        protected virtual void VisitBindingList(ReadOnlyCollection<MemberBinding> original)
        {
            for (int i = 0; i < original.Count; i++)
                VisitBinding(original[i]);
        }

        protected virtual void VisitElementInitializerList(ReadOnlyCollection<ElementInit> original)
        {
            for (int i = 0; i < original.Count; i++)
                VisitElementInitializer(original[i]);
        }

        private Dictionary<ParameterExpression, string> _map = new Dictionary<ParameterExpression, string>();
        protected virtual void VisitLambda(LambdaExpression lambda)
        {
            VisitInternal(lambda.Body);
        }

        protected virtual void VisitNew(NewExpression nex)
        {
            VisitExpressionList(nex.Arguments);
        }

        protected virtual void VisitMemberInit(MemberInitExpression init)
        {
            VisitNew(init.NewExpression);
            VisitBindingList(init.Bindings);
        }

        protected virtual void VisitListInit(ListInitExpression init)
        {
            VisitNew(init.NewExpression);
            VisitElementInitializerList(init.Initializers);
        }

        protected virtual void VisitNewArray(NewArrayExpression na)
        {
            VisitExpressionList(na.Expressions);
        }

        protected virtual void VisitInvocation(InvocationExpression iv)
        {
            VisitExpressionList(iv.Arguments);
            VisitInternal(iv.Expression);
        }
    }
}