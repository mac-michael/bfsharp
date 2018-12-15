using NUnit.Framework;
using System.Linq;

namespace BFsharp.Tests
{
    [TestFixture]
    public class EntityPrototypTests
    {
        [Test]
        public void Simple()
        {
            var e = new Entity();
            e.Extensions.CreateBusinessRule(x => x.Number + x.Number2, x => x.Number3).Start();
            e.Extensions.AllowDynamicProperties();
            e.Extensions.AddProperty<string>("abc");

            var e2 = new Entity();
            e2.Extensions.ApplyPrototype(e.Extensions);

            e2.Number = 4;
            e2.Number3.ShouldEqual(4);
            e2.Extensions.DynamicProperties.PropertiesMetadata
                .FirstOrDefault(x => x.Name == "abc").ShouldNotBeNull();
        }
    }
}