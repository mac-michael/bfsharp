using BFsharp.AOP;
using BFsharp;

namespace Rules.Entities
{
    [NotifyPropertyChanged]
    public class InvoiceLine7 : EntityBase<InvoiceLine7>, IInvoiceLine
    {
        public InvoiceLine7()
        {
            if (Tenant.Current.Direction == CalcDirection.FromQuantity)
                Extensions.CreateBusinessRule("Total=Quantity*ProductPrice").Start();
            else if (Tenant.Current.Direction == CalcDirection.FromTotal)
                Extensions.CreateBusinessRule("Quantity=Total/ProductPrice")
                    .WithModeAtStartup(BusinessRuleStartupMode.None).Start();
        }

        public decimal ProductPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
    }
}