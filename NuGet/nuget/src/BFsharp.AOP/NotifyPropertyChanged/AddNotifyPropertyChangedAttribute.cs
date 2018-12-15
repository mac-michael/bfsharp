using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace BFsharp.AOP
{
    [Serializable]
    [IntroduceInterface(typeof(IRaiseNotifyPropertyChanged), OverrideAction = InterfaceOverrideAction.Ignore)]
    [IntroduceInterface(typeof(INotifyPropertyChanged), OverrideAction = InterfaceOverrideAction.Ignore)]
    [MulticastAttributeUsage(MulticastTargets.Class, Inheritance = MulticastInheritance.None, AllowMultiple = false)]
    public sealed class AddNotifyPropertyChangedAttribute : InstanceLevelAspect, IRaiseNotifyPropertyChanged, INotifyPropertyChanged
    {
        [ImportMember("OnPropertyChanged", IsRequired = false)]
        public Action<PropertyChangedEventArgs> OnPropertyChangedMethod;

        [ImportMember("OnPropertyChanged", IsRequired = false)]
        public Action<string> OnPropertyChangedStringMethod;

        [ImportMember("RaisePropertyChanged", IsRequired = false)]
        public Action<PropertyChangedEventArgs> RaisePropertyChangedMethod;

        [ImportMember("RaisePropertyChanged", IsRequired = false)]
        public Action<string> RaisePropertyChangedStringMethod;

        [IntroduceMember(OverrideAction = MemberOverrideAction.Ignore)]
        public event PropertyChangedEventHandler PropertyChanged;
        
        [IntroduceMember(Visibility = Visibility.Family, IsVirtual = true,
           OverrideAction = MemberOverrideAction.Ignore)]
        public void AOP_OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(Instance, e);
        }

        public void RaisePropertyChanged(string propertyName)
        {
            if (OnPropertyChangedMethod != null)
                OnPropertyChangedMethod(new PropertyChangedEventArgs(propertyName));
            else if (OnPropertyChangedStringMethod != null)
                OnPropertyChangedStringMethod(propertyName);
            else if (RaisePropertyChangedMethod != null)
                RaisePropertyChangedMethod(new PropertyChangedEventArgs(propertyName));
            else if (RaisePropertyChangedStringMethod != null)
                RaisePropertyChangedStringMethod(propertyName);
            else
                AOP_OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
}
