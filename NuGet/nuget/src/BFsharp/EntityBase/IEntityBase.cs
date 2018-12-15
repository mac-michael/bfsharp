namespace BFsharp
{
    public interface IEntityBase<T>
    {
        IEntityExtensions<T> Extensions { get; }
    }

    public interface IEntityBase
    {
        IEntityExtensions Extensions { get; }
    }
}