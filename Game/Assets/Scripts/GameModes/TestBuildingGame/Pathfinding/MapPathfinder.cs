using TDS.Graphs;
using TDS.Pathfinding;
using TDS.Worlds;

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
            get =>_distanceCounter??= new PositionBasedDistanceCounter();
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
    }
}