using BFsharp.AOP;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class ValidationRuleTests
    {
        [Test]
        public void BrokenRuleMessageAndSeverity()
        {
            var e = new Entity();
            e.Extensions.CreateValidationRule(en => en.Name == "abc")
                .WithMessage("info")
                .WithSeverity(BrokenRuleSeverity.Info)
                .Enable();

            e.Extensions.BrokenRules.Count.ShouldEqual(1);

            e.Extensions.BrokenRules[0].Message.ShouldEqual("info");
            e.Extensions.BrokenRules[0].Severity.ShouldEqual(BrokenRuleSeverity.Info);
        }

        [Test]
        public void RemoveBrokenRuleWhenRuleRemoved()
        {
            var e = new Entity();
            var rule = e.Extensions.CreateValidationRule(en => en.Name == "abc")
                .Start();

            e.Extensions.BrokenRules.Count.ShouldEqual(1);

            e.Extensions.Rules.Remove(rule);
            e.Extensions.BrokenRules.Count.ShouldEqual(0);
        }

        [Test]
        public void BrokenRuleUpdateMessage()
        {
            var e = new Entity();
            e.Extensions.CreateValidationRule(en => en.Name == "abc")
                .WithLocalizableMessage(en=>e.Name)
                .Enable();

            e.Extensions.BrokenRules[0].Message.ShouldEqual(null);

            e.Name = "Abc";

            e.Extensions.BrokenRules[0].Message.ShouldEqual("Abc");
            e.Name = "abc";
            e.Extensions.IsValid.ShouldBeTrue();
        }

        [Test]
        public void ValidateRuleAfterAdd()
        {
            var e = new Entity();
            var rule = e.Extensions.CreateValidationRule(en => en.Name == "abc");

            e.Extensions.BrokenRules.Count.ShouldEqual(0);
            rule.Enable();
            e.Extensions.BrokenRules.Count.ShouldEqual(1);
        }

        [Test]
        public void FuncValidationRule()
        {
            var e = new Entity();
            e.Extensions.CreateValidationRule(en => en.Name == "yol").Start();

            e.Name = "abc";
            e.Extensions.BrokenRules.Count.ShouldEqual(1);
            
            e.Name = "yol";
            e.Extensions.BrokenRules.Count.ShouldEqual(0);
        }

        [Test]
        public void TwoFuncValidationRules()
        {
            var e = new Entity{Child = new Entity()};
            e.Extensions.CreateValidationRule(en => en.Name == "yol").Start();
            e.Extensions.CreateValidationRule(en => en.Child.Name == "yol").Start();

            e.Extensions.BrokenRules.Count.ShouldEqual(2);

            e.Name = "yol";
            e.Child = new Entity();
            e.Extensions.BrokenRules.Count.ShouldEqual(1);

            e.Child.Name = "yol";
            e.Extensions.BrokenRules.Count.ShouldEqual(0);
        }

        [Test]
        public void MultilevelFuncValidationRule()
        {
            var e = new Entity
                        {
                            Child = new Entity
                                        {
                                            Child=new Entity()
                                        }
                        };
            
            e.Extensions.CreateValidationRule(en => en.Child.Child.Name == "yol").Start();
            
            e.Child = new Entity{ Child = new Entity()};

            e.Child.Child.Name = "abc";

            e.Extensions.BrokenRules.Count.ShouldEqual(1);
        }

        [NotifyPropertyChanged]
        public class A: EntityBase<A>
        {
            [Required]
            public string Text { get; set; }
            [Required]
            public A Ref { get; set; }
            [Required]
            public int Number { get; set; }
        }

        [Test]
        public void RequiredValidation()
        {
            var a = new A();
            a.Extensions.InitializeRules();
            a.Extensions.Validate();
        }
    }
}