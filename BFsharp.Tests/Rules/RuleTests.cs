using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class RuleTests
    {
        [Test]
        public void Enable()
        {
            int c = 0;
            var e = new Entity();
            var rule = e.Extensions.CreateActionRuleWithoutDependency(en => {c++;})
                .WithDependencies(en=>en.Number);
            rule.Enable();

            c.ShouldEqual(0);
            e.Number = 5;
            c.ShouldEqual(1);
            rule.Disable();
            e.Number = 2;
            c.ShouldEqual(1);
        }
    }
}