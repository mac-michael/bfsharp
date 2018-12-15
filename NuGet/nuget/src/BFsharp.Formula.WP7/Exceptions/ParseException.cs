using System.Collections.Generic;
using System.Text;

namespace BFsharp.Formula
{
    internal class ParseException : FormulaCompilerException
    {
        public IEnumerable<ErrorInfo> Errors { get; set; }

        internal ParseException(IEnumerable<ErrorInfo> errors) : base(ToString(errors))
        {
            Errors = errors;
        }

        private static string ToString(IEnumerable<ErrorInfo> errors)
        {
            var b = new StringBuilder();
            foreach (var error in errors)
                b.AppendLine(error.ToString());

            return b.ToString();
        }

        public override string ToString()
        {
            return ToString(Errors);
        }
    }
}