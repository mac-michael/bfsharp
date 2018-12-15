using BFsharp.AOP;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class DynamicPropertyAttributeTests
    {
        public class DynamicPropertyClass : EntityBase<DynamicPropertyClass>
        {
            public DynamicPropertyClass()
            {
                Extensions.AllowDynamicProperties();
            }
            [DynamicProperty]
            public string String { get; set; }

            [DynamicProperty]
            public int Int { get; set; }

            public string Simple { get; set; }
        }

        [Test]
        public void Abc()
        {
            var d = new DynamicPropertyClass();
            d.Extensions.AllowDynamicProperties();
            d.String = "abc";
            d.Int = 4;

            d.Extensions.DynamicProperties["String"].ShouldEqual("abc");
            d.Extensions.DynamicProperties["Int"].ShouldEqual(4);
        }
    }
}