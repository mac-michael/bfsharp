using System.Collections.Generic;
using System.Diagnostics;
using PostSharp.Aspects;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace BFsharp.AOP
{
#if !SILVERLIGHT
    public class EntityBaseAttribute : TypeLevelAspect, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            yield return new AspectInstance(targetElement, new NotifyPropertyChangedAttribute());
            yield return new AspectInstance(targetElement, new DataErrorAttribute());
            yield return new AspectInstance(targetElement, new ImplementExtensionsAttribute());
        }
    }

    [MulticastAttributeUsage(MulticastTargets.Class | MulticastTargets.Struct | MulticastTargets.Assembly)]
    public sealed class ExternalEntityBaseImplementation : IExternalAspectImplementation
    {
        public IEnumerable<AspectInstance> ProvideImplementationAspects(object targetElement,
            ObjectConstruction aspectConstruction)
        {
            yield return new AspectInstance(targetElement,
                                            new ObjectConstruction(
                                                "BFsharp.AOP.NotifyPropertyChangedAttribute, BFsharp.AOP.SL"),
                                            new AspectConfiguration());

            yield return new AspectInstance(targetElement,
                                            new ObjectConstruction(
                                                "BFsharp.AOP.ImplementExtensionsAttribute, BFsharp.AOP.SL"),
                                            new AspectConfiguration());

            yield return new AspectInstance(targetElement,
                                            new ObjectConstruction(
                                                "BFsharp.AOP.DataErrorAttribute, BFsharp.AOP.SL"),
                                            new AspectConfiguration());

            yield return new AspectInstance(targetElement,
                                            new ObjectConstruction(
                                                "BFsharp.AOP.SL.NotifyDataErrorInfoAttribute, BFsharp.AOP.SL"),
                                            new AspectConfiguration());
        }
    }
#else
    [ExternalAspectConfiguration("BFsharp.AOP.ExternalEntityBaseImplementation, BFsharp.AOP")]
    [MulticastAttributeUsage(MulticastTargets.Class | MulticastTargets.Struct, PersistMetaData = true)]
    public class EntityBaseAttribute : ExternalAspect
    {
    }
#endif
}