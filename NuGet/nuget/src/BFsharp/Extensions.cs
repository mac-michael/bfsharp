using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BFsharp
{
    internal static partial class Extensions
    {
        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
            where TValue : new()
        {
            TValue value;
            if (!dictionary.TryGetValue(key, out value))
            {
                value = new TValue();
                dictionary.Add(key, value);
            }
            return value;
        }

        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> factory)
        {
            TValue value;
            if (!dictionary.TryGetValue(key, out value))
            {
                value = factory(key);
                dictionary.Add(key, value);
            }
            return value;
        }

        public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            if (!dictionary.TryGetValue(key, out value))
                return default(TValue);
            return value;
        }

        public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue @default)
        {
            TValue value;
            if (!dictionary.TryGetValue(key, out value))
                return @default;
            return value;
        }

        public static int RemoveAll<T>(this IList<T> source, Func<T,bool> predicate)
        {
            int count = 0;
            for (int i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                {
                    source.RemoveAt(i);
                    count++;
                }

                i--;
            }

            return count;
        }

        //public static void BinaryInsert<T>(this IList<T> source, T item)
        //    where T : IComparable<T>
        //{
        //    int start = 0;
        //    int end = source.Count-1;

        //    while(start<end)
        //    {
        //        int current = start + ((end - start) >> 1);

        //        var compare = item.CompareTo(source[current]);

        //        if (compare < 0)
        //            end = current - 1;
        //        else
        //            start = current + 1;
        //    }
        //    if (source.Count > 0 && source[start].CompareTo(item) <= 0)
        //        start++;
        //    source.Insert(start, item);
        //}

        public static object GetDefault(this Type type)
        {
            if (!type.IsValueType)
                return null;
            
            return Activator.CreateInstance(type); // Value type has a default constructor
        }

        public static EntityExtensions GetImplementation(this IEntityExtensions extensions)
        {
            if (extensions is EntityExtensions)
                return (EntityExtensions) extensions;
            if (extensions is IGetInternalEntityExtensions)
                return ((IGetInternalEntityExtensions) extensions).GetExtensions().GetImplementation();

            throw new InvalidOperationException();
        }
    }

    public struct Pair<T,T1>
    {
        public Pair(T one, T1 two) : this()
        {
            One = one;
            Two = two;
        }

        public T One { get; set; }
        public T1 Two { get; set; }
    }
}
