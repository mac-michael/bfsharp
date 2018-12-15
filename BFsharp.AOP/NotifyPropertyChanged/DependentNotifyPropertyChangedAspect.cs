using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using PostSharp.Aspects;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;

namespace BFsharp.AOP
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Class, Inheritance = MulticastInheritance.None, AllowMultiple=false)]
    public sealed class DependentNotifyPropertyChangedAspect : InstanceLevelAspect
    {
        public Dictionary<string, string[]> DependentProperties { get; set; }

        public DependentNotifyPropertyChangedAspect(string param)
        {
            DependentProperties = param.Split(';').Select(p => p.Split(':')).ToDictionary(p => p[0], p => p[1].Split(','));
        }
        
        public DependentNotifyPropertyChangedAspect(Dictionary<string, string[]> dependentProperties)
        {
            DependentProperties = dependentProperties;
        }

        // Do not comment, if this method is not present RuntimeInitializeInstance is not called
        public override void RuntimeInitialize(Type type)
        {
            base.RuntimeInitialize(type);
        }
        
        public override void RuntimeInitializeInstance()
        {
            base.RuntimeInitializeInstance();
            var npc = (this.Instance as INotifyPropertyChanged);
            if (npc == null)
            {
                Debug.WriteLine("DependentNotifyPropertyChangedAspect cannot find INotifyPropertyChanged");
                return;
            }

            npc.PropertyChanged += OnPropertyChanged;
        }

        void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var rnpc = Instance as IRaiseNotifyPropertyChanged;
            if ( rnpc == null) return;

            string[] properties;
            if (DependentProperties.TryGetValue(e.PropertyName, out properties))
                foreach (var property in properties)
                    rnpc.RaisePropertyChanged(property);
        }
    }
}