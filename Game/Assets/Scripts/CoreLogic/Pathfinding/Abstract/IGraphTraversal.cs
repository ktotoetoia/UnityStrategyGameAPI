using System;
using System.Collections.Generic;
using TDS.Graphs;

namespace TDS.Pathfinding
{
    public interface IGraphTraversal
    {
        IGraphReadOnly<T> FindReachableSubgraph<T>(INode<T> startNode,Func<IEnumerable<INode<T>>, bool> canPathTo);
    }
}