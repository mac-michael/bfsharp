using System;
using System.Collections.ObjectModel;

namespace BFsharp.DynamicProperties
{
    public class DynamicPropertyMetadataCollection : Collection<DynamicPropertyMetadata>
    {
        private DynamicPropertyCollection Parent { get; set; }

        internal DynamicPropertyMetadataCollection(DynamicPropertyCollection parent)
        {
            Parent = parent;
        }

        protected override void SetItem(int index, DynamicPropertyMetadata item)
        {
            throw new NotSupportedException();
        }

        protected override void InsertItem(int index, DynamicPropertyMetadata item)
        {
            base.InsertItem(index, item);
#if !PHONE
            Parent.RefreshProxy();
#endif
        }

        protected override void RemoveItem(int index)
        {
            var name = this[index].Name;
            Parent.Dictionary.Remove(name);

            base.RemoveItem(index);
#if !PHONE
            Parent.RefreshProxy();
#endif
        }

        protected override void ClearItems()
        {
            Parent.Dictionary.Clear();
            base.ClearItems();
#if !PHONE
            Parent.RefreshProxy();
#endif
        }
    }
}