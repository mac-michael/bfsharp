using BFsharp;
using BFsharp.AOP;

namespace Rules.Entities
{
    [NotifyPropertyChanged]
    public class InvoiceLine9 : EntityBase<InvoiceLine9>, IInvoiceLine
    {
        public InvoiceLine9()
        {
            Extensions.CreateBusinessRule("Total=Quantity * ProductPrice").Start();
            Extensions.CreateValidationRule("Total < 1000")
                .WithOwner("Total")
                .WithMessage("Pojedyñczy element nie mo¿e przekroczyæ wartoœæi 1000 z³.")
                .Start();
        }

        public decimal ProductPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
    }
}