using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class FormulaValidationRules
    {
        [Test]
        public void Simple()
        {
            var e = new Entity();
            e.Extensions.CreateValidationRule("Name == \"abc\"")
                .Enable();

            e.Extensions.BrokenRules.Count.ShouldEqual(1);
            e.Name = "abc";
            e.Extensions.BrokenRules.Count.ShouldEqual(0);
        }

        [Test]
        public void TwoSimple()
        {
            var e = new Entity();
            e.Extensions.CreateValidationRule("Name == \"abc\"").Enable();
            e.Extensions.CreateValidationRule("Number == 5").Enable();

            e.Extensions.BrokenRules.Count.ShouldEqual(2);
            e.Number = 5;
            e.Extensions.BrokenRules.Count.ShouldEqual(1);
        }
    }
}