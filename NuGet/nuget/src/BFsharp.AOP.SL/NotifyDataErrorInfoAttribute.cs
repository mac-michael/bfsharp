using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace BFsharp.AOP
{
    [IntroduceInterface(typeof(INotifyDataErrorInfo), OverrideAction = InterfaceOverrideAction.Ignore)]
    [MulticastAttributeUsage(MulticastTargets.Class, Inheritance = MulticastInheritance.Strict)]
    public sealed class NotifyDataErrorInfoAttribute : InstanceLevelAspect, INotifyDataErrorInfo
    {
        [ImportMember("Extensions", IsRequired = true, Order = ImportMemberOrder.BeforeIntroductions)]
        public Property<IEntityExtensions> Extensions;

        public override void RuntimeInitializeInstance()
        {
            Extensions.Get().BrokenRules.RuleBroken += OnBrokenRuleChanged;
            Extensions.Get().BrokenRules.RuleRepaired += OnBrokenRuleChanged;
            base.RuntimeInitializeInstance();
        }

        void OnBrokenRuleChanged(object sender, BrokenRuleEventArgs e)
        {
            var errorChanged = ErrorsChanged;
            if (errorChanged!= null)
                errorChanged(this, new DataErrorsChangedEventArgs(e.BrokenRule.Owner));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return Extensions.Get.Invoke().BrokenRules.Where(r => r.Owner == propertyName);
        }

        public bool HasErrors
        {
            get { return Extensions.Get.Invoke().BrokenRules.Count > 0; }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    }
}