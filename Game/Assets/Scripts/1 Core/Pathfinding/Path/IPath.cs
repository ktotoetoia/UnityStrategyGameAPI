using System.Collections.Generic;
using TDS.Graphs;

namespace TDS.Pathfinding
{
    public interface IPath<T>
    {
        public INode<T> Start { get; }
        public INode<T> End { get; }
        
        IReadOnlyList<IPathSegment<T>> Segments { get; }
    }
}