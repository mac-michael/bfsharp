using BFsharp.AOP;
using BFsharp;

namespace Rules.Entities
{
    [NotifyPropertyChanged]
    public class InvoiceLine6 : EntityBase<InvoiceLine6>, IInvoiceLine
    {
        public InvoiceLine6()
        {
            if (Tenant.Current.Direction == CalcDirection.FromQuantity)
            {
                Extensions.CreateBusinessRule(l => l.Quantity*l.ProductPrice, l => l.Total)
                    .Start();
            }
            else if (Tenant.Current.Direction == CalcDirection.FromTotal)
            {
                Extensions.CreateBusinessRule(l => l.Total/l.ProductPrice, l => l.Quantity)
                    .WithModeAtStartup(BusinessRuleStartupMode.None)
                    .Start();
            }
        }

        public decimal ProductPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
    }
}