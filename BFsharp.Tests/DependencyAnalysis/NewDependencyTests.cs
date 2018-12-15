using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class NewDependencyTests
    {
        //[Test]
        //public void ObservableCollectionTest()
        //{
        //    var a = new ObservableCollection<int>();
        //    a.CollectionChanged += a_CollectionChanged;


        //    a.Add(3);
        //    a.Add(4);
        //    a.Add(5);

        //    a.Insert(0,2);
        //    a.Insert(0,1);

        //    a.Move(1,2);

        //    a[2] = 3;

        //    a.Clear();

        //}
        //void a_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        //{
        //    var message = string.Format("Action: {0}, NewStartingIndex: {1}, OldStartingIndex: {2}, OldItemsCount: {3}, NewItems: {4}", 
        //                                e.Action, e.NewStartingIndex, e.OldStartingIndex, (e.OldItems == null ? 0 : e.OldItems.Count), (e.NewItems == null ? 0 : e.NewItems.Count));
        //    Debug.WriteLine( message);
        //}


        /*[Test]
        public void Nested()
        {
            DependencyNode n = new DependencyNode();
            Entity e = new Entity();
            e.Child = new Entity();
            n.Subscribe(e);
            n.AddPropertyDependency(new[] { "Child", "Number" }, null, "a");

            e.PropertyChangeSubscriptionCountShouldEqual(1);
            e.Child.PropertyChangeSubscriptionCountShouldEqual(1);
            
            n.Unsubscribe();

            e.PropertyChangeSubscriptionCountShouldEqual(0);
            e.Child.PropertyChangeSubscriptionCountShouldEqual(0);
        }
        */

        [Test]
        public void Simple()
        {
            var n = new DependencyNode();
            var e = new Entity {Child = new Entity()};
            n.Subscribe(e);
            n.AddPropertyDependency("Number", null, "a");

            e.PropertyChangeSubscriptionCountShouldEqual(2);
            e.Child.PropertyChangeSubscriptionCountShouldEqual(1);
            
            n.Unsubscribe();

            e.PropertyChangeSubscriptionCountShouldEqual(1);
            e.Child.PropertyChangeSubscriptionCountShouldEqual(1);
        }

        [Test]
        public void DoubleSimple()
        {
            var n = new DependencyNode();
            var e = new Entity { Child = new Entity() };
            n.Subscribe(e);
            n.AddPropertyDependency(new[] { "Number" }, null, "a");
            n.AddPropertyDependency(new[] { "Number" }, null, "a");

            e.PropertyChangeSubscriptionCountShouldEqual(2);
            e.Child.PropertyChangeSubscriptionCountShouldEqual(1);

            n.Unsubscribe();

            e.PropertyChangeSubscriptionCountShouldEqual(1);
            e.Child.PropertyChangeSubscriptionCountShouldEqual(1);
        }
        
        [Test]
        public void Collection()
        {
            var n = new DependencyNode();
            var e = new Entity { Child = new Entity() };
            e.Collection.Add(new Entity());
            n.Subscribe(e);
            n.AddPropertyDependency("Collection$Name", delegate {}, "a");

            e.PropertyChangeSubscriptionCountShouldEqual(2);
            e.Collection[0].PropertyChangeSubscriptionCountShouldEqual(2);
            
            n.Unsubscribe();

            e.PropertyChangeSubscriptionCountShouldEqual(1);
            e.Collection[0].PropertyChangeSubscriptionCountShouldEqual(1);
        }

        [Test]
        public void Collection2()
        {
            var n = new DependencyNode();
            var e = new Entity { Child = new Entity() };
            e.Collection.Add(new Entity());
            n.Subscribe(e);
            n.AddPropertyDependency("$Collection", delegate { }, "a");

            e.PropertyChangeSubscriptionCountShouldEqual(2);
            e.Collection[0].PropertyChangeSubscriptionCountShouldEqual(2);

            n.Unsubscribe();

            e.PropertyChangeSubscriptionCountShouldEqual(1);
            e.Collection[0].PropertyChangeSubscriptionCountShouldEqual(1);
        }

        [Test]
        public void CollectionNested()
        {
            var n = new DependencyNode();
            var e = new Entity { Child = new Entity() };
            e.Collection.Add(new Entity{Child = new Entity()});
            n.Subscribe(e);
            n.AddPropertyDependency("Collection$Child.Name", delegate { }, "a");

            e.PropertyChangeSubscriptionCountShouldEqual(2);
            e.Collection[0].PropertyChangeSubscriptionCountShouldEqual(2);
            e.Collection[0].Child.PropertyChangeSubscriptionCountShouldEqual(2);

            n.Unsubscribe();

            e.PropertyChangeSubscriptionCountShouldEqual(1);
            e.Collection[0].PropertyChangeSubscriptionCountShouldEqual(1);
            e.Collection[0].Child.PropertyChangeSubscriptionCountShouldEqual(1);
        }

        [Test]
        public void CollectionAdd()
        {
            var n = new DependencyNode();
            var e = new Entity { Child = new Entity() };
            n.Subscribe(e);
            n.AddPropertyDependency("Collection$Name", delegate { }, "a");
            e.Collection.Add(new Entity());
            e.Collection.Add(new Entity());

            e.PropertyChangeSubscriptionCountShouldEqual(2);
            e.Collection[0].PropertyChangeSubscriptionCountShouldEqual(2);

            n.Unsubscribe();

            e.PropertyChangeSubscriptionCountShouldEqual(1);
            e.Collection[0].PropertyChangeSubscriptionCountShouldEqual(1);
        }

        [Test]
        public void CollectionAddNestedWithNull()
        {
            var n = new DependencyNode();
            var e = new Entity { Child = new Entity() };
            n.Subscribe(e);
            n.AddPropertyDependency("Collection$Child.Name", delegate { }, "a");
            e.Collection.Add(new Entity());

            e.PropertyChangeSubscriptionCountShouldEqual(2);
            e.Collection[0].PropertyChangeSubscriptionCountShouldEqual(2);
            e.Collection[0].Child = new Entity();
            e.Collection[0].Child.PropertyChangeSubscriptionCountShouldEqual(2);

            n.Unsubscribe();

            e.PropertyChangeSubscriptionCountShouldEqual(1);
            e.Collection[0].PropertyChangeSubscriptionCountShouldEqual(1);
            e.Collection[0].Child.PropertyChangeSubscriptionCountShouldEqual(1);
        }

        [Test]
        public void CollectionRemove()
        {
            var n = new DependencyNode();
            var e = new Entity { Child = new Entity() };
            var child = new Entity();
            e.Collection.Add(child);
            n.Subscribe(e);
            n.AddPropertyDependency("Collection$Name", delegate { }, "a");

            e.PropertyChangeSubscriptionCountShouldEqual(2);
            child.PropertyChangeSubscriptionCountShouldEqual(2);

            e.Collection.RemoveAt(0);

            child.PropertyChangeSubscriptionCountShouldEqual(1);

            n.Unsubscribe();

            e.PropertyChangeSubscriptionCountShouldEqual(1);
        }

        [Test]
        public void AllProperties()
        {
            var n = new DependencyNode();
            var e = new Entity { Child = new Entity() };

            n.Subscribe(e);
            var c = new ExecutionCounter();
            n.AddPropertyDependency("*",s=>c.Execute(), "x");

            e.Name = "abc";
            e.Number2 = 4;
            //e.Collection.Add(new Entity());

            c.Counter.ShouldEqual(2);
        }

        public class ExecutionCounter
        {
            public int Counter { get; set; }
            public bool Executed { get { return Counter > 0; } }

            public Action<T> GetAction<T>()
            {
                return t => Counter++;
            }

            public void Execute()
            {
                Counter++;
            }
        }
    }
}