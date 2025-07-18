using System;
using System.Collections.Generic;
using TDS.Graphs;

namespace TDS.Pathfinding
{
    public interface IPathfinder
    {
        public List<INode<T>> GetPath<T>(List<INode<T>> nodes,INode<T> start,INode<T> end,Func<IEdge<T>, float> distances);
    }
}