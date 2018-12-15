using System;
using System.Linq.Expressions;
#if PHONE
using ExpressionCompiler;
#endif

namespace BFsharp
{
    internal static partial class Extensions
    {
#if !PHONE
        public static T GetFromCacheOrCompile<T>(this Expression<T> expression) where T : class
        {
            if (!ExtensionsOptions.CacheLambdas)
                return expression.Compile();

            var f = (T) ExpressionCache.Instance.GetOrAdd(expression,
                                                          k => ((Expression<T>) k.Expression).Compile());
            
            return f;
        }
#else
        public static Func<T, TReturn> GetFromCacheOrCompile<T, TReturn>(this Expression<Func<T, TReturn>> expression)
        {
            return expression.Compile();
        }

        public static Action<T, T2> GetFromCacheOrCompile<T, T2>(this Expression<Action<T, T2>> expression)
        {
            return expression.Compile();
        }
        
        public static Action<T> GetFromCacheOrCompile<T>(this Expression<Action<T>> expression)
        {
            return expression.Compile();
        }
#endif
    }
}