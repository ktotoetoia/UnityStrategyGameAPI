using System.Collections.Generic;
using System.Linq;
using TDS.Graphs;

namespace TDS.Pathfinding
{
    public class Path<T> : IPath<T>
    {
        public INode<T> Start { get; }
        public INode<T> End { get; }
        
        public IReadOnlyList<IPathSegment<T>> Segments { get; }
        
        public Path(IEnumerable<IPathSegment<T>> nodes) : this(nodes.ToList())
        {
            
        }

        public Path(IReadOnlyList<IPathSegment<T>> nodes)
        {
            Segments = nodes;
            Start = nodes[0].From;
            End = nodes[^1].To;
        }
    }
}