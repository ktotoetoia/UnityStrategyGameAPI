using System.Collections;
using System.Collections.Generic;

namespace TDS.Graphs
{

    public class Node : Node<object>, INode
    {
        
    }
    
    public class Node<T> : INode<T>, ICollection<IEdge>
    {
        private readonly List<IEdge> _edges = new();

        public T Value { get; set; }
        public IEnumerable<IEdge> Edges => _edges;
        public int Count => _edges.Count;
        public bool IsReadOnly => false;
        
        public Node() : this(default)
        {
        }

        public Node(T value)
        {
            Value = value;
        }

        public void Add(IEdge edge)
        {
            _edges.Add(edge);
        }

        public bool Remove(IEdge edge)
        {
            return _edges.Remove(edge);
        }

        public void Clear()
        {
            _edges.Clear();
        }

        public bool Contains(IEdge item)
        {
            return _edges.Contains(item);
        }

        public void CopyTo(IEdge[] array, int arrayIndex)
        {
            _edges.CopyTo(array, arrayIndex);
        }

        public IEnumerator<IEdge> GetEnumerator()
        {
            return _edges.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _edges.GetEnumerator();
        }
    }
}