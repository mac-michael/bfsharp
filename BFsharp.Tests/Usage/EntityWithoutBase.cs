using System.ComponentModel;
using BFsharp.AOP;

namespace BFsharp
{
    [NotifyPropertyChanged]
    public class EntityWithoutBase
    {
        public EntityWithoutBase()
        {
            Rules = EntityExtensions.RegisterTypedObject(this);
        }
        public IEntityExtensions<EntityWithoutBase> Rules { get; private set; }

        public EntityComponent Component { get; set; }
        public string Text { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
    }
}