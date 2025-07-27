using System.Collections.Generic;
using System.Linq;
using TDS.Graphs;
using TDS.Maps;

namespace BuildingsTestGame
{
    public class Path<T> : IPath<T>  where T : ITerrain
    {
        public IReadOnlyList<INode<T>> Nodes { get; }
        
        public INode<T> Start { get; }
        public INode<T> End { get; }
        
        public Path(IEnumerable<INode<T>> nodes) : this(nodes.ToList())
        {
            
        }

        public Path(IReadOnlyList<INode<T>> nodes)
        {
            Nodes = nodes;
            Start = nodes[0];
            End = nodes[^1];
        }
    }
}