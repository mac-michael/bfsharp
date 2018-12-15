namespace BFsharp
{
    /// <summary>
    /// Specifies the starupt mode of the validation rule.
    /// </summary>
    public enum ValidationRuleStartupMode
    {
        /// <summary>
        /// When the rule is started nothing happens
        /// </summary>
        None,

        /// <summary>
        /// When the rule is started it's automatically validated
        /// </summary>
        Validate
    }
}