namespace BFsharp
{
    public class BusinessRuleBrokenRule : BrokenRuleWithSource
    {
        internal BusinessRuleBrokenRule()
        {
            
        }
        public object TargetValue { get { return ((BusinessRule) Rule)._targetValue; } }
        public object FuncValue { get { return ((BusinessRule)Rule)._value; } }
    }
}