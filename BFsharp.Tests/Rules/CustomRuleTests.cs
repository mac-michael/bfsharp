using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class CustomRuleTests
    {
        [Test]
        public void Test()
        {
            var e = new Entity();
            e.Extensions.CreateValidationRule(ex => ex.Name, ValidationFactory.MaxLengthR(5))
                .Enable();

            e.Extensions.BrokenRules.Count.ShouldEqual(0);
            e.Name = "abcabc";
            e.Extensions.BrokenRules.Count.ShouldEqual(1);
        }

        [Test]
        public void Email()
        {   
            var e = new Entity();
            e.Extensions.CreateValidationRule(ex => ex.Name, ValidationFactory.Mail())
                .Enable();

            e.Name = "mail@";
            e.Extensions.BrokenRules.Count.ShouldEqual(1);
            e.Name = "mail@mail.com";
            e.Extensions.BrokenRules.Count.ShouldEqual(0);
        }

        [Test]
        public void Required()
        {
            var entity = new Entity();
            entity.Extensions.CreateValidationRule(e => e.Name, ValidationFactory.Required());
            entity.Extensions.CreateValidationRule(e => e.Child, ValidationFactory.Required<Entity>());
            
            entity.Extensions.CreateValidationRule(
                e => e.Name, new StringRequiredValidation());
        }

        [Test]
        public void Range()
        {
            var entity = new Entity();
            entity.Extensions.CreateValidationRule(e => e.Number, ValidationFactory.Range(-4.0,4.0, true, true))
                .Start();

            entity.Extensions.BrokenRules.Count.ShouldEqual(0);
        }

        [Test]
        public void Range2()
        {
            var entity = new Entity();
            entity.Extensions.CreateValidationRule(e => e.DecimalNumber, ValidationFactory.Range(-4, 4, true, true))
                .Start();

            entity.Extensions.BrokenRules.Count.ShouldEqual(0);
        }
    }
}