using System;
using BFsharp.DynamicProperties;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class StronglyTypedPropertiesTests
    {
        [Test]
        public void GetByIndexer()
        {
            var e = new Entity();
            e.Extensions.AddProperty<int>("Int");

            e.Extensions.DynamicProperties["Int"].ShouldEqual(default(int));
        }

        [Test]
        public void SetByIndexer()
        {
            var e = new Entity();
            e.Extensions.AddProperty<int>("name");

            e.Extensions.DynamicProperties["name"] = 4;
        }

        [Test]
        [ExpectedException(typeof(InvalidPropertyException))]
        public void GetNonexistingByIndexer()
        {
            var e = new Entity();
            e.Extensions.AddProperty<int>("Int2");

            object property = e.Extensions.DynamicProperties["Int"];
        }
    }
}