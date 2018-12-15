using System;
using System.Windows.Controls;

namespace BFsharp.Samples.SL
{
    public class RuleDataForm<T> : RuleDataForm
        where T : IEntityBase, new()
    {
        public T Object
        {
            get { return (T) _dataForm.CurrentItem; }
            set { _dataForm.CurrentItem = value; }
        }

        public RuleDataForm()
        {
            var product = new T();
            product.Extensions.InitializeRules();
            Object = product;
        }
    }

    public class RuleDataForm : UserControl 
    {
        public string Code { get; set; }

        protected readonly DataForm _dataForm;

        public RuleDataForm()
        {
            var panel = new StackPanel();

            _dataForm= new DataForm();
            _dataForm.AutoGeneratingField += Form_AutoGeneratingField;
            _dataForm.AutoEdit = true;
            panel.Children.Add(_dataForm);

            Content = panel;
        }
            
        static void Form_AutoGeneratingField(object sender, DataFormAutoGeneratingFieldEventArgs e)
        {
            if (e.PropertyName == "Extensions" || e.PropertyName == "Error" || e.PropertyName == "HasErrors")
                e.Cancel = true;
        }
    }
}