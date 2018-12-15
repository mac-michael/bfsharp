namespace BFsharp.Formula
{
    internal class ParameterNotFoundException : FormulaCompilerException
    {
        public ParameterNotFoundException()
        {
            
        }

        public ParameterNotFoundException(string message) : base(message)
        {
        }
    }
}