using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace BFsharp.Samples.WP7
{
    public class BrokenRuleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var brokenRuleCollection = (BrokenRuleCollection)value;
            if (brokenRuleCollection == null)
                return "";
            return string.Join(Environment.NewLine, brokenRuleCollection.Select(b => b.Message).ToArray());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}