using System;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class ExceptionFilterTests
    {
        [Test]
        public void BusinessRuleSimpleFilter()
        {
            var e = new Entity();
            const string message = "Division by zero.";

            e.Extensions.CreateBusinessRule(en => en.Number2 / en.Number3, en => en.Number)
                .WithException<DivideByZeroException>(message, BrokenRuleSeverity.Error).Enable();

            e.Number2 = 10;
            e.Extensions.BrokenRules.Count.ShouldEqual(1);
            e.Extensions.BrokenRules[0].Message.ShouldEqual(message);

            e.Number3 = 5;
            e.Extensions.BrokenRules.Count.ShouldEqual(0);
            e.Number.ShouldEqual(2);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RuleWithoutExceptionFilter()
        {
            var e = new Entity();
            var r = e.Extensions.CreateActionRuleWithoutDependency(
                en => { throw new InvalidOperationException(); });

            r.Invoke();
        }

        [Test]
        public void FuncValidationSimpleFilter()
        {
            var e = new Entity();
            const string message = "Division by zero.";

            e.Extensions.CreateValidationRule(en => en.Number2 / en.Number3== en.Number)
                .WithException<DivideByZeroException>(message, BrokenRuleSeverity.Error).Enable();

            e.Number2 = 10;
            e.Extensions.BrokenRules.Count.ShouldEqual(2);
            //e.Extensions.BrokenRules[0].Message.ShouldEqual(message);

            e.Number3 = 5;
            e.Number = 2;
            e.Extensions.BrokenRules.Count.ShouldEqual(0);
            e.Number.ShouldEqual(2);
        }

        [Test]
        public void ActionSimpleFilter()
        {
            var e = new Entity();
            const string message = "Division by zero.";

            var rule = e.Extensions.CreateActionRuleWithoutDependency(en => { en.Number = en.Number2/en.Number3; })
                .WithException<DivideByZeroException>(message, BrokenRuleSeverity.Error);
            rule.Enable();

            rule.Invoke();
            e.Extensions.BrokenRules.Count.ShouldEqual(1);
            e.Extensions.BrokenRules[0].Message.ShouldEqual(message);

            e.Number2 = 10;
            e.Number3 = 5;
            rule.Invoke();
            e.Extensions.BrokenRules.Count.ShouldEqual(0);
        }

        [Test]
        public void ActionFilter()
        {
            var e = new Entity();
            const string message = "Division by zero.";

            var rule = e.Extensions.CreateActionRuleWithoutDependency(en => {
                                                 en.Number = en.Number2/en.Number3;
                                                 throw new InvalidOperationException();
                                             })
                .WithException<DivideByZeroException>(message, BrokenRuleSeverity.Error)
                .WithException<InvalidOperationException>("2", BrokenRuleSeverity.Warning);

            rule.Enable();

            rule.Invoke();
            e.Extensions.BrokenRules.Count.ShouldEqual(1);
            e.Extensions.BrokenRules[0].Message.ShouldEqual(message);

            e.Number2 = 10;
            e.Number3 = 5;
            rule.Invoke();
            e.Extensions.BrokenRules.Count.ShouldEqual(1);
            e.Extensions.BrokenRules[0].Message.ShouldEqual("2");
        }
    }
}