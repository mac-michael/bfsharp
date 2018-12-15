using System;
using BFsharp.DynamicProperties;

namespace BFsharp
{
    /// <summary>
    /// Provides methods and properties responsible for Rule, DynamicProperties, IsDirty and Entity Management
    /// </summary>
    public interface IEntityExtensions
    {
        /// <summary>
        /// Gets the collection of rules associated with the entity.
        /// </summary>
        RuleCollection Rules { get; }
        /// <summary>
        /// Gets the collection of broken rules associated with the entity.
        /// </summary>
        BrokenRuleCollection BrokenRules { get; }

        /// <summary>
        /// Gets a value indicating whether this entity is in valid state.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        bool IsValid { get; }
        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns><c>true</c> if this instance is valid; otherwise, <c>false</c>.</returns>
        bool Validate();
        /// <summary>
        /// Validates the specified mode.
        /// </summary>
        /// <param name="mode">The validation mode.</param>
        /// <returns></returns>
        bool Validate(ValidationMode mode);

        /// <summary>
        /// Gets a value indicating whether rules are initialized.
        /// </summary>
        /// <value>
        ///   <c>true</c> if they are; otherwise, <c>false</c>.
        /// </value>
        bool RuleInitialized { get; }
        /// <summary>
        /// Initializes the rules.
        /// </summary>
        void InitializeRules();
        
#if !PHONE
        /// <summary>
        /// Gets or sets the compiler call provider used for textual rule creation.
        /// </summary>
        /// <value>
        /// The compiler call provider.
        /// </value>
        BFsharp.Formula.ICallProvider CompilerCallProvider { get; set; }
#endif
        /// <summary>
        /// Gets the collection of dynamic properties.
        /// </summary>
        DynamicPropertyCollection DynamicProperties { get; }

        /// <summary>
        /// Starts the dirty tracking.
        /// </summary>
        void StartDirtyTracking();

        /// <summary>
        /// Clears the IsDirty property.
        /// </summary>
        void ClearIsDirty();

        /// <summary>
        /// Gets or sets a value indicating whether this instance is dirty.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is dirty; otherwise, <c>false</c>.
        /// </value>
        bool IsDirty { get; set; }

        /// <summary>
        /// Gets a value indicating whether the IsDirty tracking is started.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if the tracking is started; otherwise, <c>false</c>.
        /// </value>
        bool IsDirtyTrackingStarted { get; }

        /// <summary>
        /// Gets the entity associated with the extension.
        /// </summary>
        object Target { get; }


        /// <summary>
        /// Gets or sets the parent EntityExtensions in the EntityMangement hierarchy.
        /// </summary>
        IEntityExtensions Parent { get; set; }

        /// <summary>
        /// Iterates through the cluster objects and executes an action for each.
        /// </summary>
        /// <param name="action">Action to execute.</param>
        void DoClusterAction(Action<IEntityExtensions> action);
        /// <summary>
        /// Iterates through the cluster objects and executes an action for each.
        /// </summary>
        /// <param name="action">Action with level number to execute.</param>
        void DoClusterAction(Action<IEntityExtensions, int> action);

        /// <summary>
        /// Iterates through the cluster objects and executes an action for each.
        /// </summary>
        /// <param name="action">Action to execute.</param>
        /// <param name="mode">Traversal mode.</param>
        void DoClusterAction(Action<IEntityExtensions> action, ClusterTraversalMode mode);

        /// <summary>
        /// Iterates through the cluster objects and executes an action for each.
        /// </summary>
        /// <param name="action">Action with level number to execute.</param>
        /// <param name="mode">Traversal mode.</param>
        void DoClusterAction(Action<IEntityExtensions, int> action, ClusterTraversalMode mode);
        
        //void Savepoint();
        //void Undo();
    }

    /// <summary>
    /// Provides methods and properties responsible for Rule, DynamicProperties, IsDirty and Entity Management. It's a strongly typed version of the IEntityExtensions
    /// </summary>
    /// <typeparam name="T">Associated object Type</typeparam>
    public interface IEntityExtensions<T> : IEntityExtensions
    {
    }
}
