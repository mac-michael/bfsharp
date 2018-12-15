using System;
using System.Linq.Expressions;
using Antlr.Runtime.Tree;

namespace BFsharp.Formula
{
    public interface IASTTranslator
    {
        Expression<T> Translate<T>(CommonTree lambdaTree, 
            LambdaTypeDefinition definition,
            ICallProvider callProvider,
            BuildInfo buildInfo);
    }
}
