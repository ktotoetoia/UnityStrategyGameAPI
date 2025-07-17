using TDS.Graphs;

namespace TDS.Worlds
{
    public interface IGraphMap : IMap
    {
        IGraphReadOnly<ITerrain> Graph { get; }
        
        INode<ITerrain> GetNode(ITerrain terrain);
    }
}