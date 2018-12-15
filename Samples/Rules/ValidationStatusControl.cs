using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using BFsharp;

namespace Rules
{
    [TemplatePart(Name = "errorImage", Type = typeof(FrameworkElement))]
    [TemplatePart(Name = "popup", Type = typeof(Popup))]
    [TemplatePart(Name = "text", Type = typeof(TextBlock))]
    [TemplateVisualState(Name = "Valid", GroupName = "CommonStates")]
    [TemplateVisualState(Name = "Error", GroupName = "CommonStates")]
    public class ValidationStatusControl : ContentControl
    {

        public static readonly DependencyProperty DisplayMemberProperty =
                  DependencyProperty.Register("DisplayMember", typeof(string), typeof(ValidationStatusControl),
                                  new PropertyMetadata(new PropertyChangedCallback(DisplayMemberChangedCallback)));

        public static readonly DependencyProperty EntityProperty =
                  DependencyProperty.Register("Entity", typeof(EntityBase), typeof(ValidationStatusControl),
                                  new PropertyMetadata(new PropertyChangedCallback(EntityChangedCallback)));

        private ObservableCollection<BrokenRule> fieldErrors = new ObservableCollection<BrokenRule>();

        public ValidationStatusControl()
            : base()
        {
            DefaultStyleKey = typeof(ValidationStatusControl);
            IsTabStop = false;
        }

        private void UpdateStates(bool useTransitions)
        {
            DisablePopup();

            if (isValid)
            {
                VisualStateManager.GoToState(this, "Valid", useTransitions);
            }
            else
            {
                VisualStateManager.GoToState(this, "Error", useTransitions);
                EnablePopup();
            }
        }

        private void EnablePopup()
        {
            if (image != null)
            {
                image.MouseEnter += new MouseEventHandler(image_MouseEnter);
                image.MouseLeave += new MouseEventHandler(image_MouseLeave);
            }
        }

        private void DisablePopup()
        {
            if (image != null)
            {
                image.MouseEnter -= new MouseEventHandler(image_MouseEnter);
                image.MouseLeave -= new MouseEventHandler(image_MouseLeave);
            }
        }

        private void image_MouseEnter(object sender, MouseEventArgs e)
        {
            if (popup != null && sender is UIElement)
            {
                Point p = e.GetPosition((UIElement)sender);
                Size size = ((UIElement)sender).DesiredSize;
                // ensure events are attached only once.
                popup.Child.MouseLeave -= new MouseEventHandler(popup_MouseLeave);
                popup.Child.MouseLeave += new MouseEventHandler(popup_MouseLeave);

                popup.VerticalOffset = p.Y + size.Height;
                popup.HorizontalOffset = p.X + size.Width;
                popup.IsOpen = true;
            }
        }

        private void image_MouseLeave(object sender, MouseEventArgs e)
        {
            popup.IsOpen = false;
        }

        void popup_MouseLeave(object sender, MouseEventArgs e)
        {
            popup.IsOpen = false;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            image = GetTemplateChild("errorImage") as FrameworkElement;
            popup = GetTemplateChild("popup") as Popup;
            text = GetTemplateChild("text") as TextBlock;

            UpdatePopupText();

            UpdateStates(false);
        }

        private FrameworkElement image;
        private Popup popup;
        private TextBlock text;

        private bool isValid = true;
        private string errorMessage;

        private string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;

                isValid = string.IsNullOrEmpty(errorMessage);

                UpdateStates(true);

                UpdatePopupText();
            }
        }



        private void UpdatePopupText()
        {
            if (text != null)
                text.Text = errorMessage;
        }

        private static void DisplayMemberChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //var el = d as ValidationStatus;

            //if (el != null)
            //  el.ErrorMessage = GetErrorMessage();
        }

        private static void EntityChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ValidationStatusControl status = d as ValidationStatusControl;
            Debug.Assert(status != null);

            EventHandler<BrokenRuleEventArgs> ruleRep = delegate(object sender, BrokenRuleEventArgs args) { RuleChanged(status, args, true); };
            EventHandler<BrokenRuleEventArgs> ruleBreak = delegate(object sender, BrokenRuleEventArgs args) { RuleChanged(status, args, false); };



            if (e.OldValue != null)
            {
                var c = ((EntityBase)e.OldValue).Extensions.BrokenRules;

                c.RuleRepaired -= ruleRep;
                c.RuleBroken -= ruleBreak;
                foreach (var brokenRule in c)
                    RuleChanged(status, new BrokenRuleEventArgs(brokenRule), true);
            }

            if (e.NewValue == null) return;

            {
                var c = ((EntityBase)e.NewValue).Extensions.BrokenRules;
             
                c.RuleRepaired += ruleRep;
                c.RuleBroken += ruleBreak;

                foreach (var brokenRule in c)
                    RuleChanged(status, new BrokenRuleEventArgs(brokenRule), false);
            }
        }

        static void RuleChanged(ValidationStatusControl status, BrokenRuleEventArgs args, bool isValid)
        {

            if (!isValid)
                status.fieldErrors.Add(args.BrokenRule);
            else
                status.fieldErrors.Remove(args.BrokenRule);

            var strs = from brokenRule in status.fieldErrors
                       select brokenRule.Message;

            status.ErrorMessage = string.Join(Environment.NewLine, strs.ToArray());
        }

        public EntityBase Entity
        {
            get
            {
                return (EntityBase) GetValue(EntityProperty);
            }

            set
            {
                SetValue(EntityProperty, value);

            }
        }

        public string DisplayMember
        {
            get
            {
                return (string)GetValue(DisplayMemberProperty);
            }

            set { SetValue(DisplayMemberProperty, value); }
        }
    }

}