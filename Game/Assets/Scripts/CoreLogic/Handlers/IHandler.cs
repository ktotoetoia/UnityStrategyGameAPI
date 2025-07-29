namespace TDS.Handlers
{
    public interface IHandler<in T>
    {
        bool CanHandle(T operation);
        void Handle(T operation);
    }
}