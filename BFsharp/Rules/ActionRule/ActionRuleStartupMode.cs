namespace BFsharp
{
    /// <summary>
    /// Specifies the starupt mode of the action rule.
    /// </summary>
    public enum ActionRuleStartupMode
    {
        /// <summary>
        /// When the rule is started nothing happens
        /// </summary>
        None,
        /// <summary>
        /// When the rule is started it's automatically invoked
        /// </summary>
        Invoke,
    }
}