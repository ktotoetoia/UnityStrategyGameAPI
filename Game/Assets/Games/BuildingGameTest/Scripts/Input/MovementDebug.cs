using TDS.Entities;
using TDS.Graphs;
using TDS.Maps;
using TDS.SelectionSystem;
using UnityEngine;

namespace BuildingsTestGame
{
    public class MovementDebug : MonoBehaviour
    {
        private MapPathfinder _pathfinder;
        private ISelector _selector;
        private IGraphMap _map;
        
        public IGraphMap Map
        {
            get => _map;
            set
            {
                _map = value;
                _pathfinder = new MapPathfinder(_map)
                {
                    PathResolver = new NoUnitPathResolver()
                };
            }
        }
        
        private void Awake()
        {
            _selector = GetComponent<ISelector>();
        }
        
        private void OnDrawGizmos()
        {
            if (_map == null)
            {
                return;
            }
            
            IEntity entity = _selector.GetSelection<IEntity>().First;
            
            if (entity != null&& entity.TryGetComponent(out IPlacedOnTerrain terrainComponent) && entity.TryGetComponent(out IActionDoer movementComponent))
            {
                var area = _pathfinder.GetAvailableMovement(_map.GetNode(terrainComponent.PlacedOn.Entity as ITerrain) ,movementComponent.AvailableActionPoints).Graph;
                
                Gizmos.color = Color.blue;

                foreach (INode<ITerrain> node in area.Nodes)   
                {
                    Gizmos.DrawSphere(node.Value.Transform.Position, 0.2f);
                }

                foreach (IEdge<ITerrain> edge in area.Edges)
                {

                    Gizmos.DrawLine(edge.From.Value.Transform.Position, edge.To.Value.Transform.Position);
                }
            }
        }
    }
}