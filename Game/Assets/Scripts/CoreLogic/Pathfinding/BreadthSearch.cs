using System;
using System.Collections.Generic;
using System.Linq;
using TDS.Graphs;

namespace TDS.Pathfinding
{
    public class BreadthSearch
    {
        public IGraphReadOnly<T> GetArea<T>(INode<T> startNode,Func<IEnumerable<INode<T>>, bool> canPathTo)
        {
            var newNodes = new Dictionary<INode<T>, Node<T>>();
            var newEdges = new HashSet<IEdge<T>>();

            var queue = new Queue<List<INode<T>>>();
            queue.Enqueue(new List<INode<T>> { startNode });

            newNodes[startNode] = CreateNewNode(startNode);

            while (queue.Count > 0)
            {
                var path = queue.Dequeue();
                var currentNode = path[^1];
                var currentNewNode = newNodes[currentNode];

                foreach (var edge in currentNode.Edges)
                {
                    var neighbor = GetNeighbor(edge, currentNode);

                    if (!newNodes.ContainsKey(neighbor))
                    {
                        var newPath = new List<INode<T>>(path) { neighbor };

                        if (canPathTo(newPath))
                        {
                            var neighborNewNode = CreateNewNode(neighbor);
                            newNodes[neighbor] = neighborNewNode;

                            CreateNewEdge(currentNewNode, neighborNewNode, newEdges);

                            queue.Enqueue(newPath);
                        }
                    }
                    else
                    {
                        var neighborNewNode = newNodes[neighbor];
                        CreateNewEdge(currentNewNode, neighborNewNode, newEdges);
                    }
                }
            }

            return new GraphReadOnly<T>(newNodes.Values.ToList(), newEdges.ToList());
        }

        private Node<T> CreateNewNode<T>(INode<T> originalNode)
        {
            return new Node<T>(originalNode.Value);
        }

        private void CreateNewEdge<T>(Node<T> from, Node<T> to, HashSet<IEdge<T>> edgeSet)
        {
            var newEdge = new Edge<T>(from, to);

            if (edgeSet.Add(newEdge))
            {
                from.Add(newEdge);
                to.Add(newEdge);
            }
        }

        private INode<T> GetNeighbor<T>(IEdge<T> edge, INode<T> current)
        {
            return edge.From.Equals(current) ? edge.To : edge.From;
        }
    }
}