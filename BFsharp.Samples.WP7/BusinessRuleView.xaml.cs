using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using BFsharp.AOP;
using BFsharp.Samples.SL;
using Microsoft.Phone.Controls;

namespace BFsharp.Samples.WP7
{
    public partial class BusinessRuleView : PhoneApplicationPage
    {
        public BusinessRuleView()
        {
            InitializeComponent();
            var businessRuleSample = new BusinessRuleEntity();
            businessRuleSample.Extensions.InitializeRules();
            DataContext = businessRuleSample;
        }
    }
}