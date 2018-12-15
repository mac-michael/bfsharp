namespace BFsharp
{
    public abstract class ExtensionPointFactory
    {
        public abstract ExtensionPoint<T> GetGextensions<T>();
    }
}