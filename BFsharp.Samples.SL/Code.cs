
using System;

namespace BFsharp.Samples.SL
{
	internal class Code
	{
		public const string MyEntityBase = @"public class MyEntityBase<T> where T : MyEntityBase<T>
{
    private IEntityExtensions<T> _extensions;
    public IEntityExtensions<T> Extensions
    {
        get
        {
            if (_extensions == null)
                _extensions = EntityExtensions.RegisterObject(this).GetTypeSafe<T>();

            return _extensions;
        }
    }
}";
		public const string Receipt = @"[NotifyPropertyChanged]
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
}";
		public const string ReceiptForm = @"[Sample(@""Samples\Receipt"", Code.Receipt)]
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
        total.SetBinding(TextBox.TextProperty, new Binding(""TotalGrossPrice""));
        stackPanel.Children.Add(new TextBlock() { Text = ""TotalGrossPrice"", Margin = new Thickness(0, 5, 0, 5) });
        stackPanel.Children.Add(total);
        stackPanel.Children.Add(new TextBlock(){Text=""Lines"", Margin = new Thickness(0,5,0,5)});
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
        if (e.PropertyName == ""Extensions"" || e.PropertyName == ""Error"" || e.PropertyName == ""HasErrors"" )
            e.Cancel = true;
    }
}";
		public const string UserRegistrationForm = @"[NotifyPropertyChanged]
[Sample(@""Samples\UserRegistrationForm"", Code.UserRegistrationForm)]
public class UserRegistrationForm : EntityBase<UserRegistrationForm>
{
    public UserRegistrationForm()
    {
        Birthday = DateTime.Now;
    }
    [Email, Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
    [Required]
    public string ConfirmPassword { get; set; }

    public DateTime Birthday { get; set; }

    [ShouldBe(true)]
    public bool AcceptLicence { get; set; }

    [RuleInit]
    public void RuleInit()
    {
        Extensions.CreateValidationRule(r => string.IsNullOrEmpty(ConfirmPassword) || r.Password == r.ConfirmPassword)
            .WithMessage(""Confirm password doesn't match."")
            .WithOwner(r=>r.ConfirmPassword)
            .Start();

        Extensions.CreateValidationRule(r => DateTime.Now.AddYears(-18) > r.Birthday)
            .WithMessage(""You should be at least 18 years old."")
            .WithOwner(r=>r.Birthday) // BUG: DependencyDetection
            .Start();
    }

    [RuleDecorator]
    public static void RuleDecorator(Rule rule)
    {
        // ASP.Net validation behaviour - start validation only after first edit
        if (rule is ValidationRule)
            ((ValidationRule) rule).WithModeAtStartup(ValidationRuleStartupMode.None);
    }
}";
		public const string ValidationRuleEntity = @"Extensions
    .CreateValidationRule(e => e.Value + e.Value2 == e.Total)
    .WithMessage(""Total should equals Value + Value2"")
    .WithSeverity(BrokenRuleSeverity.Error)
    .WithOwner(e => e.Total)
    .Start();";
		public const string AttributeEntity = @"[NotifyPropertyChanged]
[Sample(@""Rules\ValidationRule\Attributes"", Code.AttributeEntity)]
public class AttributeEntity : EntityBase
{
    [Range(4,8)]
    public int Value { get; set; }

    [Range(""0.5"", ""4.3"")]
    public decimal Value2 { get; set; }

    [Required]
    public string Total { get; set; }

    [Email]
    public string Email { get; set; }

    [Pattern(""a.*"", Message=""Value must start with letter a."")]
    public string Pattern { get; set; }
}";
		public const string BusinessRuleEntity = @"Extensions.CreateBusinessRule(e => e.Value + e.Value2, e => e.Total).Start();";
		public const string ExceptionFilter = @"Extensions
    .CreateBusinessRule(e => e.Value / e.Value2, e => e.Result)
    .WithException<DivideByZeroException>(""Division by zero."", BrokenRuleSeverity.Error, ""Result"")
    .Start();";
		public const string RecursiveRule = @"Extensions
    .CreateBusinessRule(e => e.Value + 1, e => e.Value)
    .DisableRecursion()
    .Start();";
		public const string RuleSuppression = @"var r= Extensions
    .CreateBusinessRule(e => (e.Rate + 1)*e.Net, e => e.Gross)
    .Start();

var r2 =Extensions
    .CreateBusinessRule(e => e.Gross/(e.Rate + 1), e => e.Net)
    .Start();

r.MutuallySuppressedBy(r2);
r.Evaluate();";
	}
}
