namespace TDS.SelectionSystem
{
    public interface IHaveSelection
    {
        ISelection<object> Selection { get; }
    }
}