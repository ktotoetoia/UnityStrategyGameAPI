namespace TDS.Handlers
{
    public interface IConditionalHandler<in T> : IHandler<T>
    {
        bool CanHandle(T operation);
    }
}