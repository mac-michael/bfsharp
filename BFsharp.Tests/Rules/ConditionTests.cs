using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class ConditionTests
    {
        [Test]
        public void Default()
        {
            var e = new Entity();
            int n = 0;
            var rule = e.Extensions.CreateActionRuleWithoutDependency(en => { n++; })
                .WithDependencies(en => en.Number2)
                .Start();

            rule.Invoke();

            n.ShouldEqual(1);
        }

        [Test]
        public void IsOfType()
        {
            var e = new Entity();
            int n = 0;
            var rule = e.Extensions.CreateActionRuleWithoutDependency(en => { n++; })
                .WithCondition(x=>
                                   {
                                       Assert.IsInstanceOf<Entity>(x);
                                       return true;
                                   })
                .Start();

            rule.Invoke();
        }

        [Test]
        public void Action()
        {
            var e = new Entity();
            e.Extensions.CreateActionRule(en => Assert.Fail())
                .WithCondition(r=>false)
                .WithDependencies(en => en.Number2).Start();

            e.Number2++;
        }

        [Test]
        public void ForceAction()
        {
            var e = new Entity();
            int n = 0;
            var rule = e.Extensions.CreateActionRuleWithoutDependency(en =>{n++;})
                .WithCondition(r => false)
                .WithDependencies(en => en.Number2).Start();

            e.Number2++;

            rule.Invoke(true);

            n.ShouldEqual(1);
        }

        [Test]
        public void ValidationRule()
        {
            var e = new Entity();
            var rule = e.Extensions.CreateValidationRule(en => false)
                .WithCondition(r => false)
                .WithDependencies(en => en.Number2).Start();

            e.Number2++;

            rule.BrokenRule.ShouldBeNull();
        }

        [Test]
        public void ValidationRule2()
        {
            var e = new Entity();
            bool ok = false;
            var rule = e.Extensions.CreateValidationRule(en => ok)
                .WithDependencies(en => en.Number2).Start();

            e.Number2++;

            rule.BrokenRule.ShouldNotBeNull();

            ok = true;
            rule.WithCondition(r => false);

            rule.Validate();
            rule.BrokenRule.ShouldNotBeNull();
        }

        [Test]
        public void ForceValidationRule()
        {
            var e = new Entity();
            var rule = e.Extensions.CreateValidationRule(en => false)
                .WithCondition(r => false)
                .WithDependencies(en => en.Number2).Start();

            e.Number2++;

            rule.Validate(true);
            
            rule.BrokenRule.ShouldNotBeNull();
        }

        [Test]
        public void BusinessRule()
        {
            var e = new Entity();
            e.Extensions.CreateBusinessRule(en => 5, en=>en.Number)
                .WithCondition(r => false)
                .WithDependencies(en => en.Number2).Start();

            e.Number2++;

            e.Number.ShouldEqual(0);
        }

        [Test]
        public void ForceBusinessRule()
        {
            var e = new Entity();
            var rule = e.Extensions.CreateBusinessRule(en => 5, en => en.Number)
                .WithCondition(r => false)
                .WithDependencies(en => en.Number2).Start();

            e.Number2++;

            e.Number.ShouldEqual(0);

            rule.Evaluate(true);
            e.Number.ShouldEqual(5);
        }
    }
}