using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class DependencyTests
    {
        [Test]
        public void Simple()
        {
            var e = new Entity();
            e.Extensions.CreateValidationRule(en => en.Name == "abc").Enable();

            e.Extensions.BrokenRules.Count.ShouldEqual(1);
            e.Name = "abc";
            e.Extensions.BrokenRules.Count.ShouldEqual(0);
        }

        [Test]
        public void SimpleRemoveDependency()
        {
            var e = new Entity();
            var rule = e.Extensions.CreateValidationRule(en => en.Name == "abc");
            rule.Enable();

            e.PropertyChangeSubscriptionCountShouldEqual(2);
            e.Extensions.Rules.Remove(rule);
            e.PropertyChangeSubscriptionCountShouldEqual(1);
        }

        [Test]
        public void SimpleRemoveDoubleDependency()
        {
            var e = new Entity();
            var rule = e.Extensions.CreateValidationRule(en => en.Name == "abc")
                .WithDependencies(en=>en.Name);
            rule.Enable();

            e.PropertyChangeSubscriptionCountShouldEqual(2);
            e.Extensions.Rules.Remove(rule);
            e.PropertyChangeSubscriptionCountShouldEqual(1);
        }

        [Test]
        public void DoubleDependency()
        {
            var e = new Entity();
            var rule = e.Extensions.CreateValidationRule(en => en.Name == "abc")
                .WithDependencies(en => en.Name, en=>en.DecimalNumber);
            rule.Enable();

            e.PropertyChangeSubscriptionCountShouldEqual(2);
            e.Extensions.Rules.Remove(rule);
            e.PropertyChangeSubscriptionCountShouldEqual(1);
        }

        [Test]
        public void NestedChanged()
        {
            var e = new Entity{Child = new Entity()};
            e.Extensions.CreateValidationRule(en => en.Child.Name == "abc").Enable();

            e.Extensions.BrokenRules.Count.ShouldEqual(1);
            e.Child.Name = "abc";
            e.Extensions.BrokenRules.Count.ShouldEqual(0);

            e.Extensions.Rules.RemoveAt(0);
        }

        [Test]
        public void RemoveDependencyNestedChanged()
        {
            var e = new Entity { Child = new Entity() };
            var rule = e.Extensions.CreateValidationRule(en => en.Child.Name == "abc")
                .Start();

            e.PropertyChangeSubscriptionCountShouldEqual(2);
            e.Child.PropertyChangeSubscriptionCountShouldEqual(2);

            e.Extensions.Rules.Remove(rule);

            e.PropertyChangeSubscriptionCountShouldEqual(1);
            e.Child.PropertyChangeSubscriptionCountShouldEqual(1);
        }

        [Test]
        public void NestedComponentChanged()
        {
            var e = new Entity { Child = new Entity() };
            e.Extensions.CreateValidationRule(en => en.Child.Name == "abc").Enable();

            e.Extensions.BrokenRules.Count.ShouldEqual(1);
            e.Child = new Entity {Name = "abc"};
            e.Extensions.BrokenRules.Count.ShouldEqual(0);
        }

        [Test]
        public void RemoveNestedComponentChanged()
        {
            var e = new Entity { Child = new Entity() };
            e.Extensions.CreateValidationRule(en => en.Child.Name == "abc").Enable();

            var old = e.Child;
            old.PropertyChangeSubscriptionCountShouldEqual(2);
            e.Child = new Entity { Name = "abc" };
            old.PropertyChangeSubscriptionCountShouldEqual(1);
            e.Child.PropertyChangeSubscriptionCountShouldEqual(2);
            
        }

        [Test]
        public void HiperNestedChanged()
        {
            var e = new Entity { Child = new Entity{Child = new Entity()}};
            e.Extensions.CreateValidationRule(en => en.Child.Child.Name == "abc").Enable();

            e.Extensions.BrokenRules.Count.ShouldEqual(1);
            e.Child.Child = new Entity {Name = "abc"};
            e.Extensions.BrokenRules.Count.ShouldEqual(0);
        }

        [Test]
        public void TwoSimpleOverlapping()
        {
            var e = new Entity {Name = ""};
            e.Extensions.CreateValidationRule(en => en.Name == "abc").Enable();
            e.Extensions.CreateValidationRule(en => en.Name == "abc").Enable();

            e.Extensions.BrokenRules.Count.ShouldEqual(2);
            e.Name = "abc";
            e.Extensions.BrokenRules.Count.ShouldEqual(0);
        }

        [Test]
        public void RemoveTwoSimpleOverlapping()
        {
            var e = new Entity {Name = ""};
            e.Extensions.CreateValidationRule(en => en.Name == "abc").Enable();
            e.Extensions.CreateValidationRule(en => en.Name == "abc").Enable();

            e.PropertyChangeSubscriptionCountShouldEqual(2);
            e.Extensions.Rules.RemoveAt(0);
            e.PropertyChangeSubscriptionCountShouldEqual(2);
            e.Extensions.Rules.RemoveAt(0);
            e.PropertyChangeSubscriptionCountShouldEqual(1);
        }

        [Test]
        public void TwoSimpleNoOverlapping()
        {
            var e = new Entity();
            e.Extensions.CreateValidationRule(en => en.Name == "abc").Enable();
            e.Extensions.CreateValidationRule(en => en.Number == 5).Enable();

            e.Extensions.BrokenRules.Count.ShouldEqual(2);
            e.Name = "abc";
            e.Extensions.BrokenRules.Count.ShouldEqual(1);
            e.Number = 5;
            e.Extensions.BrokenRules.Count.ShouldEqual(0);
        }

        [Test]
        public void RemoveTwoSimpleNoOverlapping()
        {
            var e = new Entity();
            e.Extensions.CreateValidationRule(en => en.Name == "abc").Enable();
            e.Extensions.CreateValidationRule(en => en.Number == 5).Enable();

            e.PropertyChangeSubscriptionCountShouldEqual(2);
            e.Extensions.Rules.RemoveAt(0);
            e.PropertyChangeSubscriptionCountShouldEqual(2);
            e.Extensions.Rules.RemoveAt(0);
            e.PropertyChangeSubscriptionCountShouldEqual(1);            
        }

        [Test]
        public void RegisterDependencyText()
        {
            var e = new Entity();
            e.Extensions.CreateValidationRuleWithoutDependency(en => en.Name == "abc")
                .WithDependencies("Name")
                .Enable();

            e.Extensions.BrokenRules.Count.ShouldEqual(1);
            e.Name = "abc";
            e.Extensions.BrokenRules.Count.ShouldEqual(0);
        }

        [Test]
        public void RegisterDependencyExpression()
        {
            var e = new Entity();
            e.Extensions.CreateValidationRuleWithoutDependency(en => en.Name == "abc")
                .WithDependencies(entity=>entity.Name.Length)
                .Enable();

            e.Extensions.BrokenRules.Count.ShouldEqual(1);
            e.Name = "abc";
            e.Extensions.BrokenRules.Count.ShouldEqual(0);
        }

        [Test]
        public void CollectionDependencyExpression()
        {
            var e = new Entity();
            e.Extensions.CreateValidationRuleWithoutDependency(en => en.Collection.Count == 0)
                .WithCollectionDependencies(en=> en.Collection)
                .Enable();

            e.Extensions.BrokenRules.Count.ShouldEqual(0);
            e.Collection.Add(new Entity());
            e.Extensions.BrokenRules.Count.ShouldEqual(1);
        }

        [Test]
        public void GetNestedPropertyPathReferenceType()
        {
            var path = DependencyHelper.GetPropertyPath(
                (RecursiveEntity entity) => entity.Other.Other.Other.Other);

            string s = string.Join(".", path.ToArray());
            s.ShouldEqual("Other.Other.Other.Other");
        }

        [Test]
        public void GetNestedPropertyPathValueObject()
        {
            var path = DependencyHelper.GetPropertyPath(
                (RecursiveEntity entity) => entity.Other.Other.Other.Other.Value);

            string s = string.Join(".", path.ToArray());
            s.ShouldEqual("Other.Other.Other.Other.Value");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidPropertyPath()
        {
            DependencyHelper.GetPropertyPath(
                (RecursiveEntity entity) => entity.Other.Other.Other.GetType());
        }

        [Test]
        public void GetDynamicPropertyPath()
        {
            var path = DependencyHelper.GetPropertyPath((DynamicEntity entity) =>
                     entity.Extensions.DynamicProperties.GetProperty<string>("String").Length);

            string s = string.Join(".", path.ToArray());
            s.ShouldEqual("Extensions.DynamicProperties.String.Length");
        }

        [Test]
        public void GetSetFromGet()
        {
            var a = DependencyHelper.GetSetFromGet((RecursiveEntity entity) =>
                                           entity.Value);

            var e = new RecursiveEntity();
            a(e, 5);
            e.Value.ShouldEqual(5);
        }

        [Test]
        public void GetSetFromGetWithDynamicProperty()
        {
            var a = DependencyHelper.GetSetFromGet((DynamicEntity entity) =>
                            entity.Extensions.DynamicProperties.GetProperty<SimpleClass>("Simple").Number);

            var e = new DynamicEntity();
            e.Extensions.DynamicProperties.SetProperty("Simple", new SimpleClass());
            a(e, 5);
            e.Extensions.DynamicProperties.GetProperty<SimpleClass>("Simple").Number.ShouldEqual(5);
        }

        [Test]
        public void GetSetFromDynamicGet()
        {
            var a = DependencyHelper.GetSetFromGet((DynamicEntity entity) =>
                            entity.Extensions.DynamicProperties.GetProperty<string>("String"));

            var e = new DynamicEntity();
            a(e, "value");
            e.Extensions.DynamicProperties.GetProperty<string>("String").ShouldEqual("value");
        }

        [Test]
        public void GetSetFromNestedGet()
        {
            var a = DependencyHelper.GetSetFromGet((RecursiveEntity entity) =>
                                           entity.Other.Value);

            var e = new RecursiveEntity {Other = new RecursiveEntity()};
            a(e, 5);
            e.Other.Value.ShouldEqual(5);
        }
    }
}