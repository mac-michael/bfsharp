using BFsharp.AOP;

namespace BFsharp.Samples.SL
{
    [NotifyPropertyChanged]
    [Sample(@"Rules\ValidationRule", Code.ValidationRuleEntity)]
    public class ValidationRuleEntity : EntityBase<ValidationRuleEntity>
    {
        public int Value { get; set; }
        public int Value2 { get; set; }
        public int Total { get; set; }

        [RuleInit]
        public void RuleInit()
        {
#region Code
            Extensions
                .CreateValidationRule(e => e.Value + e.Value2 == e.Total)
                .WithMessage("Total should equals Value + Value2")
                .WithSeverity(BrokenRuleSeverity.Error)
                .WithOwner(e => e.Total)
                .Start();
#endregion
        }
    }
}