using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using BFsharp.AOP;
using BFsharp;
using Rules.Entities;

namespace Rules
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = ViewModel = new ViewModel();

        }

        public ViewModel ViewModel { get; set; }
        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var en = (CalcDirection) Enum.Parse(
                typeof (CalcDirection), ((ComboBoxItem)e.AddedItems[0]).Content.ToString(), true);
            Tenant.Current.Direction = en;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ( Sample.SelectedIndex >= 2 )
                Tenant.Current.Direction = CalcDirection.FromQuantity;
            
            ViewModel.Regenerate(Sample.SelectedIndex);

            if (Sample.SelectedIndex == 4)
            {
                var line10 = (InvoiceLine10) ViewModel.InvoiceLine;
                line10.AddRuleWithParam(CustomRule.Text)
                    .WithModeAtStartup(BusinessRuleStartupMode.Evaluate)
                    .Start();
            }
        }

        private void Sample_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CD==null) return;

            CD.Visibility = Sample.SelectedIndex >= 2 ? Visibility.Collapsed : Visibility.Visible;
            CR.Visibility = Sample.SelectedIndex == 4 ? Visibility.Visible : Visibility.Collapsed;
            D.Visibility = Sample.SelectedIndex == 2 || Sample.SelectedIndex == 4 ? Visibility.Visible : Visibility.Collapsed;
        }
    }

    [NotifyPropertyChanged]
    public class ViewModel : EntityBase<ViewModel>
    {
        public ViewModel()
        {
            Debugger.Launch();
            try
            {
                User = User.Current;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Tenant = Tenant.Current;
            Regenerate(0);
        }

        public User User { get; set; }
        public Tenant Tenant { get; set; }
        public IInvoiceLine InvoiceLine { get; set; }

        public void Regenerate(int mode)
        {
            if (mode == 0)
                InvoiceLine = new InvoiceLine6();
            else if (mode == 1)
                InvoiceLine = new InvoiceLine7();
            else if (mode == 2)
                InvoiceLine = new InvoiceLine8();
            else if (mode == 3)
                InvoiceLine = new InvoiceLine9();
            else if (mode == 4)
                InvoiceLine = new InvoiceLine10();

            InvoiceLine.ProductPrice = 10;

            if (Tenant.Current.Direction == CalcDirection.FromTotal)
                InvoiceLine.Total = 50;
            else if (Tenant.Current.Direction == CalcDirection.FromQuantity)
                InvoiceLine.Quantity = 4;
        }
    }
}
