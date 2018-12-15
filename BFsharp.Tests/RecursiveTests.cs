using System.Collections.ObjectModel;
using System.Diagnostics;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class RecursionTests
    {
        [TestFixtureTearDown]
        public void TearDown()
        {
            ExtensionsOptions.Global.WithBuiltInRecursiveStrategy(PredefinedGraphMonitoringStrategy.IEntityBase);
        }

        [Test]
        public void Entity()
        {
            ExtensionsOptions.Global.WithBuiltInRecursiveStrategy(PredefinedGraphMonitoringStrategy.IEntityBase);

            var e = new Entity();
            e.Child = new Entity();

            e.Child.Extensions.Parent.ShouldNotBeNull();
        }

        [Test]
        public void Collection()
        {
            ExtensionsOptions.Global.WithBuiltInRecursiveStrategy(PredefinedGraphMonitoringStrategy.IEntityBase);

            var e = new Entity();
            e.Collection.Add(new Entity());
            
            e.Collection[0].Extensions.Parent.ShouldNotBeNull();
        }

        [Test]
        public void CollectionWithData()
        {
            ExtensionsOptions.Global.WithBuiltInRecursiveStrategy(PredefinedGraphMonitoringStrategy.IEntityBase);

            var e = new Entity();
            var c = new ObservableCollection<Entity>{new Entity()};
            e.Collection = c;

            e.Collection[0].Extensions.Parent.ShouldNotBeNull();
        }

        [Test]
        public void Entity2()
        {
            ExtensionsOptions.Global.WithBuiltInRecursiveStrategy(PredefinedGraphMonitoringStrategy.No);

            var e = new Entity();
            e.Child = new Entity();

            e.Child.Extensions.Parent.ShouldBeNull();
        }
    }

    [TestFixture]
    public class RecursiveTests
    {
        [Test]
        public void Entity()
        {
            var e = new Entity();
            e.Extensions.InitializeRules();
            e.Extensions.RuleInitialized.ShouldBeTrue();

            e.Child = new Entity();
            e.Child.Extensions.RuleInitialized.ShouldBeTrue();
        }

        [Test]
        public void Collection()
        {
            var e = new Entity();
            e.Extensions.InitializeRules();
            e.Extensions.RuleInitialized.ShouldBeTrue();

            e.Collection.Add(new Entity());
            e.Collection[0].Extensions.RuleInitialized.ShouldBeTrue();
        }

        [Test]
        public void CollectionElement()
        {
            var e = new Entity();
            e.Extensions.InitializeRules();
            e.Extensions.RuleInitialized.ShouldBeTrue();

            var entity = new Entity();
            entity.Child= new Entity();
            e.Collection.Add(entity);
            e.Collection[0].Child.Extensions.RuleInitialized.ShouldBeTrue();
        }

        [Test]
        public void IsValidCollectionElement()
        {
            var e = new Entity();
            e.Extensions.InitializeRules();
            e.Extensions.IsValid.ShouldBeTrue();

            var t = PropertyChangedTracker.Create(e.Extensions);

            var entity = new Entity();
            entity.Child = new Entity();
            e.Collection.Add(entity);
            e.Extensions.CreateValidationRule(x => false)
                .WithModeAtStartup(ValidationRuleStartupMode.Validate)
                .Enable();

            t.PropertyShouldBeNotified("IsValid", 1);
        }

        [Test]
        public void IsDirtyCollection()
        {
            var e = new Entity();
            e.Extensions.StartDirtyTracking();
            e.Extensions.IsDirty.ShouldBeFalse();

            var t = PropertyChangedTracker.Create(e.Extensions);

            var entity = new Entity();
            entity.Child = new Entity();
            e.Collection.Add(entity);

            t.PropertyShouldBeNotified("IsDirty", 1);
            e.Extensions.IsDirty.ShouldBeTrue();
        }
    }
}