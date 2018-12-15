using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BFsharp.Formula
{
    class LambdaParameterCallProvider : ICallProvider
    {
        public LambdaParameterCallProvider(IEnumerable<ParameterExpression> parameters)
        {
            Parameters = parameters.Select(p => new ParameterMethodBase {Parameter = p})
                .ToArray();
        }

        public ParameterMethodBase[] Parameters { get; set; }

        public Member FindMethod(Type thisType, string methodName, Type[] methodArguments)
        {
            foreach (var parameter in Parameters)
                if (methodName == parameter.Parameter.Name)
                    return parameter;

            return null;
        }
    }
}