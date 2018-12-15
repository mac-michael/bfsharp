namespace BFsharp
{
    /// <summary>
    /// Specifies the starupt mode of the business rule.
    /// </summary>
    public enum BusinessRuleStartupMode
    {
        /// <summary>
        /// When the rule is started nothing happens
        /// </summary>
        None,
        /// <summary>
        /// When the rule is started it's automatically evaluated
        /// </summary>
        Evaluate,

        /// <summary>
        /// When the rule is started it's automatically validated
        /// </summary>
        Validate
    }
}