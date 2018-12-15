using BFsharp.AOP;

namespace BFsharp.Samples.SL
{
    [NotifyPropertyChanged]
    [Sample(@"Rules\BusinessRule", Code.BusinessRuleEntity)]
    public class BusinessRuleEntity : EntityBase<BusinessRuleEntity>
    {
        public int Value { get; set; }
        public int Value2 { get; set; }
        public int Total { get; set; }

        [RuleInit]
        public void RuleInit()
        {
            //Extensions.CreateBusinessRule(e => e.Value + e.Value2, e => e.Total).Start();

            Extensions.CreateBusinessRule("Total=Value+Value2").Start();
        }
    }
}