using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using PostSharp.Aspects;
using PostSharp.Aspects.Advices;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace BFsharp.AOP
{
    [Serializable]
    public sealed class ImplementExtensionsAttribute : LocationInterceptionAspect
    {
#if NET
        public override bool CompileTimeValidate(LocationInfo locationInfo)
        {
            var propertyType = locationInfo.PropertyInfo.PropertyType;
            if (!propertyType.ContainsGenericParameters)
            {
                var t = Type.GetType(propertyType.AssemblyQualifiedName, true);

                if (t.IsAssignableFrom(typeof(IEntityExtensions)))
                {
                    return base.CompileTimeValidate(locationInfo);
                }
            }

            Message.Write(SeverityType.Error, "CX0001", "ImplementExtensionsAttribute can only be applied to property with type IEntityExtensions");
            return false;
        }
#endif
        public override void OnGetValue(LocationInterceptionArgs args)
        {
            var eb = ((IEntityBase)args.Instance);
            args.SetNewValue(eb.Extensions.GetTypeSafe<string>());
        }
    }
}