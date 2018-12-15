using BFsharp.AOP;
using BFsharp;

namespace Rules.Entities
{
    [NotifyPropertyChanged]
    public class InvoiceLine10 : EntityBase<InvoiceLine10>, IInvoiceLine
    {
        public decimal ProductPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
    }
}