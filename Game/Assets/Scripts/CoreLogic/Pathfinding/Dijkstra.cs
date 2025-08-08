using System;
using System.Collections.Generic;
using System.Linq;
using TDS.Graphs;
using UnityEngine;

namespace TDS.Pathfinding
{
    public class Dijkstra : IPathfinder
    {
        public IPath<T> GetPath<T>(
            IEnumerable<INode<T>> nodes,
            INode<T> start,
            INode<T> end,
            Func<IEdge<T>, float> distances)
        {
            HashSet<INode<T>> unvisited = new HashSet<INode<T>>(nodes);
            Dictionary<INode<T>, DijkstraData<T>> track = new()
            {
                [start] = new DijkstraData<T> { Price = 0 }
            };

            while (true)
            {
                INode<T> current = unvisited
                    .Where(n => track.ContainsKey(n))
                    .OrderBy(n => track[n].Price)
                    .FirstOrDefault();

                if (current == null) return new EmptyPath<T>();
                if (current.Equals(end)) break;

                foreach (var edge in current.Edges)
                {
                    INode<T> next = OtherNode(edge, current);

                    double price = track[current].Price + distances(edge);

                    if (!track.ContainsKey(next) || price < track[next].Price)
                        track[next] = new DijkstraData<T> { Previous = current, Price = price };
                }

                unvisited.Remove(current);
            }
            
            return TrackToPath(track, end);
        }

        private INode<T> OtherNode<T>(IEdge<T> edge, INode<T> current)
        {
            return Equals(edge.From, current) ? edge.To : edge.From;
        }

        private IPath<T> TrackToPath<T>(Dictionary<INode<T>, DijkstraData<T>> track, INode<T> end)
        {
            List<INode<T>> nodes = new();
            
            for (var n = end; n != null; n = track[n].Previous)
            {
                nodes.Insert(0, n);
            }

            List<IPathSegment<T>> segments = new();
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                segments.Add(new PathSegment<T>(nodes[i], nodes[i + 1]));
            }
            
            return segments.Count > 0 ? new Path<T>(segments) : new EmptyPath<T>();
        }

        class DijkstraData<T>
        {
            public INode<T> Previous { get; set; }
            public double Price { get; set; }
        }
    }
}