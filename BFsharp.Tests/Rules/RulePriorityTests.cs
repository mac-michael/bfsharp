using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class RulePriorityTests
    {
        [Test]
        public void HighPriority()
        {
            var e = new Entity();
            string lastRule = null;
            e.Extensions.CreateActionRuleWithoutDependency(en => lastRule="one")
                .WithDependencies(en=>en.Number)
                .Start();

            e.Extensions.CreateActionRuleWithoutDependency(en => lastRule = "two")
                .WithDependencies(en => en.Number)
                .WithHighPriority()
                .Start();

            e.Number = 2;

            lastRule.ShouldEqual("one");
        }

        [Test]
        public void DefaultOrdering()
        {
            var e = new Entity();
            string lastRule = null;
            e.Extensions.CreateActionRuleWithoutDependency(en => lastRule = "one")
                .WithDependencies(en => en.Number)
                .Start();

            e.Extensions.CreateActionRuleWithoutDependency(en => lastRule = "two")
                .WithDependencies(en => en.Number)
                .Start();

            e.Number = 2;

            lastRule.ShouldEqual("two");
        }
    }
}