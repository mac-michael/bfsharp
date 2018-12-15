namespace BFsharp
{
    /// <summary>
    /// Specifies the mode of the validation process.
    /// </summary>
    public enum ValidationMode
    {
        /// <summary>
        /// Validate only rules with Error severity
        /// </summary>
        OnlyErrors,
        /// <summary>
        /// Validate all rules
        /// </summary>
        All
    }
}