using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class DynamicPropertiesApiTests
    {
        [Test]
        public void StronglyTyped()
        {
            var e = new Entity();
            e.Extensions.AddProperty<int>("name");

            e.Extensions.DynamicProperties["name"] = 4;
        }

        [Test]
        public void TypedProxy()
        {
            var e = new Entity();
            e.Extensions.AddProperty<int>("name");

            var typedProxy = e.Extensions.DynamicProperties.TypedProxy;
        }

        [Test]
        public void DynamicTyped()
        {
            var e = new Entity();
            e.Extensions.AllowDynamicProperties();

            e.Extensions.DynamicProperties["name"] = 4;
        }
    }
}