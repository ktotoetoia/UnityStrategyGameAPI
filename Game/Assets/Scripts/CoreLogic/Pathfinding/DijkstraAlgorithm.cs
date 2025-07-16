using System;
using System.Collections.Generic;
using System.Linq;
using TDS.Graphs;

namespace TDS.Pathfinding
{
    public class DijkstraAlgorithm
    {
        public List<INodeReadOnly> GetPath(List<INodeReadOnly> nodes, INodeReadOnly start, INodeReadOnly end, Dictionary<IEdge, double> distances)
        {
            HashSet<INodeReadOnly> unvisited = new HashSet<INodeReadOnly>(nodes);
            Dictionary<INodeReadOnly, DijkstraData> track = new Dictionary<INodeReadOnly, DijkstraData> { [start] = new DijkstraData { Price = 0 } };

            while (true)
            {
                INodeReadOnly current = unvisited
                    .Where(n => track.ContainsKey(n))
                    .OrderBy(n => track[n].Price)
                    .FirstOrDefault();

                if (current == null) return new List<INodeReadOnly>();
                if (current == end) break;

                foreach (var edge in current.Edges)
                {
                    INodeReadOnly next = OtherNode(edge,current);
                    if (!distances.TryGetValue(edge, out var distance))
                        continue;

                    double price = track[current].Price + distance;

                    if (!track.ContainsKey(next) || price < track[next].Price)
                        track[next] = new DijkstraData { Previous = current, Price = price };
                }

                unvisited.Remove(current);
            }
            
            return TrackToPath(track, end);
        }

        private INodeReadOnly OtherNode(IEdge edge, INodeReadOnly current)
        {
            return edge.From == current ? edge.To : edge.From;
        }

        private List<INodeReadOnly> TrackToPath(Dictionary<INodeReadOnly, DijkstraData> track, INodeReadOnly end)
        {
            List<INodeReadOnly> path = new List<INodeReadOnly>();
            
            for (INodeReadOnly n = end; n != null; n = track[n].Previous)
            {
                path.Insert(0, n);
            }
            
            return path;
        }
    }

    class DijkstraData
    {
        public INodeReadOnly Previous { get; set; }
        public double Price { get; set; }
    }
}