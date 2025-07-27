using System.Collections.Generic;
using TDS.Graphs;
using TDS.Maps;

namespace BuildingsTestGame
{
    public interface IPath<T> where T : ITerrain
    {
        public IReadOnlyList<INode<T>> Nodes { get; }
        public INode<T> Start { get; }
        public INode<T> End { get; }
    }
}