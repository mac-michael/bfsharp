using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class FormulaBusinessRuleTests
    {
        [Test]
        public void Formula()
        {
            var e = new Entity();
            e.Extensions.CreateBusinessRule("Number=Number2+Number3")
                .Enable();

            e.Number2 = 5;
            e.Number.ShouldEqual(5);
            e.Number3 = 5;
            e.Number.ShouldEqual(10);
        }

        [Test]
        public void FormulaNestedEvaluate()
        {
            var e = new Entity { Child = new Entity() };
            e.Extensions.CreateBusinessRule( "Child.Number=Number2 + 5")
                .Enable();

            e.Number2 = 3;

            e.Child.Number.ShouldEqual(8);
        }
    }
}