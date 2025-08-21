using TDS.Graphs;

namespace TDS.Pathfinding
{
    public interface IPathSegment<T>
    {
        INode<T> From { get;  }
        INode<T> To { get;  }
        IEdge<T> Edge { get;  }
        float Cost { get;  }
    }
}