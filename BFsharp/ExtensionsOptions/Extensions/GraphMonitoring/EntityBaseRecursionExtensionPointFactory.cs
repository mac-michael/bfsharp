namespace BFsharp
{
    public class EntityBaseRecursionExtensionPointFactory : ExtensionPointFactory
    {
        public override ExtensionPoint<T> GetGextensions<T>()
        {
            return new EntityBaseRecursionExtensionPoint<T>();
        }
    }
}