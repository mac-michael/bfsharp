using System;

namespace BFsharp.Samples.SL
{
    public class SampleEntity
    {
        public SampleEntity()
        {
            String = "sample";
            Name = "Joel";
            SureName = "Smith";

            Int = 6;
            Time = new DateTime(2006, 5, 3, 11, 22, 7, 0);
        }

        public string Name { get; set; }
        public string SureName { get; set; }

        public string String { get; set; }
        public int Int { get; set; }
        public DateTime Time { get; set; }
    }
}