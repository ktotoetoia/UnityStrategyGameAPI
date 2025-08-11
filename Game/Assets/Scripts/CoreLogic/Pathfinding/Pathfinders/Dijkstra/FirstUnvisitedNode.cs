using System.Collections.Generic;
using System.Linq;
using TDS.Graphs;

namespace TDS.Pathfinding
{
    public class FirstUnvisitedNode : INodeSelectionStrategy
    {
        public INode<T> GetNextNode<T>(IEnumerable<INode<T>> available)
        {
            return available.FirstOrDefault();
        }
    }
}