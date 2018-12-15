using System;
using System.Collections.Generic;

namespace BFsharp.Formula
{
    public class AggregateCallProvider : ICallProvider
    {
        public AggregateCallProvider()
        {
            CallProviders = new List<ICallProvider>();
        }

        public List<ICallProvider> CallProviders { get; private set; }
        public AggregateCallProvider Register(ICallProvider provider)
        {
            CallProviders.Add(provider);
            return this;
        }

        public Member FindMethod(Type thisType, string methodName, Type[] methodArguments)
        {
            foreach (var callProvider in CallProviders)
            {
                var method = callProvider.FindMethod(thisType, methodName, methodArguments);
                if (method != null)
                    return method;
            }

            return null;
        }
    }
}