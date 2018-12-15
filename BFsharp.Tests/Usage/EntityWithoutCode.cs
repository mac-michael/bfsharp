using NUnit.Framework;

namespace BFsharp.Tests
{
    public class EntityWithoutCode
    {
        public EntityComponent Component { get; set; }
        public string Text { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
    }

    [TestFixture]
    public class EntityWithoutCodeTests
    {
        [Test]
        public void Test()
        {
            var entity = new EntityWithoutCode();

            var rules = EntityExtensions.RegisterTypedObject(entity);
            rules.CreateValidationRule(e => e.Count > 0).Start();

            rules.BrokenRules.Count.ShouldEqual(1);
        }
    }
}