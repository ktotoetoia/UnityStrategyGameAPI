using System.Linq;
using TDS.Entities;
using TDS.Graphs;
using TDS.Maps;
using TDS.SelectionSystem;
using TDS.TurnSystem;
using UnityEngine;

namespace BuildingsTestGame
{
    public class AssignStageAcc : MonoBehaviour
    {
        private MapPathfinder _pathfinder;
        private BuildingGame _game;
        private ISelectionProvider _terrainSelector;
        private ISelector _selector;
        
        public BuildingGame BuildingGame
        {
            get => _game;
            set
            {
                if (value == null) return;

                _game = value;
                _terrainSelector = new TerrainSelectionProvider(_game.Map);
                _pathfinder = new MapPathfinder(_game.Map)
                {
                    PathResolver = new NoUnitPathResolver()
                };
                
                new UpdateEntitiesOnTurnStart(_game.AssignStage,_game.EntityRegistry).Subscribe();
            }
        }
        
        private void Awake()
        {
            _selector = GetComponent<ISelector>();
        }

        public void EndTurn()
        {
            _game.AssignStage.EndTurn();
        }

        private void OnDrawGizmos()
        {
            if (_game == null)
            {
                return;
            }
            
            IEntity entity = _selector.GetSelection<IEntity>().First;
            
            if (entity != null&& entity.TryGetComponent(out IPlacedOnTerrain terrainComponent) && entity.TryGetComponent(out IActionDoer movementComponent))
            {
                var area = _pathfinder.GetAvailableMovement(_game.Map.GetNode(terrainComponent.PlacedOn.Entity as ITerrain) ,movementComponent.AvailableActionPoints).Graph;
                
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