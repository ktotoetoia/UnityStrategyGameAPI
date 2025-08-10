namespace TDS
{
    public interface IBuilder<out T>
    {
        T Value { get; }
        
        void FinishInitialization();
        void CancelInitialization();
    }
}