using System;

namespace BFsharp.Formula
{
    public class Param
    {
        public Param(Type paramType, string name)
        {
            ParamType = paramType;
            Name = name;
        }

        public Type ParamType { get; set; }
        public string Name { get; set; }
    }
}