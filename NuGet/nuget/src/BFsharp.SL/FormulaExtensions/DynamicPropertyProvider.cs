using System;
using System.Collections.Generic;
using System.Linq;
using BFsharp.DynamicProperties;
using BFsharp.Formula;

namespace BFsharp.FormulaExtensions
{
    public class DynamicPropertyProvider : ICallProvider
    {
        public Type ThisType { get; set; }
        public bool AllowDynamicProperties { get; set; }

        public DynamicPropertyProvider(Type thisType, bool allowDynamicProperties,
            IEnumerable<DynamicPropertyMetadata> properties)
        {
            ThisType = thisType;
            AllowDynamicProperties = allowDynamicProperties;
            Properties = properties.Select(dpm =>
                                           new DynamicProperty { Name = dpm.Name, ReturnedType = dpm.Type }).ToList();
        }

        public List<DynamicProperty> Properties { get; private set; }

        public Member FindMethod(Type thisType, string methodName, Type[] methodArguments)
        {
            if (thisType == ThisType)
            {
                var property = Properties.Where(p => p.Name == methodName).FirstOrDefault();
                if (property == null && AllowDynamicProperties)
                    return new DynamicProperty {Name = methodName, ReturnedType = typeof (object)};
                return property;
            }
            return null;
        }
    }
}