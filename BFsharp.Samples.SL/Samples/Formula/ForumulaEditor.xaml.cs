using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using BFsharp.Formula;

namespace BFsharp.Samples.SL.Samples
{
    public class Sample
    {
        public string Formula { get; set; }
        public string Name { get; set; }

        public bool Math { get; set; }
        public bool Date { get; set; }
        public bool All { get; set; }
        public string Using { get; set; }
        public bool SampleEntity { set; get; }
        public bool Custom { set; get; }
    }

    [Sample("Formula editor")]
    public partial class ForumulaEditor : UserControl
    {
        public ForumulaEditor()
        {
            InitializeComponent();
            Formula.Focus();
            Formula.SelectAll();

            DataContext = new[]
                              {
                                  new Sample
                                      {
                                          Math = true,
                                          Formula = "2+2*2 + max(4,5)",
                                          Name = "Math"
                                      },
                                  new Sample
                                      {
                                          SampleEntity = true,
                                          Formula = "s.Name + \" \" + s.SureName",
                                          Name = "SampleEntity"
                                      },
                                  new Sample
                                      {
                                          All = true,
                                          Using = "System",
                                          Formula = "Environment.ProcessorCount",
                                          Name = ".Net"
                                      },
                                  new Sample
                                      {
                                          Date = true,
                                          Formula = "Now + Hour",
                                          Name = "Date & Time"
                                      },
                                  new Sample
                                      {
                                          Custom = true,
                                          Formula = "rand(50) * 3",
                                          Name = "Custom"
                                      },
                                  new Sample
                                      {
                                          All = true,
                                          Custom = true,
                                          SampleEntity = true,
                                          Math=true,
                                          Date=true,
                                          Formula = "1+3",
                                          Name = "All"
                                      }
                              };

            Samples.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _func = null;

            var compiler = new FormulaCompiler();
            if (Custom.IsChecked ?? false)
            {
                compiler.
                    WithMethod("rand", () => new Random(Environment.TickCount).Next())
                    .WithMethod("rand", (int max) => new Random(Environment.TickCount).Next(max))
                    .WithMethod("p", (int p) => 5);
            }
            if (Math.IsChecked ?? false)
                compiler.WithMath();
            if (Date.IsChecked ?? false)
                compiler.WithDate();
            if (All.IsChecked ?? false)
            {
                var a = new AssemblyCallProvider()
                    .AddAssembly("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
                    .AddAssembly("mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
                    .AddAssembly("System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
                    .Using(Using.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                    .WithExtensionMethods();
                compiler.With(a);
            }

            if (SampleEntity.IsChecked ?? false)
            {
                compiler.WithType<SampleEntity>();
                var f = compiler.NewLambda()
                    .WithParam<SampleEntity>("s")
                    .Returns<object>()
                    .Compile(Formula.Text);
                if (f != null)
                    _func = () => f(new SampleEntity());
            }
            else
                _func = compiler.Compile<object>(Formula.Text);

            Status.Text = compiler.BuildInfo.Message;

            Button_Click_1(null, null);
        }

        private Func<object> _func;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (_func== null) return;

            var res = _func();
            Results.Text = res.ToString();
        }
    }
}
