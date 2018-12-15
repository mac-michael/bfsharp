using BFsharp.DynamicProperties;

namespace BFsharp
{
    public interface IEntityExtensions
    {
        RuleCollection Rules { get; }
        BrokenRuleCollection BrokenRules { get; }

        bool IsValid { get; }
        bool Validate();
        bool Validate(ValidationMode mode);

        bool RuleInitialized { get; }
        void InitializeRules();
        
#if !PHONE
        BFsharp.Formula.ICallProvider CompilerCallProvider { get; set; }
#endif
        DynamicPropertyCollection DynamicProperties { get; }

        void StartDirtyTracking();
        void ClearIsDirty();
        bool IsDirty { get; set; }
        bool IsDirtyTrackingStarted { get; }

        object Target { get; }
        IEntityExtensions Parent { get; set; }
    }

    public interface IEntityExtensions<T> : IEntityExtensions
    {
    }
}
