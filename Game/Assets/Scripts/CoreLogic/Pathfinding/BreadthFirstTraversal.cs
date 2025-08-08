using System;
using System.Collections.Generic;
using System.Linq;
using TDS.Graphs;

namespace TDS.Pathfinding
{
    public class BreadthFirstTraversal : IGraphTraversal
    {
        public ISubGraph<T> FindReachableSubgraph<T>(
            INode<T> startNode,
            Func<IEnumerable<INode<T>>, bool> canPathTo)
        {
            Dictionary<INode<T>, Node<T>> newNodes = new Dictionary<INode<T>, Node<T>>();
            HashSet<IEdge<T>> newEdges = new HashSet<IEdge<T>>();

            Queue<List<INode<T>>> queue = new Queue<List<INode<T>>>();
            queue.Enqueue(new List<INode<T>> { startNode });

            newNodes[startNode] = CreateNewNode(startNode);

            while (queue.Count > 0)
            {
                List<INode<T>> path = queue.Dequeue();
                INode<T> currentNode = path[^1];
                Node<T> currentNewNode = newNodes[currentNode];

                foreach (IEdge<T> edge in currentNode.Edges)
                {
                    INode<T> neighbor = GetNeighbor(edge, currentNode);

                    if (!newNodes.ContainsKey(neighbor))
                    {
                        List<INode<T>> newPath = new List<INode<T>>(path) { neighbor };

                        if (canPathTo(newPath))
                        {
                            Node<T> neighborNewNode = CreateNewNode(neighbor);
                            newNodes[neighbor] = neighborNewNode;

                            CreateNewEdgeIfNotConnected(currentNewNode, neighborNewNode, newEdges);

                            queue.Enqueue(newPath);
                        }
                    }
                    else
                    {
                        Node<T> neighborNewNode = newNodes[neighbor];
                        CreateNewEdgeIfNotConnected(currentNewNode, neighborNewNode, newEdges);
                    }
                }
            }

            return new SubGraph<T>(new GraphReadOnly<T>(newNodes.Values.ToList(), newEdges.ToList()));
        }

        private Node<T> CreateNewNode<T>(INode<T> originalNode)
        {
            return new Node<T>(originalNode.Value);
        }

        private void CreateNewEdgeIfNotConnected<T>(Node<T> from, Node<T> to, HashSet<IEdge<T>> edgeSet)
        {
            if (!HasEdgeBetween(from, to))
            {
                Edge<T> newEdge = new Edge<T>(from, to);

                if (edgeSet.Add(newEdge))
                {
                    from.Add(newEdge);
                    to.Add(newEdge);
                }
            }
        }

        private bool HasEdgeBetween<T>(Node<T> a, Node<T> b)
        {
            foreach (IEdge<T> edge in a.Edges)
            {
                INode<T> neighbor = edge.From.Equals(a) ? edge.To : edge.From;
                if (neighbor.Equals(b))
                    return true;
            }
            return false;
        }

        private INode<T> GetNeighbor<T>(IEdge<T> edge, INode<T> current)
        {
            return edge.From.Equals(current) ? edge.To : edge.From;
        }
    }
}