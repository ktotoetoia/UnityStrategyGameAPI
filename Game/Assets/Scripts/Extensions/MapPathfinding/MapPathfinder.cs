using System.Collections.Generic;
using TDS.Graphs;
using TDS.Pathfinding;
using TDS.Maps;

namespace BuildingsTestGame
{
    public class MapPathfinder : IMapPathfinder
    {
        private IDistanceCounter _distanceCounter;
        private IMap _map;
        private IPathfinder _pathfinder;
        private IGraphTraversal _traversal;

        public IDistanceCounter DistanceCounter
        {
            get =>_distanceCounter??= new Vector2DistanceCounter();
            set => _distanceCounter = value;
        }
        
        public MapPathfinder(IMap map) : this(map, new Dijkstra(),new BreadthFirstTraversal())
        {
            
        }

        public MapPathfinder(IMap map, IPathfinder pathfinder,IGraphTraversal traversal)
        {
            _map = map;
            _pathfinder = pathfinder;
            _traversal = traversal;
        }
        
        public IGraphReadOnly<T> GetAvailableMovement<T>(INode<T> startNode, float maxDistance) where T : ITerrain
        {
            return _traversal.FindReachableSubgraph(startNode, x => DistanceCounter.GetDistance(x) <= maxDistance);
        }

        public IPath<T> GetPath<T>(IGraphReadOnly<T> graph, INode<T> from, INode<T> to) where T : ITerrain
        {
            IEnumerable<INode<T>> nodes = _pathfinder.GetPath(graph.Nodes, from, to, x => DistanceCounter.GetDistance(x));
            
            return new Path<T>(nodes);
        }
    }
}