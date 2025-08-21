using TDS.Graphs;

namespace TDS.Maps
{
    public interface IGraphMap : IMap
    {
        IGraphReadOnly<ITerrain> Graph { get; }
        
        INode<ITerrain> GetNode(ITerrain terrain);
    }
}