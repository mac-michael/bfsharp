using BFsharp.AOP;
using BFsharp;

namespace Rules.Entities
{
    [NotifyPropertyChanged]
    public class InvoiceLine8 : EntityBase<InvoiceLine8>, IInvoiceLine
    {
        public InvoiceLine8()
        {
            this.AddRuleWithParam("Total=Quantity * ProductPrice * User.Discount").Start();
        }

        public decimal ProductPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
    }
}