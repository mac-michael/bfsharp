using System;

namespace BFsharp.Formula
{
    public abstract class FormulaCompilerException : Exception
    {
        protected FormulaCompilerException() {}
        protected FormulaCompilerException(string message) : base(message){}

        protected FormulaCompilerException(string message, Exception innerException) : 
            base(message,innerException){}
    }
}