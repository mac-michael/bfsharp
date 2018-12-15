using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using BFsharp.AOP;
using NUnit.Framework;
using System.Linq;

namespace BFsharp.Tests
{
    [TestFixture]
    public class SwitchableRuleTests
    {
        public enum InvoiceType
        {
            Net,
            Gross,
        }

        [NotifyPropertyChanged]
        public class Invoice : EntityBase<Invoice>
        {
            public Invoice()
            {
                Lines = new ObservableCollection<InvoiceLine>();
            }

            public InvoiceType Type { get; set; }

            public decimal NetPrice { get; set; }
            public decimal GrossPrice { get; set; }

            public string Status { get; set; }

            public ObservableCollection<InvoiceLine> Lines { get; set; }

            public decimal Total { get; set; }

            [RuleInit]
            public void RuleInit()
            {
                Extensions.CreateBusinessRule(e => e.Lines.Sum(x => x.NetTotal), e => e.Total)
                    .WithCollectionDependencies(e => e.Lines, e => e.NetTotal)
                    .WithSwitch(InvoiceType.Net)
                    .Start();

                Extensions.CreateBusinessRule(e => e.Lines.Sum(x => x.GrossTotal), e => e.Total)
                    .WithCollectionDependencies(e => e.Lines, e => e.GrossTotal)
                    .WithSwitch(InvoiceType.Gross)
                    .Start();

                Extensions.CreateSwitchableRule(en => en.Type)
                    .Start();
            }
        }

        [NotifyPropertyChanged]
        public class InvoiceLine : EntityBase<InvoiceLine>
        {
            public decimal Quantity { get; set; }
            public decimal NetPrice { get; set; }
            public decimal GrossPrice { get; set; }
            public decimal GrossTotal { get; set; }
            public decimal NetTotal { get; set; }

            [RuleInit]
            public void RuleInit()
            {
                Extensions.CreateBusinessRule(e => e.Quantity*e.NetPrice, e => e.NetTotal)
                    .WithEvaluationAtStartup()
                    .WithSwitch(InvoiceType.Net)
                    .Start();

                Extensions.CreateBusinessRule(e => e.Quantity*e.GrossPrice, e => e.GrossTotal)
                    .WithEvaluationAtStartup()
                    .WithSwitch(InvoiceType.Gross)
                    .Start();
            }
        }

        [NotifyPropertyChanged]
        public class SwtichEntity : EntityBase<SwtichEntity>
        {
            public InvoiceType Type { get; set; }
            public string Status { get; set; }
        }

        [Test]
        public void Switch()
        {
            var e = new SwtichEntity();
            e.Extensions.CreateBusinessRule(en => en.Type.ToString(), en => en.Status)
                .WithSwitch(InvoiceType.Net)
                .Start();

            e.Extensions.CreateBusinessRule(en => en.Type.ToString(), en => en.Status)
                .WithSwitch(InvoiceType.Gross)
                .Start();

            e.Extensions.CreateSwitchableRule(en => en.Type).Start();

            e.Status.ShouldEqual("Net");
            e.Type = InvoiceType.Gross;
            e.Status.ShouldEqual("Gross");
        }

        [Test]
        public void RecursiveSwitchTest()
        {
            var i = new Invoice
                        {
                            Lines =
                                {
                                    new InvoiceLine {Quantity = 2, NetPrice = 2, GrossPrice = 3},
                                    new InvoiceLine {Quantity = 1, NetPrice = 1, GrossPrice = 2}
                                }
                        };

            i.Extensions.InitializeRules();

            i.Total.ShouldEqual(2*2 + 1*1);
            i.Type = InvoiceType.Gross;
            i.Total.ShouldEqual(2*3 + 1*2);
        }

        //[Test]
        //public void NewApi()
        //{
        //    var invoiceLine = new InvoiceLine();
        //    invoiceLine.Extensions.CreateBusinessRule(e => e.Quantity*e.NetPrice, e => e.NetTotal)
        //        .WithCondition(e => ((Invoice) e.Extensions.Parent.Target).Type == InvoiceType.Gross)
        //        .Start();
        //    //invoiceLine.Extensions.Validate()
        //    var invoice = new Invoice();
        //    invoice.Extensions.CreateBusinessRule(e => e.GrossPrice, e => e.NetPrice)
        //        .WithCondition(e => e.Type == InvoiceType.Gross)
        //        .Start();
        //}
    }
}