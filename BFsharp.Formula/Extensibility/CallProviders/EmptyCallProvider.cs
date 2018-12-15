using System;

namespace BFsharp.Formula
{
    public class EmptyCallProvider : ICallProvider
    {
        public Member FindMethod(Type thisType, string methodName, Type[] methodArguments)
        {
            return null;
        }

        public static EmptyCallProvider Empty = new EmptyCallProvider();
    }
}