using BFsharp.AOP;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class ClientServerTests
    {
        [NotifyPropertyChanged]
        public class Product : EntityBase<Product>
        {
            public decimal Quantity { get; set; }
            public decimal NetPrice { get; set; }
            public decimal GrossPrice { get; set; }
        }

        [Test]
        public void Test()
        {
            var f = new RuleFactory<Product>();

            var rule = f.CreateBusinessRule(e => e.Quantity*e.NetPrice, e => e.GrossPrice)
                .WithClientSide(
                    r => r.Mode = BusinessRuleMode.Evaluate
                )
                .WithServerSide(
                    r => r.Mode = BusinessRuleMode.Validate
                ).Start();

            RuleContext.Strategy = ()=>RuleContextState.Client;
            var p = new Product {Quantity = 4, NetPrice=5};
            p.Extensions.AddRuleFromPrototype(rule);
            p.Quantity = 5;

            p.GrossPrice.ShouldEqual(5*5);
            p.Extensions.BrokenRules.Count.ShouldEqual(0);

            RuleContext.Strategy = () => RuleContextState.Server;
            var p2 = new Product { Quantity = 4, NetPrice = 5 };
            p2.Extensions.AddRuleFromPrototype(rule);
            p2.Quantity = 3;

            p2.GrossPrice.ShouldEqual(0);
            p2.Extensions.BrokenRules.Count.ShouldEqual(1);
        }

        [Test]
        public void ValidateOnlyOnServerSide()
        {
            var f = new RuleFactory<Product>();
            var rule = f.CreateBusinessRule(e => e.Quantity*e.NetPrice, e => e.GrossPrice)
                .ValidateOnlyOnServerSide().Start();

            RuleContext.Strategy = () => RuleContextState.Client;
            var p = new Product { Quantity = 4, NetPrice = 5 };
            p.Extensions.AddRuleFromPrototype(rule);
            p.Quantity = 5;

            p.GrossPrice.ShouldEqual(5 * 5);
            p.Extensions.BrokenRules.Count.ShouldEqual(0);

            RuleContext.Strategy = () => RuleContextState.Server;
            var p2 = new Product { Quantity = 4, NetPrice = 5 };
            p2.Extensions.AddRuleFromPrototype(rule);
            p2.Quantity = 3;

            p2.GrossPrice.ShouldEqual(0);
            p2.Extensions.BrokenRules.Count.ShouldEqual(1);
        }
    }
}