using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using Db4objects.Db4o.Linq.Expressions;

namespace BFsharp
{
    public class Cache<TKey,TValue>
    {
        private readonly Dictionary<TKey, TValue> _cache = new Dictionary<TKey, TValue>();
        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

        public TValue GetOrAdd(TKey key, Func<TKey,TValue> factory)
        {
            TValue value;
            _lock.EnterReadLock();
            try
            {
                if ( _cache.TryGetValue(key, out value))
                    return value;
                }
            finally
            {
                _lock.ExitReadLock();
            }

            _lock.EnterWriteLock();
            try
            {
                value = factory(key);
                _cache[key] = value;

                return value;
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    }

    internal class ExpressionCache : Cache<ExpressionCache.ExpressionCacheKey, object>
    {
        private static readonly ExpressionCache _instance = new ExpressionCache();
        public static ExpressionCache Instance
        {
            get { return _instance; }
        }

        internal class ExpressionCacheKey
        {
            public Expression Expression { get; set; }

            public override bool Equals(object obj)
            {
                return ExpressionEqualityComparer.Instance.Equals(
                    Expression, ((ExpressionCacheKey) obj).Expression);
            }

            public override int GetHashCode()
            {
                return ExpressionEqualityComparer.Instance.GetHashCode(
                    Expression);
            }

            public static implicit operator ExpressionCacheKey(Expression e)
            {
                return new ExpressionCacheKey {Expression = e};
            }
        }

    }
}