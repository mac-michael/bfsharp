using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class OneTimeTests
    {
        [Test]
        public void OneTime()
        {
            var e = new Entity();
            int count = 0;
            e.Extensions.CreateActionRuleWithoutDependency(x => { count++; })
                .WithDependencies(x => x.Number)
                .WithOneTime()
                .Start();

            e.Number++;
            e.Number++;

            count.ShouldEqual(1);
            e.Extensions.Rules.Count.ShouldEqual(0);
        }
    }
}