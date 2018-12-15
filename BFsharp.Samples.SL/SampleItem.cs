using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace BFsharp.Samples.SL
{
    class SampleItem
    {
        public SampleItem()
        {
            Items = new List<SampleItem>();
        }
        public string Name { get; set; }
        public Func<UserControl> Control { get; set; }
        public List<SampleItem> Items { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}