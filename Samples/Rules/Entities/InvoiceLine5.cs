using System.ComponentModel;
using BFsharp;

namespace Rules.Entities
{
    public class InvoiceLine5 : EntityBase<InvoiceLine5>
    {
        public InvoiceLine5()
        {
            if (Tenant.Current.Direction == CalcDirection.FromQuantity)
            {
                Extensions.CreateBusinessRule( l => l.Quantity * l.ProductPrice, l => l.Total)
                    .Start();
            }
            else if (Tenant.Current.Direction == CalcDirection.FromTotal)
            {
                Extensions.CreateBusinessRule(l => l.Total / l.ProductPrice, l => l.Quantity)
                    .WithModeAtStartup(BusinessRuleStartupMode.None)
                    .Start();
            }
        }

        private decimal _productPrice;
        public decimal ProductPrice
        {
            get { return _productPrice; }
            set
            {
                if (_productPrice != value)
                {
                    _productPrice = value;
                    RaisePropertyChanged("ProductPrice");
                }
            }
        }

        private decimal _quantity;
        public decimal Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    RaisePropertyChanged("Quantity");
                }
            }
        }

        private decimal _total;

        public decimal Total
        {
            get { return _total; }
            set
            {
                if (_total != value)
                {
                    _total = value;
                    RaisePropertyChanged("Total");
                }
            }
        }

        public new event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}