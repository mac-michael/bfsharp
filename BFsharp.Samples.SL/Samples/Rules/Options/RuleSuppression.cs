using BFsharp.AOP;

namespace BFsharp.Samples.SL
{
    [NotifyPropertyChanged]
    [Sample(@"Rules\Options\Suppression", Code.RuleSuppression)]
    public class RuleSuppression : EntityBase<RuleSuppression>
    {
        public RuleSuppression()
        {
            Rate = 0.22m;
            Net = 1;
        }
        public decimal Rate { get; set; }
        public decimal Net { get; set; }
        public decimal Gross { get; set; }

        [RuleInit]
        public void RuleInit()
        {
            #region Code

            var r= Extensions
                .CreateBusinessRule(e => (e.Rate + 1)*e.Net, e => e.Gross)
                .Start();

            var r2 =Extensions
                .CreateBusinessRule(e => e.Gross/(e.Rate + 1), e => e.Net)
                .Start();

            r.MutuallySuppressedBy(r2);
            r.Evaluate();

            #endregion

        }
    }
}