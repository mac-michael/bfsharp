using System.Collections;
using System.Collections.Generic;

namespace BFsharp
{
    public class HashSet<T> : IEnumerable<T>
    {
        private readonly Dictionary<T, object> _dic;

        public HashSet()
        {
            _dic = new Dictionary<T, object>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _dic.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T target)
        {
            _dic.Add(target, null);
        }
    }
}
