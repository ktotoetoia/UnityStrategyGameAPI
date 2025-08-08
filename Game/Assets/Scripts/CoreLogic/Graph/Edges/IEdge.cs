namespace TDS.Graphs
{
    public interface IEdge<T>
    {
        INode<T> From { get; }
        INode<T> To { get; }
    }
}