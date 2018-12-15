using System.ComponentModel;

namespace BFsharp.DynamicProperties
{
    public abstract class TypedProxyBase : INotifyPropertyChanged
    {
        protected DynamicPropertyCollection _parent;

        protected TypedProxyBase(DynamicPropertyCollection parent)
        {
            _parent = parent;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        internal void RaisePropertyChanged(string propertyName)
        {
            var p = PropertyChanged;
            if (p != null)
                p(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}