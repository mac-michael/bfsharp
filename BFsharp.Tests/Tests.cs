using NUnit.Framework;

namespace BFsharp.Tests
{
    public class Entity2 : EntityBase
    {
        public string Text { get; set; }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        public void A()
        {
            var e = new Entity();
            e.Extensions.IsValid.ShouldBeTrue();

            Entity child;
            e.Collection.Add(child = new Entity());

            child.Extensions.CreateValidationRule(x => x.Collection.Count == 1)
                .Start();

            e.Extensions.IsValid.ShouldBeFalse();
        }
    }
}