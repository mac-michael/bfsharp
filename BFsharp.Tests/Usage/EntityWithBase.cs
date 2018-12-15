using BFsharp.AOP;

namespace BFsharp
{
    [NotifyPropertyChanged]
    public class EntityWithBase : EntityBase<EntityWithBase>
    {
        public EntityComponent Component { get; set; }
        public string Text { get; set; }
        public int Price { get; set; }

        public int Count { get; set; }

        public int Total { get; set; }
    }
}