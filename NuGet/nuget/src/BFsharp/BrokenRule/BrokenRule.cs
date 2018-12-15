using System;
using System.Runtime.Serialization;

namespace BFsharp
{
    // TODO: Rename Info?
    public class BrokenRule
    {
        public BrokenRule() { }
        
        public BrokenRule(string message, BrokenRuleSeverity severity, string owner)
        {
            Message = message;
            Severity = severity;
            Owner = owner;
        }

        public string Message { get; set; }
        public BrokenRuleSeverity Severity { get; set; }
        public string Owner { get; set; }
        public BrokenRuleRevocationStrategy Mode { get; set; }
        internal Rule RevocationRule { get; set; }
        
        public BrokenRule WithMode(BrokenRuleRevocationStrategy mode)
        {
            Mode = mode;
            return this;
        }

        public override string ToString()
        {
            return Message;
        }
    }

    public enum BrokenRuleRevocationStrategy
    {
        None,
        //PropertyChanged, // todo
        Validate
    }
}