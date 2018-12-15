using System;
using System.Reflection;
using BFsharp.AOP;

namespace BFsharp.Samples.SL.Samples
{
    [NotifyPropertyChanged]
    [Sample(@"Samples\UserRegistrationForm", Code.UserRegistrationForm)]
    public class UserRegistrationForm : EntityBase<UserRegistrationForm>
    {
        public UserRegistrationForm()
        {
            Birthday = DateTime.Now;
        }
        [Email, Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

        public DateTime Birthday { get; set; }

        [ShouldBe(true)]
        public bool AcceptLicence { get; set; }

        [RuleInit]
        public void RuleInit()
        {
            Extensions.CreateValidationRule(r => string.IsNullOrEmpty(ConfirmPassword) || r.Password == r.ConfirmPassword)
                .WithMessage("Confirm password doesn't match.")
                .WithOwner(r=>r.ConfirmPassword)
                .Start();

            Extensions.CreateValidationRule(r => DateTime.Now.AddYears(-18) > r.Birthday)
                .WithMessage("You should be at least 18 years old.")
                .WithOwner(r=>r.Birthday) // BUG: DependencyDetection
                .Start();
        }

        [RuleDecorator]
        public static void RuleDecorator(Rule rule)
        {
            // ASP.Net validation behaviour - start validation only after first edit
            if (rule is ValidationRule)
                ((ValidationRule) rule).WithModeAtStartup(ValidationRuleStartupMode.None);
        }
    }
}