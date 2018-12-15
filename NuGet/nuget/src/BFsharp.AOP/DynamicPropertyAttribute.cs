using System;
using PostSharp.Aspects;

namespace BFsharp.AOP
{
    [Serializable]
    // BUG: NotifyPropertyChanged !!!
    public sealed class DynamicPropertyAttribute : LocationInterceptionAspect, IInstanceScopedAspect
    {
        public object CreateInstance(AdviceArgs adviceArgs)
        {
            return MemberwiseClone();
        }

        public void RuntimeInitializeInstance()
        {
        
        }

        public override void OnGetValue(LocationInterceptionArgs args)
        {
            var eb = args.Instance as IEntityBase;
            if (eb == null)
                throw new InvalidOperationException("Object doesn't implement IEntityBase");

            args.Value = eb.Extensions.DynamicProperties[args.LocationName];
        }

        public override void OnSetValue(LocationInterceptionArgs args)
        {
            var eb = args.Instance as IEntityBase;
            if (eb == null)
                throw new InvalidOperationException("Object doesn't implement IEntityBase");

            eb.Extensions.DynamicProperties[args.LocationName] = args.Value;
        }
    }
}