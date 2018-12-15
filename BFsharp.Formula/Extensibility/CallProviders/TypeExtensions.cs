using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace BFsharp.Formula
{
    public static class TypeExtensions
    {
        private static Type GetTypeDefinition(this Type type)
        {
            return type.IsGenericType ? type.GetGenericTypeDefinition() : type;
        }

        private static IEnumerable<Type> GetImproperComposingTypes(this Type type)
        {
            yield return type.GetTypeDefinition();
            if (type.IsGenericType)
            {
                foreach (var argumentType in type.GetGenericArguments())
                {
                    foreach (var t in argumentType.GetImproperComposingTypes()) yield return t;
                }
            }
        }

        private static Dictionary<Type, Type> GetInferenceMap(IEnumerable<ParameterInfo> parameters, Type[] types)
        {
            var genericArgumentsMap = new Dictionary<Type, Type>();
            var match = parameters.All(
                parameter => GetImproperComposingTypes(parameter.ParameterType)
                                 .Zip(types[parameter.Position].GetImproperComposingTypes(),
                                      (t, t2) => new {Item1 = t, Item2 = t2})
                                 .All(a => {
                                          if (!a.Item1.IsGenericParameter) return a.Item1 == a.Item2;
                                          if (genericArgumentsMap.ContainsKey(a.Item1))
                                              return genericArgumentsMap[a.Item1] == a.Item2;
                                          genericArgumentsMap[a.Item1] = a.Item2;
                                          return true;
                                      }));
            return match ? genericArgumentsMap : null;
        }

        public static IEnumerable<Member> GetExtensionMethods(string name, Assembly assembly, Type[] parameters)
        {
            var res = from t in assembly.GetTypes()
                      where t.IsAbstract
                      from m1 in t.GetMethods(BindingFlags.Public | BindingFlags.Static)
                      where m1.Name == name
                      where m1.IsDefined(typeof (ExtensionAttribute), true)
                      select (MemberInfo)m1;

            return from m in res
                   let m2 = ProcessMemeber(m, parameters, true)
                   where m2 != null
                   select m2;
        }

        public static IEnumerable<Member> GetStaticMembers(string name, Type type, Type[] parameters)
        {
            var members = from m in type.GetMember(name, MemberTypes.Method | MemberTypes.Property,
                                                       BindingFlags.Public | BindingFlags.Static)
                             select m;

            return from m in members
                   let m2 = ProcessMemeber(m, parameters, false)
                   where m2 != null
                   select m2;
        }

        public static IEnumerable<Member> GetInstanceMembers(string name, Type type, Type[] parameters)
        {
            var methods = from m in type.GetMember(name, MemberTypes.Method | MemberTypes.Property,
                                                       BindingFlags.Public | BindingFlags.Instance)
                             select m;

            return from m in methods
                   let m2 = ProcessMemeber(m, parameters, false)
                   where m2 != null
                   select m2;
        }

        private static Member ProcessMemeber(MemberInfo member, Type[] parameters, bool extensionMethod)
        {
            if (member is MethodInfo)
            {
                var method = ResolveMethod((MethodInfo)member, parameters);
                if (method == null) return null;
                if (extensionMethod)
                    return new ExtensionMethod(method);
                return new Method(method);
            }
            if (member is PropertyInfo)
                return new Method(member);

            return null;
        }

        private static MethodInfo ResolveMethod(MethodInfo method, Type[] types)
        {
            var parameters = method.GetParameters();
            if ( parameters.Length != types.Length)
                return null;

            if (!method.IsGenericMethodDefinition) return method;

            var map = GetInferenceMap(parameters, types);
            if (map == null) return null;

            var arguments = method.GetGenericArguments();
            if (arguments.Length != map.Keys.Count)
                return null;

            var typeArguments = arguments.Select(t => map[t]).ToArray();
            return method.MakeGenericMethod(typeArguments);
        }

        //public static MethodInfo[] MakeGenericMethod(this Type type, string name, BindingFlags flags, Type[] types)
        //{
        //    var methods = from method in type.GetMethods(flags)
        //                  where method.Name == name
        //                  let parameters = method.GetParameters()
        //                  where parameters.Length == types.Length
        //                  let genericArgumentsMap = GetInferenceMap(parameters, types)
        //                  where genericArgumentsMap != null
        //                  where method.GetGenericArguments().Length == genericArgumentsMap.Keys.Count()
        //                  select new
        //                             {
        //                                 method,
        //                                 genericArgumentsMap
        //                             };

        //    return methods.Select(m => m.method.IsGenericMethodDefinition
        //                                   ?
        //                                       m.method.MakeGenericMethod(
        //                                           m.method.GetGenericArguments()
        //                                               .Map(m.genericArgumentsMap).ToArray())
        //                                   : m.method)
        //        .ToArray();
        //}

        //public static Type[] Map(this Type[] source, Dictionary<Type, Type> map)
        //{
        //    var r = from t in source
        //            select map[t];

        //    return r.ToArray();
        //}

        private static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> func)
        {
            var ie1 = first.GetEnumerator();
            var ie2 = second.GetEnumerator();

            while (ie1.MoveNext() && ie2.MoveNext())
                yield return func(ie1.Current, ie2.Current);
        } 
    }
}