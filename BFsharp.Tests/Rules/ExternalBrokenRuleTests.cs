using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class ExternalBrokenRuleTests
    {
        [Test, Ignore]
        public void OnChangeRemoveTest()
        {
            var e = new Entity();

            e.Extensions.AddBrokenRule(new BrokenRule("yo", BrokenRuleSeverity.Error, "Number"));

            e.Extensions.BrokenRules.Count.ShouldEqual(1);
            e.Number = 1;
            e.Extensions.BrokenRules.Count.ShouldEqual(0);
            e.Extensions.Rules.Count.ShouldEqual(0);
        }

        [Test]
        public void OnValidateRemoveTest()
        {
            var e = new Entity();

            e.Extensions.AddBrokenRule(new BrokenRule("yo", BrokenRuleSeverity.Error, "Number").WithMode(BrokenRuleRevocationStrategy.Validate));

            e.Extensions.BrokenRules.Count.ShouldEqual(1);
            e.Extensions.Validate();
            e.Extensions.BrokenRules.Count.ShouldEqual(0);
        }

        // TODO: This should be in other Test class
        [Test]
        public void RemoveRulesFromRule()
        {
            var e = new Entity();

            ActionRule<Entity> rule = null;
            ActionRule<Entity> removeRule = null;
            removeRule = e.Extensions.CreateActionRuleWithoutDependency(a =>
                                                                    {
                                                                        e.Extensions.Rules.Remove(rule);
                                                                        e.Extensions.Rules.Remove(removeRule);
                                                                    }).WithDependencies("Number");
            removeRule.Enable();

            bool ruleExecuted = false;
            rule = e.Extensions.CreateActionRuleWithoutDependency(a => { ruleExecuted = true; })
                .WithDependencies("Number");
            rule.Enable();

            e.Number = 1;

            e.Extensions.Rules.Count.ShouldEqual(0);
            ruleExecuted.ShouldBeFalse();
        }

        [Test]
        public void RemoveRulesFromRule2()
        {
            var e = new Entity();

            ActionRule<Entity> rule = null;
            ActionRule<Entity> removeRule = null;
            bool ruleExecuted = false;
            rule = e.Extensions.CreateActionRuleWithoutDependency(a => { ruleExecuted = true; })
                .WithDependencies("Number");
            rule.Enable();

            removeRule = e.Extensions.CreateActionRuleWithoutDependency(a =>
            {
                e.Extensions.Rules.Remove(rule);
                e.Extensions.Rules.Remove(removeRule);
            }).WithDependencies("Number");
            removeRule.Enable();

            e.Number = 1;

            e.Extensions.Rules.Count.ShouldEqual(0);
            ruleExecuted.ShouldBeTrue();
        }
    }
}