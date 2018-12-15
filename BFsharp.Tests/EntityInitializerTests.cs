using System;
using System.Collections.Generic;
using BFsharp.AOP;
using NUnit.Framework;
using System.Linq;

namespace BFsharp.Tests
{
    [NotifyPropertyChanged]
    public class RuleInitializerEntity : EntityBase
    {
        public RuleInitializerEntity()
        {
            Entities = new List<Entity>();
            Entities2 = new List<Entity>();
        }
        public int Value;
        public bool Inited;
        public static bool DecoratorExecuted;
        public IEnumerable<Entity> Entities { get; private set; }
        public List<Entity> Entities2 { get; private set; }
        public Entity Entity { get; set; }

        public Child Child { get; set; }

        [Range(-4,4)]
        public int Value2 { get; set; }

        [Range("-4.4", "3.3")]
        public decimal Value3 { get; set; }

        [Email(AllowEmpty=true)]
        public string Email { get; set; }

        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [RuleInit]
        public void RuleInit()
        {
            Inited = true;
        }

        [RuleInit]
        public static IEnumerable<Rule> RulePrototype(Type type)
        {
            var f = new RuleFactory<RuleInitializerEntity>();
            yield return f.CreateValidationRule(o => o.Value == 0);
        }

        [RuleDecorator]
        public static void RuleDecorator(Rule rule)
        {
            DecoratorExecuted = true;
            //if (rule is ValidationRule)
                //((ValidationRule) rule).WithModeAtStartup(ValidationRuleStartupMode.None);
        }
        
        [PropertiesInit]
        public void DynamicProperties()
        {
            PropertiesExecuted = true;

            Extensions.AddProperty<int>("abc")
                .AddProperty<int>("x");
        }

        public static bool PropertiesExecuted { get; set; }
    }

    public class Child : EntityBase
    {
        [IgnoreTraversal]
        public RuleInitializerEntity Parent { get; set; }
    }

    struct abc
    {
        private int a;
        private string b;
    }

    [TestFixture]
    public class EntityInitializerTests
    {
        [Test]
        public void PropertiesTest()
        {
            var e = new RuleInitializerEntity();
            e.Extensions.DynamicProperties["abc"] = 5;
            e.Extensions.DynamicProperties["x"] = 5;
            RuleInitializerEntity.PropertiesExecuted.ShouldBeTrue();
        }

        [Test]
        public void CompareTest()
        {
            var e = new RuleInitializerEntity();
            e.Extensions.InitializeRules();

            e.Password = "asd";

            //e.Extensions.Validate();
            e.Extensions.BrokenRules.Count.ShouldEqual(1);

        }

        [Test]
        public void RangeAttributeTest()
        {
            var e = new RuleInitializerEntity();
            e.Extensions.InitializeRules();
            e.Value2 = 33;
            e.Value3 = 34;
            e.Extensions.BrokenRules.Count.ShouldEqual(2);
        }


        [Test]
        public void RecursiveValidation()
        {
            var entity = new Entity();
            entity.Extensions.CreateValidationRule(en => en.Number == 0).Start();

            var e = new RuleInitializerEntity{Entity = entity};
            e.Extensions.Validate().ShouldBeTrue();

            entity.Number = 4;
            e.Extensions.Validate().ShouldBeFalse();
        }

        [Test]
        public void RecursiveIsValid()
        {
            var entity = new Entity();
            entity.Extensions.CreateValidationRule(en => en.Number == 0).Start();

            var e = new RuleInitializerEntity { Entity = entity };
            e.Extensions.IsValid.ShouldBeTrue();

            entity.Number = 4;
            e.Extensions.IsValid.ShouldBeFalse();
        }

        [Test]
        public void CollectionIsValid()
        {
            var entity = new Entity();
            entity.Extensions.CreateValidationRule(en => en.Number == 0).Start();

            var e = new RuleInitializerEntity {Entities2 = {entity}};
            e.Extensions.IsValid.ShouldBeTrue();

            entity.Number = 4;
            e.Extensions.IsValid.ShouldBeFalse();
        }

        [Test]
        public void RuleInitExecuted()
        {
            var e = new RuleInitializerEntity();
            e.Extensions.InitializeRules();
            e.Inited.ShouldBeTrue();
        }
        
        [Test]
        public void RuleInit2Executed()
        {
            try
            {
                var e = new RuleInitializerEntity();
                var c = new Child();
                c.Parent = e;
                e.Child = c;
                e.Extensions.InitializeRules();
                e.Inited.ShouldBeTrue();
            }
            catch (StackOverflowException e)
            {
                Console.WriteLine(e);
            }
        }

        [Test]
        public void RuleDecoratorExecuted()
        {
            var e = new RuleInitializerEntity();
            e.Extensions.InitializeRules();

            RuleInitializerEntity.DecoratorExecuted.ShouldBeTrue();
        }

        [Test]
        public void AttributeRules()
        {
            var e = new RuleInitializerEntity();
            e.Extensions.InitializeRules();
            e.Email = "a";
            e.Extensions.BrokenRules.ShouldContains("Email", 1);
            e.Email = "a@a.com";
            e.Extensions.BrokenRules.ShouldContains("Email", 0);
        }
    }

    public static class TestExtensions
    {
        public static void ShouldContains(this BrokenRuleCollection brokenRuleCollection, string owner, int brokenRulesCount)
        {
            brokenRuleCollection.Count(b => b.Owner == owner).ShouldEqual(brokenRulesCount);
        }
    }
}