using System;
using System.Collections.Generic;

namespace BFsharp.Formula
{
    public class LambdaTypeDefinition
    {
        public Type LambdaType { get; set; }
        public Type ThisType { get; set; }
        public Type ReturnedType { get; set; }

        private List<Param> _params;
        public List<Param> Params
        {
            get
            {
                if (_params == null)
                    _params = new List<Param>();
                return _params;
            }
        }
    }
}