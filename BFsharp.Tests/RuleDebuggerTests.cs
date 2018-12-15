using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class RuleDebuggerTests
    {
        [Test]
        public void Test()
        {
            Entity e = new Entity();
            var r = e.Extensions.CreateBusinessRule(en => en.Number + 4, en => en.Number2)
                .Start();

            DebugHelpers h = new DebugHelpers();
            h.LogRuleExecution(r);
        }
    }
}