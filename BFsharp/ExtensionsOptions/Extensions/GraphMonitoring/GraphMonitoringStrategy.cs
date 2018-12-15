using System;
using System.Collections;
using System.Collections.Generic;

namespace BFsharp
{
    public abstract class GraphMonitoringStrategy
    {
        protected GraphMonitoringStrategy()
        {
            Properties = new Dictionary<string, Func<object, object>>();
            Collections = new Dictionary<string, Func<object, IEnumerable>>();
        }

        public Dictionary<string, Func<object, object>> Properties { get; private set; }
        public Dictionary<string, Func<object, IEnumerable>> Collections { get; private set; }

        public virtual IEntityExtensions GetIEntityExtensionsFromObject(object element)
        {
            return null;
        }

        public virtual void Initialize(EntityExtensions extensions) { }

        #region Protected
        protected IEntityExtensions GetProperty(object target, string propertyName)
        {
            Func<object, object> selector;
            Properties.TryGetValue(propertyName, out selector);

            if (selector == null) return null;
            return GetProperty(target, selector);
        }
        protected IEntityExtensions GetProperty(object target, Func<object, object> propertySelector)
        {
            IEntityExtensions extensions = null;

            try
            {
                var propertyValue = propertySelector(target);
                extensions = GetIEntityExtensionsFromObject(propertyValue);
            }
            catch (Exception e)
            {
                if (ExceptionHelper.IsNonrecoverableException(e))
                    throw;
            }
            return extensions;
        }

        public IEnumerable<IEntityExtensions> GetProperties(object target)
        {
            foreach (var propertySelector in Properties.Values)
            {
                var extensions = GetProperty(target, propertySelector);
                if (extensions != null)
                    yield return extensions;
            }
        }

        protected IEnumerable GetCollection(object target, string collectionName)
        {
            Func<object, IEnumerable> selector;
            Collections.TryGetValue(collectionName, out selector);

            if (selector == null) return null;
            return GetCollection(target, selector);
        }
        protected IEnumerable GetCollection(object target, Func<object, IEnumerable> collectionSelector)
        {
            IEnumerable collection = null;
            try
            {
                collection = collectionSelector(target);
            }
            catch (Exception e)
            {
                if (ExceptionHelper.IsNonrecoverableException(e))
                    throw;
            }

            return collection;
        }
        protected IEnumerable<IEnumerable> GetCollections(object target)
        {
            foreach (var collectionSelector in Collections.Values)
            {
                IEnumerable collection = GetCollection(target, collectionSelector);
                if (collection != null)
                    yield return collection;
            }
        }

        protected IEnumerable<IEntityExtensions> GetCollectionElements(IEnumerable collection)
        {
            if (collection != null)
            {
                foreach (var obj in collection)
                {
                    if (obj != null)
                    {
                        var extensions = GetIEntityExtensionsFromObject(obj);
                        if (extensions != null)
                            yield return extensions;
                    }
                }
            }
        }

        public IEnumerable<IEntityExtensions> GetCollectionsElements(object target)
        {
            foreach (var collection in GetCollections(target))
            {
                foreach (var element in GetCollectionElements(collection))
                {
                    yield return element;
                }
            }
        }

        protected internal IEnumerable<IEntityExtensions> GetAllChildObjects(object target)
        {
            foreach (var simpleProperty in GetProperties(target))
                yield return simpleProperty;
            foreach (var element in GetCollectionsElements(target))
                yield return element;
        }
        #endregion
    }
}