using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace BFsharp
{
    public static class PrecompilationHelper
    {
#if PHONE
        public static Func<T, V> GetPropertySelector<T,V>(params PropertyInfo[] info)
        {
            if ( info.Length != 1)
                throw new NotImplementedException("Only 1 PropertyInfo can be specified.");

            return i => GetPropertyImpl<T,V>(info.First(), i);
        }

        private static V GetPropertyImpl<T, V>(PropertyInfo info, T instance)
        {
            return (V) info.GetValue(instance, null);
        }
#else
        public static Func<T, V> GetPropertySelector<T,V>(params PropertyInfo[] info)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression ex = param;
            if (param.Type != info[0].DeclaringType)
                ex = Expression.Convert(param, info[0].DeclaringType);

            if (!ex.Type.IsValueType)
            {
                ex = Expression.Condition(
                            Expression.Equal(ex, Expression.Constant(null, ex.Type)),
                        Expression.Constant(null, ex.Type), ex);
            }
            
            foreach (var propertyInfo in info)
            {
                if (propertyInfo.PropertyType.IsValueType)
                    ex = Expression.Property(ex, propertyInfo);
                else
                {
                    ex = Expression.Condition(
                        Expression.Equal(ex,
                                         Expression.Constant(null, ex.Type)),
                        Expression.Constant(null, propertyInfo.PropertyType),
                        Expression.Property(ex, propertyInfo));
                }
            }

            if (ex.Type != typeof(V))
                ex = Expression.Convert(ex, typeof (V));

            var selector = Expression.Lambda<Func<T, V>>(ex, param);

            return selector.Compile();
        }
#endif
        public static Func<T,object> GetPropertySelector<T>(params PropertyInfo[] info)
        {
            return GetPropertySelector<T, object>(info);
        }

        public static Func<object, object> GetPropertySelector( PropertyInfo info )
        {
            return GetPropertySelector<object, object>(info);
        }

        public static Type GetIEnumerableGenericParam(this Type type)
        {
            IEnumerable<Type> interfaces = type.GetInterfaces();
            if (type.IsInterface)
                interfaces = interfaces.Union(new[] {type});

            foreach (var i in interfaces)
            {
                if ( i.IsGenericType )
                {
                    if (i.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                    {
                        return i.GetGenericArguments()[0];
                    }
                }
            }

            return null;
        }
    }
}