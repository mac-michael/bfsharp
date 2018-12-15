using System.Linq;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class BusinessRuleTests
    {
        [Test]
        public void BusinessRuleValidation()
        {
            var e = new Entity{Number = 10};
            var r = e.Extensions.CreateBusinessRule(en => en.Number2 + 5, en => en.Number)
                .WithValidation()
                .Start();

            e.Extensions.BrokenRules.Count.ShouldEqual(1);
            e.Number2 = 5;

            e.Extensions.BrokenRules.Count.ShouldEqual(0);
        }

        [Test]
        public void BusinessRuleValidationBrokenRule()
        {
            var e = new Entity { Number = 10 };
            var r = e.Extensions.CreateBusinessRule(en => en.Number2 + 5, en => en.Number)
                .WithValidation()
                .Start();
            
            e.Number2 = 3;
            var br =(BusinessRuleBrokenRule)e.Extensions.BrokenRules.First();

            br.FuncValue.ShouldEqual(8);
            br.TargetValue.ShouldEqual(10);
        }

        [Test]
        public void BusinessRuleNestedValidation()
        {
            var e = new Entity { Child = new Entity {Number = 10} };
            e.Extensions.CreateBusinessRule(en => en.Number2 + 5, en => en.Child.Number)
                .WithValidation()
                .Enable();

            e.Extensions.BrokenRules.Count.ShouldEqual(1);
            e.Number2 = 5;

            e.Extensions.BrokenRules.Count.ShouldEqual(0);
        }

        [Test]
        public void BusinessRuleEvaluate()
        {
            var e = new Entity();
            e.Extensions.CreateBusinessRule(en => en.Number2 + 5, en => en.Number)
                .Enable();

            e.Number2 = 5;

            e.Number.ShouldEqual(10);
        }

        [Test]
        public void BusinessRuleNestedEvaluate()
        {
            var e = new Entity {Child = new Entity()};
            e.Extensions.CreateBusinessRule(en => en.Number2 + 5, en => en.Child.Number)
                .Enable();

            e.Number2 = 3;

            e.Child.Number.ShouldEqual(8);
        }

        [Test] // ??
        public void NullObject()
        {
            var e = new Entity { Child = new Entity() };
            e.Extensions.CreateBusinessRule(en => "asd", en => en.Name)
                .Enable();
        }

        [Test] // ??
        public void DefaultValue()
        {
            var e = new Entity { Child = new Entity() };
            e.Extensions.CreateBusinessRule(en => 5, en => en.Number)
                .Enable();
        }

        [Test]
        public void BrokeRuleOnTargetSet()
        {
            var e = new Entity { Child = new Entity() };
            e.Extensions.CreateBusinessRule(en => 0, en => en.Number)
                .Enable();

            e.Number = 3;

            e.Extensions.BrokenRules.Count.ShouldEqual(1);
            e.Number.ShouldEqual(3);
        }

        [Test]
        public void OverrideOnTargetSet()
        {
            var e = new Entity { Child = new Entity() };
            e.Extensions.CreateBusinessRule(en => 5, en => en.Number)
                .WithOverride()
                .Enable();

            e.Number = 3;

            e.Extensions.BrokenRules.Count.ShouldEqual(0);
            e.Number.ShouldEqual(5);
        }
    }
}