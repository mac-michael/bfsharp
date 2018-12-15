using System.ComponentModel;

namespace Rules.Entities
{
    public class InvoiceLine3 : INotifyPropertyChanged
    {
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
                    RaisePropertyChanged("Total");
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
                    RaisePropertyChanged("Total");
                }
            }
        }

        public decimal Total { get { return ProductPrice * Quantity; } }
/// Problemy:
/// - brak mo¿liwoœci prostej podmiany regu³
/// - nieczytelne (brak automatycznych properties)
/// - koniecznoœæ jawnego specyfikowania zale¿noœci pomiêdzy properties

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}