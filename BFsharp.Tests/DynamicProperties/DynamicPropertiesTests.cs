using BFsharp;
using BFsharp.DynamicProperties;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class DynamicPropertiesTests
    {
        [Test]
        public void GetSetIndexer()
        {
            var e = new Entity();
            e.Extensions.AllowDynamicProperties();
            e.Extensions.DynamicProperties["MyProperty"] = 5;
            e.Extensions.DynamicProperties["MyProperty"].ShouldEqual(5);
        }

        [Test]
        public void GetSetMethod()
        {
            var e = new Entity();
            e.Extensions.AllowDynamicProperties();
            e.Extensions.DynamicProperties.SetProperty("MyProperty", 5);
            e.Extensions.DynamicProperties.GetProperty<int>("MyProperty").ShouldEqual(5);
        }

        [Test]
        public void GetNonexisitngMethod()
        {
            var e = new Entity();
            e.Extensions.AllowDynamicProperties();
            e.Extensions.DynamicProperties.GetProperty<int>("MyProperty");
        }

        [Test]
        public void GetNonexisitngIndexer()
        {
            var e = new Entity();
            e.Extensions.AllowDynamicProperties();
            object property = e.Extensions.DynamicProperties["MyProperty"];
        }
    }
}