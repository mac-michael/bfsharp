using System.Globalization;
using System.Threading;
using BFsharp.Localization;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class IsDirtyTests
    {
        [Test]
        public void Simple()
        {
            var e = new Entity();
            e.Extensions.StartDirtyTracking();
            e.Extensions.IsDirty.ShouldBeFalse();

            e.Name = "a";

            e.Extensions.IsDirty.ShouldBeTrue();
        }

        [Test]
        public void ClearIsDirty()
        {
            var e = new Entity();
            e.Extensions.StartDirtyTracking();

            e.Name = "a";
            e.Extensions.IsDirty.ShouldBeTrue();
            e.Extensions.ClearIsDirty();
            e.Extensions.IsDirty.ShouldBeFalse();
        }

        [Test]
        public void Hierarchy()
        {
            var e = new Entity();
            e.Extensions.StartDirtyTracking();

            e.Child = new Entity();
            e.Child.Name = "a";
            e.Extensions.IsDirty.ShouldBeTrue();
            e.Extensions.ClearIsDirty();
            e.Extensions.IsDirty.ShouldBeFalse();
        }

        [Test]
        public void ModifiedHierarchy()
        {
            var e = new Entity();
            e.Extensions.StartDirtyTracking();

            e.Child = new Entity();

            e.Child.Name = "a";
            e.Extensions.IsDirty.ShouldBeTrue();
            e.Extensions.ClearIsDirty();
            e.Child.Name = "b";
            e.Extensions.IsDirty.ShouldBeTrue();
        }

        [Test]
        public void Collection()
        {
            var e = new Entity();
            e.Collection.Add(new Entity{Number = 3});
            e.Extensions.StartDirtyTracking();

            e.Collection[0].Number = 2;
            
            e.Extensions.IsDirty.ShouldBeTrue();
        }

        [Test]
        public void ModifiedCollection()
        {
            var e = new Entity();
            e.Collection.Add(new Entity { Number = 3 });
            e.Extensions.StartDirtyTracking();

            var entity = new Entity { Number = 2 };
            e.Collection.Add(entity);

            e.Extensions.IsDirty.ShouldBeTrue();
        }

        [Test]
        public void CollectionRemove()
        {
            var e = new Entity();
            e.Collection.Add(new Entity { Number = 3 });
            e.Extensions.StartDirtyTracking();
            
            e.Collection.RemoveAt(0);

            e.Extensions.IsDirty.ShouldBeTrue();
        }

        [Test]
        public void Advanced()
        {
            var e = new Entity();
            e.Collection.Add(new Entity {Child = new Entity {Number = 4}});

            e.Extensions.StartDirtyTracking();

            var entity = new Entity { Number = 2 };
            e.Collection.Add(entity);

            e.Extensions.IsDirty.ShouldBeTrue();
            e.Extensions.ClearIsDirty();

            entity.Child = new Entity();
            e.Extensions.IsDirty.ShouldBeTrue();
            e.Extensions.ClearIsDirty();

            entity.Child.Name = "abc";
            e.Extensions.IsDirty.ShouldBeTrue();
        }
    }
}