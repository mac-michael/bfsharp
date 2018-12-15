using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BFsharp
{
    public class ReflectionHelper
    {
        public static IEnumerable<MethodInfo> GetMethods<T>()
        {
            return typeof (T).GetMethods(BindingFlags.Instance | BindingFlags.Static
                                         | BindingFlags.Public | BindingFlags.FlattenHierarchy);
        }

        public static IEnumerable<MethodInfo> GetMethodsWithAttributeOfType<T, TAttribute>()
        {
            return GetMethods<T>().Where(m => m.IsDefined(typeof (TAttribute), true));
        }

        public static IEnumerable<PropertyInfo> GetProperties<T>()
        {
            return typeof (T).GetProperties(BindingFlags.Instance | BindingFlags.Public
                                            | BindingFlags.FlattenHierarchy);
        }

        public static bool IsMethod(MethodInfo method, bool isStatic, Type returnType, params Type[] paramTypes)
        {
            if (method.IsStatic != isStatic)
                return false;

            if (method.ReturnType != returnType)
                return false;

            var parameters = method.GetParameters();
            if (parameters.Length != paramTypes.Length)
                return false;

            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].ParameterType != paramTypes[i])
                    return false;
            }

            return true;
        }
    }
}