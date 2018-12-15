using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BFsharp.AOP;

namespace BFsharp.Tests
{
    [NotifyPropertyChanged]
    public class Entity : EntityBase<Entity>
    {
        public Entity()
        {
            Collection = new ObservableCollection<Entity>();
        }

        public string Name { get; set; }
        public int Number { get; set; }
        public int Number2 { get; set; }
        public int Number3 { get; set; }
        public decimal DecimalNumber { get; set; }
        public int? NullableNumber { get; set; }
        public Entity Child { get; set; }
        public Switch Switch { get; set; }

        public ObservableCollection<Entity> Collection { get; set; }
        public IEnumerable<int> Range { get { return Enumerable.Range(0, 20); } }
        public void SetNumber2(int value)
        {
            Number2 = value;
        }
    }

    public enum Switch
    {
        A,
        B,
        C
    }
}