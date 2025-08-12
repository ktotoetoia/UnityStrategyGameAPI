using TDS.Graphs;

namespace TDS.Pathfinding
{
    internal class DijkstraData<T>
    {
        public INode<T> Previous { get; set; }
        public float Price { get; set; }
        public float CurrentPrice { get; set; }
    }
}