using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class ExtendedPropertiesDependencyTests
    {
        [Test]
        public void ExtendedPropertyInBusinessRule()
        {
            var e = new DynamicEntity();
            e.Extensions.CreateBusinessRule(
                en => en.Extensions.DynamicProperties.GetProperty<int>("Number") + 1,
                en => en.Number2)
                .Enable();

            e.Extensions.DynamicProperties.SetProperty("Number", 4);

            e.Number2.ShouldEqual(5);
        }

        [Test]
        public void ExtendedPropertyInBusinessRuleIndexer()
        {
            var e = new DynamicEntity();
            e.Extensions.CreateBusinessRule(
                en => (int)en.Extensions.DynamicProperties["Number"] + 1,
                en => en.Number2).Enable();

            e.Extensions.DynamicProperties.SetProperty("Number", 4);

            e.Number2.ShouldEqual(5);
        }

        [Test]
        public void ExtendedPropertyInFormula()
        {
            var e = new DynamicEntity();
            e.Extensions.CreateBusinessRule("Number2=Number+1").Enable();

            e.Extensions.DynamicProperties.SetProperty("Number", 7);

            e.Number2.ShouldEqual(8);
        }

        [Test]
        public void ExtendedPropertyInBusinessRuleSet()
        {
            var e = new DynamicEntity();
            e.Extensions.CreateBusinessRule( en => en.Number2 + 1,
                en => en.Extensions.DynamicProperties.GetProperty<int>("Number"))
                .Enable();

            e.Number2 = 4;

            e.Extensions.DynamicProperties.GetProperty<int>("Number").ShouldEqual(5);
        }

        [Test]
        public void ExtendedPropertyInBusinessRuleIndexerSet()
        {
            var e = new DynamicEntity();
            e.Extensions.CreateBusinessRule(
                en => en.Number2 + 1,
                en => en.Extensions.DynamicProperties["Number"])
                .Enable();

            e.Number2 = 4;

            e.Extensions.DynamicProperties.GetProperty<int>("Number").ShouldEqual(5);
        }

        [Test]
        public void ExtendedPropertyInFormulaSet()
        {
            var e = new DynamicEntity();
            e.Extensions.CreateBusinessRule("Number=Number2+1")
                .Enable();

            e.Number2 = 4;

            e.Extensions.DynamicProperties.GetProperty<int>("Number").ShouldEqual(5);
        }
    }
}