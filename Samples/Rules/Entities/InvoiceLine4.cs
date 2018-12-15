using System.ComponentModel;

namespace Rules.Entities
{
    public class InvoiceLine4 : INotifyPropertyChanged
    {
        public InvoiceLine4()
        {
            PropertyChanged += OnPropertyChanged;
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

/// Problemy:
/// - nieczytelne (brak automatycznych properties)
/// - koniecznoœæ jawnego specyfikowania zale¿noœci pomiêdzy properties
/// - regu³y nie s¹ reu¿ywalne

        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (Tenant.Current.Direction == CalcDirection.FromQuantity
                && (e.PropertyName == "Quantity" || e.PropertyName == "ProductPrice"))
                Total = Quantity * ProductPrice;
            else if (Tenant.Current.Direction == CalcDirection.FromTotal
                     && (e.PropertyName == "Total" || e.PropertyName == "ProductPrice"))
                Quantity = Total / ProductPrice;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}