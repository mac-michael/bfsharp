using System;
using BFsharp.Localization;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class ApiTests
    {
        [Test]
        public void ValidationRuleWithExceptionFilter()
        {
            var e = new Entity();
            
            var rule = e.Extensions.CreateValidationRule(en => en.Number < 5)
                .WithName("NumberLessThan")
                .WithMessage("Number cannot be less than 5.")
                .WithDependencies(en => en.Number, en => en.Number2)
                .WithException<InvalidOperationException>("Cannot evaluate rule.", BrokenRuleSeverity.Error)
                .Start();
            
            rule.State.ShouldEqual(RuleState.Enabled);
        }

        [Test]
        public void RuleFactory()
        {
            var e = new Entity();

            var f = new RuleFactory<Entity>();
            var rule = f.CreateValidationRule(en => en.Number < 4)
                .WithName("NumberLessThan").Start();

            e.Extensions.Rules.Add(rule);

            rule.State.ShouldEqual(RuleState.Enabled);
        }


        [Test]
        public void BusinessRuleWithExceptionFilter()
        {
            var e = new Entity();
            e.Extensions.CreateBusinessRule(en => en.Number2 / en.Number3, en=>en.Number )
                .WithName("Division")
                .WithException<InvalidOperationException>("Cannot evaluate rule.",
                                                          BrokenRuleSeverity.Error);
        }

        [Test]
        public void ValidationRule()
        {
            var e = new Entity();
            e.Extensions.CreateValidationRule(en => en.Number < 5)
                .WithName("NumberLessThan")
                .WithMessage("Number cannot be less than 5.")
                .WithOwner(en => en.Number);
        }

        [Test]
        public void CreateRules()
        {
            var factory = new RuleFactory<Entity>();

            factory.CreateActionRule(en => en.Name.ToString());
            factory.CreateActionRuleWithoutDependency(en => en.Name.ToString())
                .WithDependencies(en=>en.Number);

            factory.CreateValidationRule(en => en.Number < 10);
            factory.CreateValidationRuleWithoutDependency(en => en.Number < 10)
                .WithDependencies(en => en.Number);

            factory.CreateBusinessRule(en => en.Number2 + en.Number3, en => en.Number);
        }

        [Test]
        public void AddRules()
        {
            var e = new Entity();
            e.Extensions.CreateActionRule(en => en.Name.ToString());
            e.Extensions.CreateActionRuleWithoutDependency(en => en.Name.ToString())
                .WithDependencies(en => en.Number);

            e.Extensions.CreateValidationRule(en => en.Number < 10);
            e.Extensions.CreateValidationRuleWithoutDependency(en => en.Number < 10)
                .WithDependencies(en => en.Number);

            e.Extensions.CreateBusinessRule(en => en.Number2 + en.Number3, en => en.Number);
        }

        [Test]
        public void AddRuleFromFactory()
        {
            var factory = new RuleFactory<Entity>();
            var rule = factory.CreateValidationRule(en => en.Number < 5);
            
            var e = new Entity();
            e.Extensions.AddRule(rule);
        }

        [Test]
        public void RuleSuppression()
        {
            var e = new Entity();

            e.Extensions.CreateBusinessRule(en => en.Number2*en.Number3, en => en.Number)
                .Suppresses(
                    e.Extensions.CreateBusinessRule(
                        en => en.Number*en.Number2, en => en.Number3)
                );

            e.Extensions.CreateBusinessRule(en => en.Number2 * en.Number3, en => en.Number)
                .MutuallySuppressedBy(
                    e.Extensions.CreateBusinessRule(
                        en => en.Number * en.Number2, en => en.Number3)
                );
        }
    }
}