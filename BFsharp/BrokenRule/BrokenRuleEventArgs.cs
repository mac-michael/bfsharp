using System;

namespace BFsharp
{
    public class BrokenRuleEventArgs : EventArgs
    {
        public BrokenRuleEventArgs() { }

        public BrokenRuleEventArgs(BrokenRule rule)
        {
            BrokenRule = rule;
        }

        public BrokenRule BrokenRule { get; set; }
    }
}