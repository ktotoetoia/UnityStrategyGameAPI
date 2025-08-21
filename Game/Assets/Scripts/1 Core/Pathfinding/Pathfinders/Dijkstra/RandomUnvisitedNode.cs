using System.Collections.Generic;
using TDS.Graphs;

namespace TDS.Pathfinding
{
    public class RandomUnvisitedNode : INodeSelectionStrategy
    {
        public INode<T> GetNextNode<T>(IEnumerable<INode<T>> available)
        {
            List<INode<T>> nodes = new(available);
            
            if (nodes.Count == 0)
            {
                return null;
            }
            
            int ran = UnityEngine.Random.Range(0, nodes.Count);

            return nodes[ran];
        }
    }
}