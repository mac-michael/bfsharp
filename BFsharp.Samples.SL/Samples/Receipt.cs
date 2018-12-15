using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Linq;
using BFsharp.AOP;

namespace BFsharp.Samples.SL.Samples
{
    [NotifyPropertyChanged]
    public class Receipt : EntityBase<Receipt>
    {
        public Receipt()
        {
            Lines = new ObservableCollection<ReceiptLine>();
            Extensions.CreateActionRuleWithoutDependency(
                e => e.TotalGrossPrice = e.Lines.Sum(s => s.TotalGrossPrice))
                .WithCollectionDependencies(e => e.Lines, l => l.TotalGrossPrice)
                .Start();
        }
        public ObservableCollection<ReceiptLine> Lines { get; set; }

        public decimal TotalGrossPrice { get; set; }
    }

    [NotifyPropertyChanged]
    public class ReceiptLine : EntityBase<ReceiptLine>
    {
        public decimal GrossProductPrice { get; set; }

        public decimal Quantity { get; set; }

        public decimal TotalGrossPrice { get; set; }

        public ReceiptLine()
        {
            Extensions.CreateBusinessRule(e => e.Quantity * e.GrossProductPrice, e => e.TotalGrossPrice)
                .Start();
        }
    }
}
