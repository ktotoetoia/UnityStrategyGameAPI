using System;
using System.Collections.Generic;
using System.Linq;
using TDS.Graphs;
using UnityEngine;

namespace TDS.Pathfinding
{
    public class Dijkstra : IPathfinder
    {
        private readonly INodeSelectionStrategy _nodeSelectionStrategy;

        public Dijkstra() :this(new RandomUnvisitedNode())
        {
            
        }
        
        public Dijkstra(INodeSelectionStrategy nodeSelectionStrategy)
        {
            _nodeSelectionStrategy = nodeSelectionStrategy;
        }
        
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
                INode<T> current = _nodeSelectionStrategy.GetNextNode(GetLowestPriceNodes(unvisited, track));

                if (current == null) return new EmptyPath<T>();
                if (current.Equals(end)) break;

                foreach (IEdge<T> edge in current.Edges)
                {
                    INode<T> next = edge.GetOther(current);

                    float price = track[current].Price + distances(edge);
                    track[current].CurrentPrice = distances(edge);

                    if (!track.ContainsKey(next) || price < track[next].Price)
                        track[next] = new DijkstraData<T> { Previous = current, Price = price};
                }

                unvisited.Remove(current);
            }
            
            return TrackToPath(track, end);
        }
        
        private IEnumerable<INode<T>> GetLowestPriceNodes<T>(
            HashSet<INode<T>> unvisited,
            Dictionary<INode<T>, DijkstraData<T>> track)
        {
            INode<T> cheapest = null;
            
            foreach (INode<T> node in unvisited.Where(track.ContainsKey).OrderBy(n => track[n].Price))
            {
                if (cheapest == null)
                {
                    cheapest = node;
                }
                
                if (track[node].Price > track[cheapest].Price)
                {
                    yield break;
                }

                yield return node;
            }
        }

        private IPath<T> TrackToPath<T>(Dictionary<INode<T>, DijkstraData<T>> track, INode<T> end)
        {
            List<INode<T>> nodes = GetNodes(track, end);
            List<IPathSegment<T>> segments = GetSegments(track,nodes);
            
            return segments.Count > 0 ? new Path<T>(segments) : new EmptyPath<T>();
        }

        private List<INode<T>> GetNodes<T>(Dictionary<INode<T>, DijkstraData<T>> track, INode<T> end)
        {
            List<INode<T>> nodes = new();
            
            for (INode<T> n = end; n != null; n = track[n].Previous)
            {
                nodes.Insert(0, n);
            }

            return nodes;
        }

        private List<IPathSegment<T>> GetSegments<T>(Dictionary<INode<T>, DijkstraData<T>> track, List<INode<T>> nodes)
        {
            List<IPathSegment<T>> segments = new();
            
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                segments.Add(new PathSegment<T>(nodes[i], nodes[i + 1],track[nodes[i]].CurrentPrice));
            }
            
            return segments;
        }

        class DijkstraData<T>
        {
            public INode<T> Previous { get; set; }
            public float Price { get; set; }
            public float CurrentPrice { get; set; }
        }
    }
}