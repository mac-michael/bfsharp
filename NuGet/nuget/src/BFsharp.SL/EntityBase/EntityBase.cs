using BFsharp.Authoring;

namespace BFsharp
{
    public partial class EntityBase
    {
        public IEntityExtensions Extensions
        {
            get
            {
                return ((IEntityBase)this).Extensions;
            }
        }
    }

    public partial class EntityBase<T> : IEntityBase<T>
        where T : EntityBase<T>
    {
        IEntityExtensions<T> _entityExtensions;
        public IEntityExtensions<T> Extensions
        {
            get
            {
                if (_entityExtensions == null)
                    _entityExtensions = ((IEntityBase) this).Extensions.GetTypeSafe<T>();
                return _entityExtensions;
            }
        }
    }
}