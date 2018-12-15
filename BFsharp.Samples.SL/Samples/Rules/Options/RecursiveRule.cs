using BFsharp.AOP;

namespace BFsharp.Samples.SL
{
    [NotifyPropertyChanged]
    [Sample(@"Rules\Options\Recursion", Code.RecursiveRule)]
    public class RecursiveRule : EntityBase<RecursiveRule>
    {
        public int Value { get; set; }
        public int Value2 { get; set; }

        [RuleInit]
        public void RuleInit()
        {
            #region Code

            Extensions
                .CreateBusinessRule(e => e.Value + 1, e => e.Value)
                .DisableRecursion()
                .Start();

            #endregion

        }
    }
}