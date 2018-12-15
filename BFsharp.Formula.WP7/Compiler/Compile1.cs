 
using System;
using System.Linq.Expressions;

namespace ExpressionCompiler
{
	public static class Extensions
	{
		public static Func<TResult> Compile<TResult>(this Expression<Func<TResult>> expression)
		{
			var d = ExpressionCompiler.Compile( (LambdaExpression)expression );
			return () => (TResult)d.DynamicInvoke();
		}
		
		public static Func<T1, TResult> Compile<T1, TResult>(this Expression<Func<T1, TResult>> expression)
		{
			var d = ExpressionCompiler.Compile( (LambdaExpression)expression );
			return (p1) => (TResult)d.DynamicInvoke(p1);
		}
		
		public static Func<T1, T2, TResult> Compile<T1, T2, TResult>(this Expression<Func<T1, T2, TResult>> expression)
		{
			var d = ExpressionCompiler.Compile( (LambdaExpression)expression );
			return (p1, p2) => (TResult)d.DynamicInvoke(p1, p2);
		}
		
		public static Func<T1, T2, T3, TResult> Compile<T1, T2, T3, TResult>(this Expression<Func<T1, T2, T3, TResult>> expression)
		{
			var d = ExpressionCompiler.Compile( (LambdaExpression)expression );
			return (p1, p2, p3) => (TResult)d.DynamicInvoke(p1, p2, p3);
		}
		
		public static Func<T1, T2, T3, T4, TResult> Compile<T1, T2, T3, T4, TResult>(this Expression<Func<T1, T2, T3, T4, TResult>> expression)
		{
			var d = ExpressionCompiler.Compile( (LambdaExpression)expression );
			return (p1, p2, p3, p4) => (TResult)d.DynamicInvoke(p1, p2, p3, p4);
		}
		
		public static Action<T1> Compile<T1>(this Expression<Action<T1>> expression)
		{
			var d = ExpressionCompiler.Compile( (LambdaExpression)expression );
			return (p1) => d.DynamicInvoke(p1);
		}
		
		public static Action<T1, T2> Compile<T1, T2>(this Expression<Action<T1, T2>> expression)
		{
			var d = ExpressionCompiler.Compile( (LambdaExpression)expression );
			return (p1, p2) => d.DynamicInvoke(p1, p2);
		}
		
		public static Action<T1, T2, T3> Compile<T1, T2, T3>(this Expression<Action<T1, T2, T3>> expression)
		{
			var d = ExpressionCompiler.Compile( (LambdaExpression)expression );
			return (p1, p2, p3) => d.DynamicInvoke(p1, p2, p3);
		}
		
		public static Action<T1, T2, T3, T4> Compile<T1, T2, T3, T4>(this Expression<Action<T1, T2, T3, T4>> expression)
		{
			var d = ExpressionCompiler.Compile( (LambdaExpression)expression );
			return (p1, p2, p3, p4) => d.DynamicInvoke(p1, p2, p3, p4);
		}
		
	}
}
 
