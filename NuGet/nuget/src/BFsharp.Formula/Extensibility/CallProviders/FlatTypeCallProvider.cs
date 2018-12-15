using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BFsharp.Formula
{
    public class FlatTypeCallProvider : CallProviderBase
    {
        private readonly Type _type;
        private readonly Type _requiredAttribute;

        public FlatTypeCallProvider(Type type, Type requiredAttribute)
        {
            _type = type;
            _requiredAttribute = requiredAttribute;
        }

        protected override IEnumerable<Method> GetMethods(Type type)
        {
            if (type != null) return Enumerable.Empty<Method>();

            var calls = (from p in _type.GetProperties(BindingFlags.Static | BindingFlags.Public)
                         select (Method) p).Union(
                from m in _type.GetMethods(BindingFlags.Static | BindingFlags.Public)
                select (Method) m);

            if (_requiredAttribute != null)
                calls = calls.Where(m => m.MethodInfo.GetCustomAttributes(_requiredAttribute, false).Count() > 0);
            return calls;
        }
    }
}