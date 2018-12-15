using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BFsharp.Formula
{
    public class TypeCallProvider : CallProviderBase
    {
        private readonly Type _type;
        private readonly Type _requiredAttribute;

        public TypeCallProvider(Type type) : this(type,null) { }

        public TypeCallProvider(Type type, Type requiredAttribute)
        {
            _type = type;
            _requiredAttribute = requiredAttribute;
        }

        protected override IEnumerable<Method> GetMethods(Type type)
        {
            if (type != _type) return Enumerable.Empty<Method>();

            var calls = (from p in type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                         select (Method)p).Union(
                from m in type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                select (Method)m);

            if (_requiredAttribute != null)
                calls = calls.Where(m => m.MethodInfo.GetCustomAttributes(_requiredAttribute, false).Count() > 0);
            return calls;
        }
    }
}