using System;
using BFsharp.AOP;

namespace BFsharp.Samples.SL
{
    [NotifyPropertyChanged]
    [Sample(@"Rules\Options\ExceptionFilter", Code.ExceptionFilter)]
    public class ExceptionFilter : EntityBase<ExceptionFilter>
    {
        public int Value { get; set; }
        public int Value2 { get; set; }
        public int Result { get; set; }

        [RuleInit]
        public void RuleInit()
        {
            #region Code

            Extensions
                .CreateBusinessRule(e => e.Value / e.Value2, e => e.Result)
                .WithException<DivideByZeroException>("Division by zero.", BrokenRuleSeverity.Error, "Result")
                .Start();

            #endregion

        }
    }
}