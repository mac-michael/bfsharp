using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;

namespace BFsharp
{
    public class ManualIEntityBaseGraphMonitoringStrategy<T> : HierarchyGraphMonitoringStrategy
    {
        public ManualIEntityBaseGraphMonitoringStrategy<T> WithProperties(params Expression<Func<T,object>>[] propertySelectors)
        {
            foreach (var propertySelector in propertySelectors)
            {
                var p = DependencyHelper.GetPropertyPath(propertySelector);
                if (p.Count() != 1)
                    throw new InvalidOperationException("Invalid propertySelector");

                var s = propertySelector.Compile();

                Properties.Add(p.Single(), o => s((T) o));
            }

            return this;
        }

       public ManualIEntityBaseGraphMonitoringStrategy<T> WithCollections(params Expression<Func<T,IEnumerable>>[] collectionSelectors)
       {
           foreach (var collectionSelector in collectionSelectors)
           {
               var p = DependencyHelper.GetPropertyPath(collectionSelector);
               if (p.Count() != 1)
                   throw new InvalidOperationException("Invalid collectionSelector");

               var s = collectionSelector.Compile();

               Properties.Add(p.Single(), o => s((T) o));
           }
           return this;
       }

        public override IEntityExtensions GetIEntityExtensionsFromObject(object element)
        {
            if (element is IEntityBase)
                return ((IEntityBase)element).Extensions;

            return null;
        }
    }
}