namespace BFsharp
{
    public interface IExtensionOptions
    {
        void InitializeRules(IEntityExtensions entityExtensions);
        void InitializeProperties(IEntityExtensions entityExtensions);
        void DecorateRules(Rule rule);

        GraphMonitoringStrategy GraphMonitoringStrategy { get; }
    }
}