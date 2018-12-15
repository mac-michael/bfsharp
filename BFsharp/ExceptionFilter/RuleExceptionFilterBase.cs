using System;
using System.Threading;

namespace BFsharp
{
    public abstract class RuleExceptionFilterBase 
    {
        public abstract BrokenRule[] Process(Exception e);

        public string Message { get; set; }
        public Func<Exception, string> LocalizableMessageFunc { get; set; }
        public BrokenRuleSeverity Severity { get; set; }
        public string Owner { get; set; }
    }

    public class NonRecoverableRuleExceptionFilter : RuleExceptionFilterBase
    {
        // NonRecoverable exceptions are caught in Rule.InvokeWithExceptionFilter method
        public override BrokenRule[] Process(Exception e)
        {
            var message = LocalizableMessageFunc != null ? LocalizableMessageFunc( e) : Message;

            return new[]
                       {
                           new BrokenRule
                               {
                                   Message = message,
                                   Severity = Severity,
                                   Owner = Owner
                               }
                       };
        }
    }
}