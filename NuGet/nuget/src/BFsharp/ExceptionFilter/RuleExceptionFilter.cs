using System;

namespace BFsharp
{
    public class RuleExceptionFilter : RuleExceptionFilterBase
    {
        public Type ExceptionType { get; set; }

        public override BrokenRule[] Process(Exception e)
        {
            if ( ExceptionType.IsAssignableFrom(e.GetType()) )
            {
                return new[]
                           {
                               new BrokenRule
                                   {
                                       Message = Message,
                                       Severity = Severity,
                                       Owner = Owner
                                   }
                           };
            }

            return null;
        }
    }
}