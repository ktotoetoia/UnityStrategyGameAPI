namespace TDS
{
    public interface IDestroyable
    {
        bool IsDestroyed { get; }
        void Destroy();
    }
}