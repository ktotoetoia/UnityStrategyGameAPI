using System.Collections.Generic;
using TDS.Graphs;

namespace TDS.Pathfinding
{
    public class EmptyPath<T> : IPath<T>
    {
        public INode<T> Start => null;
        public INode<T> End => null;
        public IReadOnlyList<IPathSegment<T>> Segments { get; } = new List<IPathSegment<T>>();
        
    }
}