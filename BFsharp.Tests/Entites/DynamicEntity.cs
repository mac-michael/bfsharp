using System.Collections.Generic;
using BFsharp.AOP;
using BFsharp.DynamicProperties;
using BFsharp.Formula;

namespace BFsharp.Tests
{
    [NotifyPropertyChanged]
    public class DynamicEntity : EntityBase<DynamicEntity>
    {
        public DynamicEntity()
        {
            Extensions
                .AddProperty<int>("Number")
                .AddProperty<string>("String")
                .AddProperty<SimpleClass>("Simple");
        }
        
        public int Number2 { get; set; }
        public string String2 { get; set; }
    }

    public class SimpleClass
    {
        public int Number { get; set; }
    }
}