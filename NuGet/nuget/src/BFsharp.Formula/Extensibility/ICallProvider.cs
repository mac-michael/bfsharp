using System;
using System.Collections.Generic;

namespace BFsharp.Formula
{
    public interface ICallProvider
    {
        Member FindMethod(Type thisType, string methodName, Type[] methodArguments);
    }

    public abstract class CallProviderBase : ICallProvider
    {
        public Member FindMethod(Type thisType, string methodName, Type[] methodArguments)
        {
            MethodName = methodName;
            Params = methodArguments;

            foreach (var method in GetMethods(thisType))
            {
                if (method.Name.Equals(methodName, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (Helpers.TypeArrayEquals(method.Parameteres, methodArguments))
                        return method;
                }
            }

            return null;
        }

        protected string MethodName { get; set; }
        protected Type[] Params { get; set; }

        protected abstract IEnumerable<Method> GetMethods(Type type);
    }
}