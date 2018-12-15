using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BFsharp.Formula
{
    public class AssemblyCallProvider : ICallProvider
    {
        private List<string> _usingDirectives;
        public List<string> UsingDirectives
        {
            get
            {
                if (_usingDirectives == null)
                    _usingDirectives = new List<string>();
                return _usingDirectives;
            }
        }

        public AssemblyCallProvider Using(params string[] @namespaces)
        {
            foreach (var @namespace in @namespaces)
                UsingDirectives.Add(@namespace);

            return this;
        }

        public AssemblyCallProvider AddAssembly(params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
                Assemblies.Add(assembly);

            return this;
        }

        public AssemblyCallProvider AddAssembly(params string[] assemblies)
        {
            foreach (var assembly in assemblies)
                Assemblies.Add(Assembly.Load(assembly));

            return this;
        }

        private List<Assembly> _assemblies;
        public List<Assembly> Assemblies
        {
            get
            {
                if (_assemblies == null)
                    _assemblies = new List<Assembly>(); 
                return _assemblies;
            }
        }

        public bool EnableExtensionMethods { get; set; }

        public AssemblyCallProvider WithExtensionMethods()
        {
            EnableExtensionMethods = true;
            return this;
        }

        public Member FindMethod(Type thisType, string methodName, Type[] methodArguments)
        {
            var methods = FindMembers(thisType, methodName, methodArguments);
            
            return ChooseOverload( thisType, methodArguments, methods);
        }

        protected virtual Member ChooseOverload(Type thisType, Type[] methodArguments, Member[] methods)
        {
            foreach (var method in methods)
            {
                if (method is ExtensionMethod)
                {
                    var m = (ExtensionMethod) method;
                    if (Helpers.TypeArrayEquals(m.Method.GetParameters().Select(p => p.ParameterType).ToArray(),
                        Helpers.Combine(thisType, methodArguments)))
                        return method;
                }
                else if (Helpers.TypeArrayEquals(method.Parameteres, methodArguments))
                    return method;
            }

            return null;
        }

        protected Member[] FindMembers(Type thisType, string methodName, Type[] parameterTypes)
        {
            if (thisType == null)
                return GetStaticMembers(methodName, parameterTypes).ToArray();

            return GetInstanceMembers(thisType, methodName, parameterTypes).ToArray();
        }

        private IEnumerable<Member> GetInstanceMembers(Type type, string methodName, Type[] parameterTypes)
        {
            var methods = TypeExtensions.GetInstanceMembers(methodName, type, parameterTypes);
            foreach (var m in methods)
                yield return m;

            if (EnableExtensionMethods) 
            {
                Type[] parameters = Helpers.Combine(type, parameterTypes);
                
                foreach (var assembly in Assemblies)
                {
                    var res = TypeExtensions.GetExtensionMethods(methodName, assembly, parameters);
                    foreach (var method in res)
                        yield return method;
                }
            }
        }

        private IEnumerable<Member> GetStaticMembers(string methodName, Type[] parameterTypes)
        {
            var pos = methodName.LastIndexOf('.');
            if (pos < 0) yield break;

            string typeName = methodName.Substring(0, pos);
            string methodName2 = methodName.Substring(pos + 1);

            foreach (var assembly in Assemblies)
            {
                foreach (var usingDirective in UsingDirectives.Union(new[] { "" }))
                {
                    var name = string.IsNullOrEmpty(usingDirective) ? typeName : usingDirective + "." + typeName;

                    var t = assembly.GetType(name);
                    if (t != null)
                    {
                        var methods = TypeExtensions.GetStaticMembers(methodName2, t, parameterTypes);
                        foreach (var method in methods)
                            yield return method;
                    }
                }
            }
        }
    }
}