using System;

namespace BFsharp.Formula
{
    [Flags]
    public enum FormulaCompilerBuildInfoLevels
    {
        None = 0,
        AST = 1,
        Expression = 2,
        Error = 4,
        Info = 8,
        Warning = 16,

        All = AST | Expression | Error | Info | Warning,
    }
}