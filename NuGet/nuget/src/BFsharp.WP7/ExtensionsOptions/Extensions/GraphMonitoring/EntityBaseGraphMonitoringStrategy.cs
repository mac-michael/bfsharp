using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace BFsharp
{
    public class EntityBaseGraphMonitoringStrategy<T> : HierarchyGraphMonitoringStrategy
    {
        public EntityBaseGraphMonitoringStrategy()
        {
            foreach (var p in ReflectionHelper.GetProperties<T>()
                .Where(p => HasTraversal(typeof(T), p)))
            {
                if ((typeof(IEntityBase).IsAssignableFrom(p.PropertyType)))
                {
                    var propertySelector = PrecompilationHelper
                        .GetPropertySelector<object>(p);
                    Properties.Add(p.Name, propertySelector);
                }
                var paramType = p.PropertyType.GetIEnumerableGenericParam();
                if (paramType != null)
                {
                    if ((typeof(IEntityBase).IsAssignableFrom(paramType)))
                    {
                        Func<object, IEnumerable> collectionSelector = PrecompilationHelper.GetPropertySelector<object, IEnumerable>(p);
                        Collections.Add(p.Name, collectionSelector);
                    }
                }
            }
        }

        protected virtual bool HasTraversal( Type parentType, PropertyInfo propertyInfo )
        {
            if (propertyInfo.IsDefined(typeof(IgnoreTraversalAttribute), true))
                return false;

            return true;
        }

        public override IEntityExtensions GetIEntityExtensionsFromObject(object element)
        {
            if (element is IEntityBase)
                return ((IEntityBase) element).Extensions;

            return null;
        }
    }
}