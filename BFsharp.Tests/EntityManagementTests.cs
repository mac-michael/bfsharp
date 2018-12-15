using System.Diagnostics;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class EntityManagementTests
    {
        [Test]
        public void Test()
        {
            var invoice = new SwitchableRuleTests.Invoice
            {
                Lines =
                                {
                                    new SwitchableRuleTests.InvoiceLine {Quantity = 2, NetPrice = 2, GrossPrice = 3},
                                    new SwitchableRuleTests.InvoiceLine {Quantity = 1, NetPrice = 1, GrossPrice = 2}
                                }
            };

            invoice.Extensions.DoClusterAction((e,n)=>Debug.WriteLine(n + ". " + e));
        }
    }
}