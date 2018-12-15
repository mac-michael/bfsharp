using System;

namespace BFsharp
{
    /// <summary>
    /// Specifies the mode of the cluster traversal.
    /// </summary>
    [Flags]
    public enum ClusterTraversalMode
    {
        /// <summary>
        /// All object in the cluster are processed
        /// </summary>
        All,
        /// <summary>
        /// Only the current object will be processed
        /// </summary>
        SelfOnly,
        /// <summary>
        /// Recursion will only process current instance and marked properties
        /// </summary>
        ChildProperties,
        /// <summary>
        /// Recursion will only process current instance and collections' elements
        /// </summary>
        ChildCollections
    }
}