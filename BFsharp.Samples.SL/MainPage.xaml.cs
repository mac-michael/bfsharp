using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Samples.SyntaxHighlighting;
using BFsharp.Samples.SL.Samples;

namespace BFsharp.Samples.SL
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            Source.SourceLanguage = SourceLanguageType.CSharp;


            Samples = new SampleItem();
            
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes()
                .Where(a=>a.IsDefined(typeof(SampleAttribute), true)))
            {
                var sampleAttribute = (SampleAttribute)type.GetCustomAttributes(typeof(SampleAttribute), true).Single();

                var t2 = type;
                Func<UserControl> f;
                if (type.IsSubclassOf(typeof(UserControl)))
                    f = () => (UserControl) Activator.CreateInstance(t2);
                else
                {
                    var t = typeof(RuleDataForm<>).MakeGenericType(type);
                    f = () => (UserControl)Activator.CreateInstance(t);
                }
                BuildSampleItem(sampleAttribute.Path, f);
            }

            foreach (var s in Samples.Items)
                TransformMenu(null, s);
        }

        SampleItem Samples { get; set; }

        private void BuildSampleItem(string path, Func<UserControl> control)
        {
            BuildSampleItem(path, control, Samples);
        }

        private static void BuildSampleItem(string path, Func<UserControl> control, SampleItem root)
        {
            var names = path.Split('\\');
            if (names.Length > 1)
            {
                var p = root.Items.FirstOrDefault(s => s.Name == names[0]);
                if (p == null)
                {
                    p = new SampleItem { Name = names[0] };
                    root.Items.Add(p);
                }
                BuildSampleItem(string.Join(@"\", names.Skip(1).ToArray()), control, p);
            }
            else
            {
                var p = root.Items.FirstOrDefault(s => s.Name == names[0]);
                if (p == null)
                    root.Items.Add(new SampleItem {Name = names[0], Control = control});
                else
                    p.Control = control;
            }
        }

        private void TransformMenu(TreeViewItem tree, SampleItem item)
        {
            var tree2 = new TreeViewItem();
            if ( item.Control != null)
                tree2.FontWeight=FontWeights.Bold;
            tree2.Header = item;
            tree2.IsExpanded = true;

            if (tree == null)
                treeView1.Items.Add(tree2);
            else
                tree.Items.Add(tree2);

            foreach (var i in item.Items)
                TransformMenu(tree2, i);
        }

        private void treeView1_SelectedItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e)
        {
            Sample.Children.Clear();

            var item = (SampleItem)((TreeViewItem) e.NewValue).Header;
            Source.Text = "";

            if (item.Control != null)
            {
                var userControl = item.Control();
                Sample.Children.Add(userControl);

                var type = userControl.GetType();

                if (type.IsGenericType && typeof (RuleDataForm<>) == type.GetGenericTypeDefinition())
                    type = type.GetGenericArguments()[0];

                var sampleAttribute = (SampleAttribute) type.GetCustomAttributes(
                    typeof (SampleAttribute), true).FirstOrDefault();

                if (sampleAttribute == null)
                {
                    Source.Visibility = Visibility.Collapsed;
                }
                else
                {
                    Source.Visibility = string.IsNullOrEmpty(sampleAttribute.Code)
                                            ? Visibility.Collapsed
                                            : Visibility.Visible;

                    Source.Text = sampleAttribute.Code;
                }
            }
        }
    }
}
