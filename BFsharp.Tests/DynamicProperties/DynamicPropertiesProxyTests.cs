using NUnit.Framework;
using BFsharp;

namespace BFsharp.Tests
{
    public class Class<T>
    {
        public Entity Entity { get; set; }

        public void Register()
        {
            Entity = new Entity();
            Entity.Extensions.AddProperty<Inner>("abc");
        }

        public class Inner
        {
            
        }
    }

    public class ClassA : Class<int>
    {
        
    }

    public class ClassB : Class<string>
    {

    }

    [TestFixture]
    public class DynamicPropertiesProxyTests
    {
        [Test]
        public void NestedGeneric()
        {
            var x = new ClassA();
            x.Register();
            x.Entity.Extensions.DynamicProperties["abc"] = new ClassA.Inner();
            var t = x.Entity.Extensions.DynamicProperties.TypedProxy;
            var x2 = new ClassB();
            x2.Register();
            x2.Entity.Extensions.DynamicProperties["abc"] = new ClassB.Inner();
            var t2 = x2.Entity.Extensions.DynamicProperties.TypedProxy;
        }

        [Test]
        public void Simple()
        {
            var e = new Entity();
            e.Extensions.AddProperty<int>("name");

            var p = e.Extensions.DynamicProperties.TypedProxy;
            p.ContainsProperty("name", typeof(int)).ShouldBeTrue();
        }

        [Test]
        public void Add()
        {
            var e = new Entity();
            e.Extensions.AddProperty<int>("name");

            var p = e.Extensions.DynamicProperties.TypedProxy;
            p.ContainsProperty("name", typeof(int)).ShouldBeTrue();
            p.ContainsProperty("xxx", typeof(string)).ShouldBeFalse();

            e.Extensions.AddProperty<string>("xxx");
            p = e.Extensions.DynamicProperties.TypedProxy;
            p.ContainsProperty("xxx", typeof(string)).ShouldBeTrue();
        }

        [Test]
        public void Remove()
        {
            var e = new Entity();
            e.Extensions.AddProperty<int>("name");
            e.Extensions.AddProperty<string>("xxx");
            
            var p = e.Extensions.DynamicProperties.TypedProxy;
            p.ContainsProperty("name", typeof(int)).ShouldBeTrue();
            p.ContainsProperty("xxx", typeof(string)).ShouldBeTrue();

            e.Extensions.DynamicProperties.PropertiesMetadata.RemoveAt(1);

            p = e.Extensions.DynamicProperties.TypedProxy;
            p.ContainsProperty("name", typeof(int)).ShouldBeTrue();
            p.ContainsProperty("xxx", typeof(string)).ShouldBeFalse();
        }
    }
}