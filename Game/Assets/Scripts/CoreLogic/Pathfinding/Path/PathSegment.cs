using System.Linq;
using TDS.Graphs;

namespace TDS.Pathfinding
{
    public class PathSegment<T> : IPathSegment<T>
    {
        public INode<T> From { get;  }
        public INode<T> To { get;  }
        public IEdge<T> Edge { get;  }

        public PathSegment(INode<T> from, INode<T> to)
        {
            From = from;
            To = to;
            Edge = from.Edges.First(x => x.From == to || x.To == to);
        }
    }
}