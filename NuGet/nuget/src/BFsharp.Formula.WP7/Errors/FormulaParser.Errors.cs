using System;
using System.Collections.Generic;
using Antlr.Runtime;

namespace BFsharp.Formula
{
    public partial class FormulaParser
    {
        private readonly List<ErrorInfo> _errors = new List<ErrorInfo>();
        public IEnumerable<ErrorInfo> GetErrors()
        {
            return _errors;
        }

        public override void ReportError(RecognitionException e)
        {
            base.ReportError(e);
            var error = new ErrorInfo();
            error.Line = e.Line;
            error.Column = e.CharPositionInLine;

            if (e is MismatchedTokenException)
            {
                var ex = (MismatchedTokenException)e;

                error.Number = 100 + ex.Expecting;
                error.Text = GetToken(ex.Expecting) + " expected";
            }
            else if (e is NoViableAltException)
            {
                var ex = (NoViableAltException)e;

                error.Number = 200 + ex.Token.Type;
                error.Text = "Invalid expression term " + GetToken(ex.Token.Type);
            }
            else
            {
                new ErrorInfo
                    {
                        Text = GetErrorHeader(e) + " " + GetErrorMessage(e, TokenNames)
                    };
            }

            _errors.Add(error);
        }

        private string GetToken(int token)
        {
            if (token == Token.EOF)
                return "EOF";
            
            return TokenNames[token];
        }
    }
}