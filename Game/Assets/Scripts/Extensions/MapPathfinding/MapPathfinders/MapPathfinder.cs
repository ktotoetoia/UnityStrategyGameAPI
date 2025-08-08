using System.Collections.Generic;
using System.Linq;
using TDS.Graphs;
using TDS.Maps;
using TDS.Pathfinding;
using UnityEngine;

namespace TDS.Maps
{
    public class MapPathfinder : IMapPathfinder
    {
        private IDistanceCounter _distanceCounter;
        private IGraphMap _map;
        private IPathfinder _pathfinder;
        private IGraphTraversal _traversal;
        private IPathResolver _pathResolver;

        public IDistanceCounter DistanceCounter
        {
            get =>_distanceCounter??= new Vector2DistanceCounter();
            set => _distanceCounter = value;
        }

        public IPathResolver PathResolver
        {
            get => _pathResolver ??= new PathResolver();
            set => _pathResolver = value;
        }

        public MapPathfinder(IGraphMap map) : this(map, new Dijkstra(),new BreadthFirstTraversal())
        {
            
        }

        public MapPathfinder(IGraphMap map, IPathfinder pathfinder,IGraphTraversal traversal)
        {
            _map = map;
            _pathfinder = pathfinder;
            _traversal = traversal;
        }
        
        public ISubGraph<T> GetAvailableMovement<T>(INode<T> startNode, float maxDistance) where T : ITerrain
        {
            return _traversal.FindReachableSubgraph(startNode, x => DistanceCounter.GetDistance(x) <= maxDistance && PathResolver.CanPathThrough(x));
        }

        public IPath<T> GetPath<T>(IGraphReadOnly<T> graph, INode<T> from, INode<T> to) where T : ITerrain
        {
            return _pathfinder.GetPath(graph.Nodes, from, to, x => DistanceCounter.GetDistance(x));
        }

        public IPath<ITerrain> GetPath(INode<ITerrain> startNode, INode<ITerrain> to,float distance)
        {
            IGraphReadOnly<ITerrain> graph = GetAvailableMovement(startNode, distance).Graph;
            
            return GetPath(graph, graph.Nodes.FirstOrDefault(x => x.Value.Equals(startNode.Value)), graph.Nodes.FirstOrDefault(x => x.Value.Equals(to.Value)));
        }

        public IPath<ITerrain> GetPath(ITerrain startTerrain, ITerrain endTerrain,float distance)
        {
            return GetPath(_map.GetNode(startTerrain), _map.GetNode(endTerrain), distance);
        }
    }
}