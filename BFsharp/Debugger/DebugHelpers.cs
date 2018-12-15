using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BFsharp
{
    public class DebugHelpers
    {
        public DebugHelpers()
        {
            Log = new List<RuleEventEntry>();
        }
        public IEntityExtensions GetGraphParent(IEntityExtensions extensions)
        {
            while (extensions.Parent != null)
                extensions = extensions.Parent;

            return extensions;
        }

        public List<RuleEventEntry> Log { get; set; }
        
        public void LogRuleExecution( Rule rule )
        {
            // RuleEvaluationContext.Current.R

            var entry = new RuleEventEntry();
            entry.Time = DateTime.Now;
            entry.RuleState = ObjectState.Create(rule);
            entry.RuleType = rule.GetType().Name;
        }
    }

    public class RuleEventEntry
    {
        public DateTime Time { get; set; }
        public string RuleType { get;  set; }
        public ObjectState RuleState { get; set; }
    }

    public class ObjectState
    {
        public ObjectState()
        {
            Properties = new List<Property>();
        }
        public List<Property> Properties { get; set; }

        public static ObjectState Create(object obj)
        {
            var properties = new ObjectState();
            var type = obj.GetType();
            foreach (var property in type.GetProperties())
            {
                properties.Properties.Add(new Property
                                              {
                                                  Name = property.Name,
                                                  Value = (property.GetValue(obj, null) ?? "").ToString()
                                              });
            }

            return properties;
        }
    }

    [DebuggerDisplay("{Name}: {Value}")]
    public struct Property
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
