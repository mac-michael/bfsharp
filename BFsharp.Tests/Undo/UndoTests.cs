using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;
using BFsharp.Undo;

namespace BFsharp.Tests
{
    [TestFixture]
    public class UndoTests
    {
        [Test]
        public void AutoProperty()
        {
            var e = new UndoEntity {AutoProperty = "prop"};

            var state = e.Savepoint();
            e.AutoProperty = "changed";

            state.Rollback();

            e.AutoProperty.ShouldEqual("prop");
        }

        [Test]
        public void PrivateAutoProperty()
        {
            var e = new UndoEntity();
            e.SetPrivateAutoProperty("prop");

            var state = e.Savepoint();
            e.SetPrivateAutoProperty("changed");

            state.Rollback();

            e.GetPrivateAutoProperty().ShouldEqual("prop");
        }

        [Test]
        public void MixedAutoProperty()
        {
            var e = new UndoEntity();
            e.SetMixedAutoProperty("prop");

            var state = e.Savepoint();
            e.SetMixedAutoProperty("changed");
            e.MixedAutoProperty.ShouldEqual("changed");

            state.Rollback();

            e.MixedAutoProperty.ShouldEqual("prop");
        }

        [Test]
        public void Multilevel()
        {
            var e = new UndoEntity();
            e.Entity = new UndoEntityLevel1() { Property = 5 };

            var state = e.Savepoint();

            e.Entity.Property = 4;

            state.Rollback();

            e.Entity.Property.ShouldEqual(5);
        }

        [Test]
        public void MultilevelWithIdentity()
        {
            var e = new UndoEntity();
            var level1 = new UndoEntityLevel1();
            
            e.Entity = e.Entity2 = level1;

            var state = e.Savepoint();

            e.Entity.Property = 4;
            e.Entity2 = new UndoEntityLevel1();

            state.Rollback();

            e.Entity.Property.ShouldEqual(default(int));
            e.Entity.ShouldEqual(e.Entity2);


            Assert.IsTrue(object.ReferenceEquals(e.Entity, e.Entity2));
        }

        [Test]
        public void MultilevelInstance()
        {
            var e = new UndoEntity();
            var level1 = new UndoEntityLevel1();

            e.Entity = level1;

            var state = e.Savepoint();

            e.Entity = new UndoEntityLevel1();

            state.Rollback();

            e.Entity.ShouldEqual(level1);
        }

        [Test]
        public void RecursiveEntity()
        {
            var e = new RecursiveEntity { Value = 5};
            var other = e.Other = new RecursiveEntity { Other = e, Value = 3 };

            var state = e.Savepoint();

            e.Value = 3;
            e.Other.Value = 5;

            state.Rollback();

            e.Value.ShouldEqual(5);
            e.Other.ShouldEqual(other); // Reference equality
            e.Other.Value.ShouldEqual(3);
        }

        [Test]
        public void MultilevelUndo()
        {
            var e = new UndoEntity();
            e.Property = "Joel";
            var state = e.Savepoint();
                e.Property = "Joel2";
                var state2 = e.Savepoint();
                    e.Property = "Joel3";
                    state2.Rollback();
                e.Property.ShouldEqual("Joel2");
                state.Rollback();
            e.Property.ShouldEqual("Joel");
        }

        [Test]
        public void CustomUndo()
        {
            var e = new CustomUndoEntity {NonUndoableProperty = "normal", UndoableProperty = "normal"};

            using( e.Savepoint())
            {
                e.NonUndoableProperty = "changed";
                e.UndoableProperty = "changed";
            }

            e.NonUndoableProperty.ShouldEqual("changed");
            e.UndoableProperty.ShouldEqual("normal");
        }

        [Test]
        public void UndoStruct()
        {
            var s = new UndoEntityWithStruct();
            s.Struct = new UndoStruct{Name = "name", Number = 4};

            using(s.Savepoint())
            {
                s.Struct = new UndoStruct {Name = "rename", Number = 5};
            }

            s.Struct.Name.ShouldEqual("name");
            s.Struct.Number.ShouldEqual(4);
        }

        [Test]
        public void UndoStructWithMethod()
        {
            var s = new UndoEntityWithStruct();
            s.Struct = new UndoStruct { Name = "name" };

            using (s.Savepoint())
            {
                s.Struct.SetName("renamed");
            }

            s.Struct.Name.ShouldEqual("name");
        }

        // Not supported
        [Test]
        [ExpectedException(typeof(AssertionException))]
        public void UndoStructWithClass()
        {
            var s = new UndoEntityWithStruct();
            s.Struct = new UndoStruct() { Level2 = new UndoEntityLevel2{Name="name"}};

            using (s.Savepoint())
            {
                s.Struct.Level2.Name = "renamed";
            }

            s.Struct.Level2.Name.ShouldEqual("name");
        }

        [Test]
        public void InheritanceTest()
        {
            UndoEntityWithInheritance e = new UndoEntityWithInheritanceB { PropertyInBase = "base", PropertyInChild = "child" };

            using (e.Savepoint())
            {
                e.PropertyInBase = "changed";
                ((UndoEntityWithInheritanceB)e).PropertyInChild = "changed";
            }

            ((UndoEntityWithInheritanceB)e).PropertyInChild.ShouldEqual("child");
            e.PropertyInBase.ShouldEqual("base");

        }

        [Test]
        public void Array()
        {
            UndoEntityWithArray e = new UndoEntityWithArray();
            e.Ints = new []{1,2,3};

            using(e.Savepoint())
            {
                e.Ints = new [] {2,3};
            }

            e.Ints.Length.ShouldEqual(3);
        }
    }
}