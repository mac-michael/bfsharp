using System.Globalization;
using System.Resources;
using System.Threading;
using BFsharp.Localization;
using BFsharp.Tests.Properties;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class LocalizationTests
    {
        [Test]
        public void LocalizableMessage()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("");

            var e = new Entity();
            e.Extensions.CreateValidationRule(ex => ex.Child != null)
                .WithLocalizableMessage(r => Resources.String1)
                .WithModeAtStartup(ValidationRuleStartupMode.None)
                .Start();

            e.Child = new Entity();
            e.Child = null;
            e.Extensions.BrokenRules[0].Message.ShouldEqual("Neutral");

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("pl-PL");

            e.Child = new Entity();
            e.Child = null;
            e.Extensions.BrokenRules[0].Message.ShouldEqual("Polish");
        }
        
        [Test]
        public void Message()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("");

            var e = new Entity();
            e.Extensions.CreateValidationRule(ex => ex.Child != null)
                .WithMessage(Resources.String1)
                .WithModeAtStartup(ValidationRuleStartupMode.None)
                .Start();

            e.Child = new Entity();
            e.Child = null;
            e.Extensions.BrokenRules[0].Message.ShouldEqual("Neutral");

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("pl-PL");

            e.Child = new Entity();
            e.Child = null;
            e.Extensions.BrokenRules[0].Message.ShouldEqual("Neutral");
        }

        public class TestEntity : EntityBase<TestEntity>
        {
            [Required]
            public string Required { get; set; }
        }

        public class TestEntity2 : EntityBase<TestEntity2>
        {
            [Required(MessageResourceType = typeof(Resources), MessageResourceName = "String1")]
            public string Required { get; set; }
        }

        [Test]
        public void RulePrototype()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("");

            var e = new TestEntity();
            e.Extensions.InitializeRules();
            e.Extensions.BrokenRules[0].Message.ShouldEqual("String must not be empty.");

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("pl-PL");

            e = new TestEntity();
            e.Extensions.InitializeRules();

            e.Extensions.BrokenRules[0].Message.ShouldEqual("Pole jest wymagane.");
        }

        [Test]
        public void CustomLocalizableAttribute()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("");

            var e = new TestEntity2();
            e.Extensions.InitializeRules();
            e.Extensions.BrokenRules[0].Message.ShouldEqual("Neutral");

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("pl-PL");

            e = new TestEntity2();
            e.Extensions.InitializeRules();

            e.Extensions.BrokenRules[0].Message.ShouldEqual("Polish");
        }
    }
}