using System;
using System.Linq;
using System.Reflection;
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using PostSharp.Extensibility;

namespace BFsharp.AOP
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Property, Inheritance = MulticastInheritance.None, AllowMultiple = false)]
    public sealed class AddSetterNotifyPropertyChangedAttribute : LocationInterceptionAspect
    {
        public override void OnSetValue(LocationInterceptionArgs args)
        {
            // Don't go further if the new value is equal to the old one.
            if (args.Value == null && args.GetCurrentValue() == null) return;
            if (args.Value != null && args.Value.Equals(args.GetCurrentValue())) return;

            // Actually sets the value.
            args.ProceedSetValue();

            var rnpc = (args.Instance as IRaiseNotifyPropertyChanged);
            if (rnpc != null)
                rnpc.RaisePropertyChanged(args.Location.Name);
        }
    }
}