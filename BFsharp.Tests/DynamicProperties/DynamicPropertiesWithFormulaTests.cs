using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class DynamicPropertiesWithFormulaTests
    {
        [Test]
        public void Test()
        {
            var e = new Entity();
            e.Extensions.AddProperty<int>("ExtendedNumber");
            e.Extensions.CreateBusinessRule("ExtendedNumber=Number+Number2").Start();
            
            e.Number = 1;
            e.Number2 = 2;

            e.Extensions.DynamicProperties["ExtendedNumber"].ShouldEqual(3);
        }

        [Test]
        public void TestDynamic()
        {
            var e = new Entity();
            e.Extensions.AllowDynamicProperties();

            e.Extensions.DynamicProperties["XX"] = 4;
            var r = e.Extensions.CreateBusinessRule("ExtendedNumber=XX+Number2").Start();
            e.Extensions.DynamicProperties["ExtendedNumber"] = 4;
            r.Evaluate();
        }
    }
}