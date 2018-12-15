using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace BFsharp.Samples.WP7
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                var xaml = string.Format("/{0}.xaml", ((FrameworkElement) e.AddedItems[0]).Tag);
                NavigationService.Navigate(new Uri(xaml, UriKind.Relative));
            }

            Menu.SelectedItem = null;
        }
    }
}