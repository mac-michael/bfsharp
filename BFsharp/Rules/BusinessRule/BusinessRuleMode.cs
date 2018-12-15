namespace BFsharp
{
    /// <summary>
    /// Specifies the mode of the business rule.
    /// </summary>
    public enum BusinessRuleMode
    {
        /// <summary>
        /// Rule is evaluated in response to a dependent property change.
        /// </summary>
        Evaluate,
        /// <summary>
        /// Rule is validated in response to a dependent property chagne.
        /// </summary>
        Validate,
    }
}