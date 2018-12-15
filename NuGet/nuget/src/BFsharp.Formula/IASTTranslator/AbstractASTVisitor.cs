using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Antlr.Runtime.Tree;

namespace BFsharp.Formula
{
    public abstract class AbstractASTVisitor : IASTTranslator
    {
        protected ParameterExpression This { get; set; }
        protected List<ParameterExpression> Parameters { get; set; }
        protected ICallProvider CallProvider { get; set; }
        protected LambdaTypeDefinition Definition { get; set; }
        protected BuildInfo BuildInfo { get; set; }

        public Expression<T> Translate<T>(CommonTree lambdaTree,
                                          LambdaTypeDefinition definition,
                                          ICallProvider callProvider,
                                          BuildInfo buildInfo)
        {
            CallProvider = callProvider ?? EmptyCallProvider.Empty;
            Definition = definition;
            BuildInfo = buildInfo;

            // Prepare params
            Parameters = definition.Params.Select(
                p => Expression.Parameter(p.ParamType, p.Name)).ToList();

            // Prepare this param
            if (definition.ThisType != null)
            {
                var thisParam = Expression.Parameter(definition.ThisType, "this");
                This = thisParam;
                Parameters.Insert(0, thisParam);
            }
            else
                This = null;

            Expression<T> expression = null;
            try
            {
                expression = TranslateInternal<T>(lambdaTree);
            }
            catch (FormulaCompilerException e)
            {
                BuildInfo.Log(e.Message, FormulaCompilerBuildInfoLevels.Error);
            }

            return expression;
        }

        protected abstract Expression<T> TranslateInternal<T>(CommonTree lambdaTree);
    }
}