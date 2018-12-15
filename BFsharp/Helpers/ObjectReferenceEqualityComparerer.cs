using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BFsharp
{
    internal class ObjectReferenceEqualityComparerer<T> : EqualityComparer<T>
        where T : class
    {
        private static readonly IEqualityComparer<T> _defaultComparer = new ObjectReferenceEqualityComparerer<T>();

        public new static IEqualityComparer<T> Default
        {
            get { return _defaultComparer; }
        }

        #region IEqualityComparer<T> Members

        public override bool Equals(T x, T y)
        {
            return ReferenceEquals(x, y);
        }

        public override int GetHashCode(T obj)
        {
            return RuntimeHelpers.GetHashCode(obj);
        }

        #endregion
    }
}