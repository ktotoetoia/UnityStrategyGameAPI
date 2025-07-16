namespace TDS.Graphs
{
    public interface IEdge
    {
        INode From { get; }
        INode To { get; }

        INode GetOther(INode node);
    }
}