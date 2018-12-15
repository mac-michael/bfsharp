using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using PostSharp.Aspects;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Reflection;
using System.Linq;

namespace BFsharp.AOP
{
#if NET
    [MulticastAttributeUsage(MulticastTargets.Class, Inheritance = MulticastInheritance.Strict)]
    [Serializable]
    public class NotifyPropertyChangedAttribute : TypeLevelAspect, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            var type = targetElement as Type;
            if (type == null)
                return new AspectInstance[0];
            var list = new List<AspectInstance>();

            // Implement interface
            list.Add(new AspectInstance(targetElement, new AddNotifyPropertyChangedAttribute()));
            
            // Dependencies
            var dependencies = AspectHelper.AnalyzeDependencies(type);
            if (dependencies.Count > 0)
                list.Add(new AspectInstance(targetElement, new DependentNotifyPropertyChangedAspect(dependencies)));

            // Add setters
            const BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            foreach (var property in from p in ((Type)targetElement).GetProperties(bindingFlags)
                                     where p.CanWrite && !p.IsDefined(typeof(DontNotifyAttribute), true)
                                     select p)
            {
                var getter = property.GetGetMethod(true);
                if (getter.IsPublic)
                    list.Add(new AspectInstance(property, new AddSetterNotifyPropertyChangedAttribute()));
            }

            return list;
        }
    }

    internal class AspectHelper
    {
        public static Dictionary<string, string[]> AnalyzeDependencies(Type t)
        {
            var q = from p in t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    let a =
                        (NotifiedByAttribute)p.GetCustomAttributes(typeof(NotifiedByAttribute), true).FirstOrDefault()
                    where a != null
                    from d in a.Properties
                    select new { Target = d, Notify = p.Name };

            var q2 = from e in q
                     group e.Notify by e.Target;

            var c = q2.ToDictionary(k => k.Key, v => v.ToArray());

            return c;
        }

        public static Dictionary<string, string[]> AnalyzeDependenciesWP7(Type t)
        {
            return AnalyzeDependenciesInternal(t,
                                               "BFsharp.AOP.NotifiedByAttribute, BFsharp.AOP.WP7");
        }
        public static Dictionary<string, string[]> AnalyzeDependenciesSL(Type t)
        {
            return AnalyzeDependenciesInternal(t,
                                               "BFsharp.AOP.NotifiedByAttribute, BFsharp.AOP.SL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=96cdc67b89484745");
        }
        public static Dictionary<string, string[]> AnalyzeDependenciesInternal(Type t, string notifyByAttribute)
        {
            string type = notifyByAttribute;

            var notifiedByAttribute = Type.GetType(type, true);
            var propertyInfo = notifiedByAttribute.GetProperty("Properties");

            var q = from p in t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    let a =p.GetCustomAttributes(notifiedByAttribute, true).FirstOrDefault()
                    where a != null
                    from d in (string[])propertyInfo.GetValue(a, null)
                    select new { Target = d, Notify = p.Name };

            var q2 = from e in q
                     group e.Notify by e.Target;

            var c = q2.ToDictionary(k => k.Key, v => v.ToArray());

            return c;
        }
    }

    [MulticastAttributeUsage(MulticastTargets.Class, Inheritance = MulticastInheritance.Strict)]
    public sealed class ExternalNotifyPropertyChangedAttribute : IExternalAspectImplementation
    {
        public IEnumerable<AspectInstance> ProvideImplementationAspects(object targetElement,
            ObjectConstruction aspectConstruction)
        {
            var type = targetElement as Type;
            if (type == null)
                return new AspectInstance[0];
            var list = new List<AspectInstance>();

            // Implement interface
            list.Add(new AspectInstance(targetElement,
                                        new ObjectConstruction(
                                            "BFsharp.AOP.AddNotifyPropertyChangedAttribute, BFsharp.AOP.SL"),
                                        new AspectConfiguration()));

            // Dependencies
            var dependencies = AspectHelper.AnalyzeDependenciesSL(type);
            if (dependencies.Count > 0)
            {
                // Silverlight aspects do not support complex constructor parameters
                var x = from d in dependencies
                        select d.Key + ":" + string.Join(",", d.Value.ToArray());

                var param = string.Join(";", x.ToArray());
                //var array = new string[]{"ab", "bc"};
                var oc = new ObjectConstruction("BFsharp.AOP.DependentNotifyPropertyChangedAspect, BFsharp.AOP.SL", param);
                list.Add(new AspectInstance(targetElement,oc,new AspectConfiguration()));
            }

            var dontNotifyAttributeName =
                "BFsharp.AOP.DontNotifyAttribute, BFsharp.AOP.SL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=96cdc67b89484745";
            var dontNotifyAttribute = Type.GetType(dontNotifyAttributeName);

            // Add setters
            const BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;

            foreach ( var property in
                    from p in ((Type)targetElement).GetProperties(bindingFlags)
                    where p.CanWrite && !p.IsDefined(dontNotifyAttribute, true)
                    select p)
            {
                var getter = property.GetGetMethod(true);
                if (getter.IsPublic)
                {
                    list.Add(new AspectInstance(property, new ObjectConstruction(
                                                               "BFsharp.AOP.AddSetterNotifyPropertyChangedAttribute, BFsharp.AOP.SL"),
                                            new AspectConfiguration()));
                }
            }
            
            return list;
        }
    }

    [MulticastAttributeUsage(MulticastTargets.Class, Inheritance = MulticastInheritance.Strict)]
    public sealed class ExternalNotifyPropertyChangedAttributeWP7 : IExternalAspectImplementation
    {
        public IEnumerable<AspectInstance> ProvideImplementationAspects(object targetElement,
            ObjectConstruction aspectConstruction)
        {
            var type = targetElement as Type;
            if (type == null)
                return new AspectInstance[0];
            var list = new List<AspectInstance>();

            // Implement interface
            list.Add(new AspectInstance(targetElement,
                                        new ObjectConstruction(
                                            "BFsharp.AOP.AddNotifyPropertyChangedAttribute, BFsharp.AOP.WP7"),
                                        new AspectConfiguration()));

            // Dependencies
            var dependencies = AspectHelper.AnalyzeDependenciesWP7(type);
            if (dependencies.Count > 0)
            {
                // Silverlight aspects do not support complex constructor parameters
                var x = from d in dependencies
                        select d.Key + ":" + string.Join(",", d.Value.ToArray());

                var param = string.Join(";", x.ToArray());
                //var array = new string[]{"ab", "bc"};
                var oc = new ObjectConstruction("BFsharp.AOP.DependentNotifyPropertyChangedAspect, BFsharp.AOP.WP7", param);
                list.Add(new AspectInstance(targetElement, oc, new AspectConfiguration()));
            }

            var dontNotifyAttributeName =
                "BFsharp.AOP.DontNotifyAttribute, BFsharp.AOP.WP7, Version=1.0.0.0";
            var dontNotifyAttribute = Type.GetType(dontNotifyAttributeName);

            // Add setters
            const BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;

            foreach (var property in
                    from p in ((Type)targetElement).GetProperties(bindingFlags)
                    where p.CanWrite && !p.IsDefined(dontNotifyAttribute, true)
                    select p)
            {
                var getter = property.GetGetMethod(true);
                if (getter.IsPublic)
                {
                    list.Add(new AspectInstance(property, new ObjectConstruction(
                                                               "BFsharp.AOP.AddSetterNotifyPropertyChangedAttribute, BFsharp.AOP.WP7"),
                                            new AspectConfiguration()));
                }
            }

            return list;
        }
    }
#elif SILVERLIGHT
    [ExternalAspectConfiguration("BFsharp.AOP.ExternalNotifyPropertyChangedAttribute, BFsharp.AOP")]
    [MulticastAttributeUsage(MulticastTargets.Class, Inheritance = MulticastInheritance.Strict, AllowMultiple=false)]
    public class NotifyPropertyChangedAttribute : ExternalAspect
    {
    }
#elif PHONE
    [ExternalAspectConfiguration("BFsharp.AOP.ExternalNotifyPropertyChangedAttributeWP7, BFsharp.AOP")]
    [MulticastAttributeUsage(MulticastTargets.Class, Inheritance = MulticastInheritance.Strict, AllowMultiple=false)]
    public class NotifyPropertyChangedAttribute : ExternalAspect
    {
    }
#endif
}