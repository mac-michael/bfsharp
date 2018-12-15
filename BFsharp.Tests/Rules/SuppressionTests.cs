using System;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class SuppressionTests
    {
        [Test]
        public void SimpleSuppression()
        {
            var e = new Entity();

            var rule = e.Extensions.CreateBusinessRule(en => en.Number2 + 1, en => en.Number);
            var rule2 = e.Extensions.CreateBusinessRule(en => en.Number + 1, en => en.Number2);
            rule.Enable();
            rule2.Enable();
            rule2.Suppresses(rule);

            e.Number++;

            e.Number.ShouldEqual(1);
            e.Number2.ShouldEqual(2);
        }

        [Test]
        public void ManualSimpleSuppression()
        {
            var e = new Entity();

            var rule2 = e.Extensions.CreateBusinessRule(en => en.Number2 + 1, en => en.Number)
                .WithName("Number");
            var rule = e.Extensions.CreateBusinessRule(en => en.Number + 1, en => en.Number2)
                .WithName( "Number2")
                .Suppresses(rule2);

            rule.Enable();
            rule2.Enable();

            e.Number++;
            rule.Evaluate();

            e.Number.ShouldEqual(1);
            e.Number2.ShouldEqual(2);
        }

        [Test]
        public void SimpleSuppression2()
        {
            var e = new Entity();

            var rule = e.Extensions.CreateBusinessRule(en => en.Number2 + 1, en => en.Number);
            e.Extensions.CreateBusinessRule(en => en.Number + 1, en => en.Number2)
                .Suppresses(
                rule
                ).Enable();

            rule.Enable();

            e.Number2++;

            e.Number.ShouldEqual(2);
            e.Number2.ShouldEqual(3);
        }

        [Test]
        public void MutualSuppression()
        {
            var e = new Entity();

            var rule = e.Extensions.CreateBusinessRule(en => en.Number2 + 1, en => en.Number);
            var rule2 = e.Extensions.CreateBusinessRule(en => en.Number + 1, en => en.Number2)
                .MutuallySuppressedBy(rule);

            rule.Enable();
            rule2.Enable();

            e.Number++;
            e.Number.ShouldEqual(1);
            e.Number2.ShouldEqual(2);

            e.Number2++;
            e.Number.ShouldEqual(4);
            e.Number2.ShouldEqual(3);
        }

        [Test]
        public void DisableRecursion()
        {
            var e = new Entity();

            e.Extensions.CreateBusinessRule(en => en.Number + 1, en => en.Number)
                .DisableRecursion()
                .Start();

            e.Number++;
            e.Number.ShouldEqual(2);
        }

        [Test()]
        public void NoDisableRecursion()
        {
            var e = new Entity();
            BusinessRule<Entity, int> r = null;
            e.Extensions.CreateActionRuleWithoutDependency(en =>
                                                               {
                                                                   if (en.Number == 50)
                                                                       r.Disable();
                                                               })
                .WithDependencies(en => en.Number)
                .Start();

            r = e.Extensions.CreateBusinessRule(en => en.Number + 1, en => en.Number)
                .Start();

            e.Number++;
            e.Number.ShouldEqual(50);
        }
    }
}