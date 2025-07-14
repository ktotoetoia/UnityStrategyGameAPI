namespace TDS.Graphs
{
    public interface IEdge
    {
        INodeReadOnly From { get; }
        INodeReadOnly To { get; }

        INodeReadOnly GetOther(INodeReadOnly node);
    }
}