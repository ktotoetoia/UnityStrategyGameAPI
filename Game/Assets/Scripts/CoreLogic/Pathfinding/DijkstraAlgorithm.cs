using System;
using System.Collections.Generic;
using System.Linq;
using TDS.Graphs;

namespace TDS.Pathfinding
{
    public class DijkstraAlgorithm
    {
        public List<INode> GetPath(List<INode> nodes, INode start, INode end, Func<IEdge,float> distances)
        {
            HashSet<INode> unvisited = new HashSet<INode>(nodes);
            Dictionary<INode, DijkstraData> track = new Dictionary<INode, DijkstraData> { [start] = new DijkstraData { Price = 0 } };

            while (true)
            {
                INode current = unvisited
                    .Where(n => track.ContainsKey(n))
                    .OrderBy(n => track[n].Price)
                    .FirstOrDefault();

                if (current == null) return new List<INode>();
                if (current == end) break;

                foreach (var edge in current.Edges)
                {
                    INode next = OtherNode(edge,current);
                    
                    double price = track[current].Price + distances(edge);

                    if (!track.ContainsKey(next) || price < track[next].Price)
                        track[next] = new DijkstraData { Previous = current, Price = price };
                }

                unvisited.Remove(current);
            }
            
            return TrackToPath(track, end);
        }

        private INode OtherNode(IEdge edge, INode current)
        {
            return edge.From == current ? edge.To : edge.From;
        }

        private List<INode> TrackToPath(Dictionary<INode, DijkstraData> track, INode end)
        {
            List<INode> path = new List<INode>();
            
            for (INode n = end; n != null; n = track[n].Previous)
            {
                path.Insert(0, n);
            }
            
            return path;
        }
    }

    class DijkstraData
    {
        public INode Previous { get; set; }
        public double Price { get; set; }
    }
}