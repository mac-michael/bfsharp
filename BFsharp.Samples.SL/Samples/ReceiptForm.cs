using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BFsharp.Samples.SL.Samples
{
    [Sample(@"Samples\Receipt", Code.Receipt)]
    public class ReceiptForm : UserControl
    {
        protected readonly DataForm _dataForm;

        public ReceiptForm()
        {
            _dataForm = new DataForm();
            _dataForm.AutoGeneratingField += Form_AutoGeneratingField;
            _dataForm.AutoEdit = true;

            var stackPanel = new StackPanel();
            var total = new TextBox() { Margin = new Thickness(0, 5, 0, 5) };
            total.IsReadOnly = true;
            total.SetBinding(TextBox.TextProperty, new Binding("TotalGrossPrice"));
            stackPanel.Children.Add(new TextBlock() { Text = "TotalGrossPrice", Margin = new Thickness(0, 5, 0, 5) });
            stackPanel.Children.Add(total);
            stackPanel.Children.Add(new TextBlock(){Text="Lines", Margin = new Thickness(0,5,0,5)});
            stackPanel.Children.Add(_dataForm);

            var receipt = new Receipt();
            receipt.Lines.Add(new ReceiptLine());
            receipt.Extensions.InitializeRules();

            _dataForm.ItemsSource = receipt.Lines;
            total.DataContext = receipt;

            Content = stackPanel;
        }

        static void Form_AutoGeneratingField(object sender, DataFormAutoGeneratingFieldEventArgs e)
        {
            if (e.PropertyName == "Extensions" || e.PropertyName == "Error" || e.PropertyName == "HasErrors" )
                e.Cancel = true;
        }
    }
}