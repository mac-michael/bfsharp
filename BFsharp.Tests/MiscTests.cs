using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using BFsharp.AOP;
using NUnit.Framework;

namespace BFsharp.Tests
{
    public class MyEntityBase : IEntityBase
    {
        [ImplementExtensions]
        public IEntityExtensions Extensions { get; private set; }
    }

    public abstract class MyEntityBase<T> : IEntityBase//, IEntityBase<T>
    {
        [ImplementExtensions]
        IEntityExtensions IEntityBase.Extensions { get { throw new InvalidOperationException(); } }

        public IEntityExtensions<T> Extensions
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class Customer2 : MyEntityBase<Customer>
    {

    }

    //[ImplementExtensionsAttribute]
    public class Customer : IEntityBase<Customer>
    {
        public IEntityExtensions<Customer> Extensions { get; private set; }
    }

    [TestFixture, Ignore]
    public class MiscTests
    {
        [Test]
        public void x()
        {
            var e = new MyEntityBase();
           // var e2 = new Customer();
            var e3 = new Customer2();

            var x = e.Extensions;
            //var x2 = e2.Extensions;
            //var x3 = e3.Extensions;
        }

        class A : EntityBase{}
        class B : EntityBase<B>
        {
            public int Number { get; set; }
        }

        [Test]
        public void XXX()
        {
            var eb = new A();

            eb.Extensions.CreateValidationRule(o => false)
                .Start();

            var ebg = new B();
            ebg.Extensions.CreateValidationRule(o => o.Number == 4)
                .Start();

            IEntityExtensions e = eb.Extensions;

            IEntityExtensions e2 = ebg.Extensions;
            IEntityExtensions<B> e3 = ebg.Extensions;

            IEntityBase b = eb;
            IEntityBase b2 = ebg;
            IEntityBase<B> b3 = ebg;
        }

        [Test]
        public void Sum()
        {
            Expression<Func<Entity, int>> c = e => e.Collection
                .Where(o=>o.Name!="mmm" && o.Number2 < 5)
                .Where(x=>x.Number3 < 5)
                .Sum(en => en.Number)+5;

            var v = new DependencyVisitor();
            v.Visit(c);
        }

        [Test]
        public void Max()
        {
            Expression<Func<Entity, int?>> c = e => e.Collection
                .Where(o => o.Name != "mmm" && o.Number2 < 5)
                .Where((o,i)=>i<4)
                .Max(m => m.NullableNumber);

            var v = new DependencyVisitor();
            v.Visit(c);
        }

        [Test]
        public void Min()
        {
            Expression<Func<Entity, int?>> c = e => e.Collection
                .Where(o => o.Name != "mmm" && o.Number2 < 5)
                .Where((o, i) => i < 4)
                .Min(m => m.NullableNumber);

            var v = new DependencyVisitor();
            v.Visit(c);
        }

        [Test]
        public void a()
        {
            var t = typeof (Enumerable);
            var max = from m in t.GetMethods()
                      where m.Name == "Min"
                      select m.ToString();

            var maxm = string.Join(Environment.NewLine, max.ToArray());
            Debug.WriteLine(maxm);
        }

        [Test]
        public void Max2()
        {
            Expression<Func<Entity, int?>> c = e => e.Range.Max();

            var v = new DependencyVisitor();
            v.Visit(c);
        }

        [Test]
        public void Select()
        {
            Expression<Func<Entity, int>> c = e => e.Collection
                        .Where(o => o.Number2 < 5)
                        .Select(x => x.Child.Child)
                        .Select(x => x.Child)
                        .Select(x => x.Name).Sum(s => s.Length);

            var v = new DependencyVisitor();
            v.Visit(c);
        }


        [Test]
        public void SelectMax()
        {
            Expression<Func<Entity, int>> c = e => e.Collection
                        .Where(o => o.Number2 < 5)
                        .Select(x=>x.Child.Child)
                        .Select(x=>x.Child)
                        .Select(x=>x.Name).Select(s=>s.Length).Max();
            
            var v = new DependencyVisitor();
            v.Visit(c);
        }

        [Test]
        public void Rule()
        {
            var entity = new Entity();
            //entity.Extensions.AddBusinessRule(r => r.Name, );
        }

        [Test]
        public void PredicateTest()
        {
            Predicate<Entity> p = e => e.Number == 4;

            var entity = new Entity();
            entity.Extensions.CreateValidationRuleWithoutDependency(e => p(e));
            entity.Extensions.CreateValidationRuleWithoutDependency(e => e.Number2 == 4);
        }

        [Test]
        public void Test()
        {
            var entity = new Entity();

            entity.Extensions.CreateActionRule(e => e.GetType());
        }

        [Test]
        public void EnumerableRuleTest()
        {
            var e = new Entity();
            // 1
            //e.Extensions.AddEnumerableRule(en => from p in en.Collection select p.Number,
            //                               a => a.Sum(x=>x.Number), en => en.Number);

            // 2
            e.Extensions.CreateBusinessRule(en => en.Collection.Sum(x=>x.Number2), en => en.Number)
                .WithCollectionDependencies(p=>p.Collection, i=>i.Number, i=>i.Number2);
            
            // 3
            e.Extensions.CreateBusinessRule(en => (from x in en.Collection select x.Number2).Sum(), en => en.Number);
        }
    }
}