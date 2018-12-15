namespace BFsharp
{
    public class DataAnnotationsExtensionPointFactory : ExtensionPointFactory
    {
        public override ExtensionPoint<T> GetGextensions<T>()
        {
            return new DataAnnotationsExtensionPoint<T>();
        }
    }
}