namespace TDS.Graphs
{
    public interface IGraph : IGraphReadOnly
    {
        IEdge Connect(INodeReadOnly first, INodeReadOnly second);
        INodeReadOnly CreateNode();
        void Disconnect(IEdge edge);
        void RemoveNode(INodeReadOnly node);
    }
}