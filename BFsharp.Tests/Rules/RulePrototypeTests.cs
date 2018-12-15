using System;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class RulePrototypeTests
    {
        [Test]
        public void AddFuncRuleFromPrototype()
        {
            var factory = new RuleFactory<Entity>();
            var rule = factory.CreateValidationRule(en => en.Number > 5).Start();

            var e = new Entity();
            e.Extensions.AddRuleFromPrototype(rule);

            e.Extensions.BrokenRules.Count.ShouldEqual(1);
            e.Number = 8;
            e.Extensions.BrokenRules.Count.ShouldEqual(0);
        }

        [Test]
        public void ChangeValidation()
        {
            var factory = new RuleFactory<Entity>();
            RangeValidation<int> rangeValidation = ValidationFactory.Range(0, 10, true, true);
            var rule = factory.CreateValidationRule(en => en.Number, rangeValidation)
                .Start();

            var e = new Entity {Number = -3};
            var r = (PredefinedValidationRule)e.Extensions.AddRuleFromPrototype(rule);
            e.Extensions.BrokenRules.Count.ShouldEqual(1);

            var e2 = new Entity { Number = -3 };
            e2.Extensions.AddRuleFromPrototype(rule);
            e2.Extensions.BrokenRules.Count.ShouldEqual(1);

            ((RangeValidation<int>) r.ValidationStrategy).Low = -10;
            e.Extensions.Validate();
            e2.Extensions.Validate();

            e.Extensions.BrokenRules.Count.ShouldEqual(0);
            e2.Extensions.BrokenRules.Count.ShouldEqual(1);
        }

        [Test]
        public void AddBusinessRuleFromPrototype()
        {
            var factory = new RuleFactory<Entity>();
            var rule = factory.CreateBusinessRule(en => en.Number + en.Number2,
                en=>en.Number3).Start();

            var e = new Entity();
            e.Extensions.AddRuleFromPrototype(rule);

            e.Number = 8;
            e.Number2 = 5;
            e.Number3.ShouldEqual(13);
        }

        [Test]
        public void AddActionRuleFromPrototype()
        {
            var factory = new RuleFactory<Entity>();
            var rule = factory.CreateActionRule(en => en.SetNumber2(en.Number));

            var e = new Entity();
            var r = e.Extensions.AddRuleFromPrototype(rule);

            e.Number = 8;
            e.Number.ShouldEqual(8);
            r.ShouldNotBeTheSameAs(rule);
        }
    }
}