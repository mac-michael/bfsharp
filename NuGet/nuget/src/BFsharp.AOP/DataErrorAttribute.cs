using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using PostSharp.Extensibility;

namespace BFsharp.AOP
{
    [Serializable]
    [IntroduceInterface(typeof(IDataErrorInfo), OverrideAction = InterfaceOverrideAction.Ignore)]
    [MulticastAttributeUsage(MulticastTargets.Class, Inheritance = MulticastInheritance.Strict)]
    public sealed class DataErrorAttribute : InstanceLevelAspect, IDataErrorInfo
    {
        [ImportMember("Extensions", IsRequired = true, Order = ImportMemberOrder.BeforeIntroductions)]
        public Property<IEntityExtensions> Extensions;

        [IntroduceMember(OverrideAction = MemberOverrideAction.Ignore)]
        public string this[string columnName]
        {
            get
            {
                var message = string.Join(Environment.NewLine,
                                        Extensions.Get.Invoke().BrokenRules.Where(r => r.Severity == BrokenRuleSeverity.Error)
                                            .Select(r => r.Message).ToArray());

                return string.IsNullOrEmpty(message) ? null : message;
            }
        }

        [IntroduceMember(OverrideAction = MemberOverrideAction.Ignore)]
        public string Error
        {
            get { return string.Join(Environment.NewLine, Extensions.Get.Invoke().BrokenRules.Select(r => r.Message).ToArray()); }
        }
    }
}