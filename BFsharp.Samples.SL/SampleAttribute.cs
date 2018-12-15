using System;

namespace BFsharp.Samples.SL
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SampleAttribute : Attribute
    {
        public string Path { get; set; }
        public string Code { get; set; }

        public SampleAttribute(string path)
        {
            Path = path;
        }

        public SampleAttribute(string path, string code)
        {
            Path = path;
            Code = code;
        }
    }
}