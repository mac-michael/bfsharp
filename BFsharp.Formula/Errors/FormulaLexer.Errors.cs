using System;
using System.Collections.Generic;

namespace BFsharp.Formula
{
    public partial class FormulaLexer
    {
        private readonly List<ErrorInfo> _errors = new List<ErrorInfo>();
        public IEnumerable<ErrorInfo> GetErrors()
        {
            return _errors;    
        }

        public override void ReportError(Antlr.Runtime.RecognitionException e)
        {
            _errors.Add(new ErrorInfo
                            {
                                Text = GetErrorHeader(e) + " " + GetErrorMessage(e, TokenNames)
                            });
        }
    }
}