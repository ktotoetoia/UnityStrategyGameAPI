using System.Collections.Generic;
using TDS.Graphs;

namespace TDS.Pathfinding
{
    public interface INodeSelectionStrategy
    {
        INode<T> GetNextNode<T>(IEnumerable<INode<T>> available);
    }
}