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
using BFsharp.Samples.SL.Entites;
using Microsoft.Phone.Controls;
using BFsharp.Samples.SL;

namespace BFsharp.Samples.WP7
{
    public partial class AttributesView : PhoneApplicationPage
    {
        public AttributesView()
        {
            InitializeComponent();
            var businessRuleSample = new AttributeEntity();
            businessRuleSample.Extensions.InitializeRules();
            DataContext = businessRuleSample;
        }
    }
}