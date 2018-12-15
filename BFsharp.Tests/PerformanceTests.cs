using System;
using BFsharp.Undo;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture, Ignore]
    public class PerformanceTests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            ExtensionsOptions.CacheLambdas = true;
        }

        [Test]
        public void EntityCreation()
        {
            TestTime.Measure(() => new Entity().Extensions.ToString());
        }

        [Test]
        public void RulesWithExpressionAnalysis()
        {
            var e = new Entity();
            TestTime.Measure(() => e.Extensions.CreateValidationRule(en => en.Number < 100));
        }
        
        [Test]
        public void RulesWithDependencyAnalysis()
        {
            var e = new Entity();
            TestTime.Measure(() => e.Extensions.CreateValidationRuleWithoutDependency(en => en.Number < 100)
                                       .WithDependencies(en => en.Number));
        }
        
        [Test]
        public void RulesWithoutExpressionAnalysis()
        {
            var e = new Entity();
            TestTime.Measure(() => e.Extensions.CreateValidationRuleWithoutDependency(en => en.Number < 100)
                                       .WithDependencies("Number"));
        }

        [Test]
        public void RulesFromPrototype()
        {
            var factory = new RuleFactory<Entity>();
            var rule = factory.CreateValidationRule(en => en.Number > 5);

            var e = new Entity();
            TestTime.Measure(() => e.Extensions.AddRuleFromPrototype(rule));
        }

        [Test]
        public void RulesAdd()
        {
            var factory = new RuleFactory<Entity>();
            var rule = factory.CreateValidationRule(en => en.Number > 5);


            TestTime.Measure(() =>
                                 {
                                     var e = new Entity();
                                     e.Extensions.AddRule(rule);
                                 });
        }

        [Test]
        public void DynamicPropertiesProxy()
        {
            TestTime.Measure(() =>
                                 {
                                     var e = new Entity();
                                     e.Extensions.AddProperty<string>("abc");

                                     var t = e.Extensions.DynamicProperties.TypedProxy;
                                 }
                );
        }

        [Test]
        public void DynamicPropertiesSet()
        {
            TestTime.Measure(() =>
                                 {
                                     var e = new Entity();
                                     e.Extensions.AddProperty<string>("abc");

                                     e.Extensions.DynamicProperties.SetProperty("abc", "x");
                                 }
                );
        }
        
        [Test]
        public void Undo()
        {
            TestTime.Measure(() =>
            {
                var e = new UndoEntity();
                var level1 = new UndoEntityLevel1();

                e.Entity = level1;

                var state = e.Savepoint();

                e.Entity = new UndoEntityLevel1();

                state.Rollback();

                e.Entity.ShouldEqual(level1);
            });
        }
    }
}