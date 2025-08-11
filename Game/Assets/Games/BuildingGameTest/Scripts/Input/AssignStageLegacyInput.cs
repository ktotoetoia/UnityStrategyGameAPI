using BuildingsTestGame;
using TDS.Entities;
using TDS.Graphs;
using TDS.Maps;
using TDS.SelectionSystem;
using UnityEngine;

namespace TDS
{
    public class AssignStageLegacyInput : MonoBehaviour
    {
        [SerializeField] private float _f;
        private MapPathfinder _pathfinder;
        private ISelector _selector;
        private ISelectionProvider _terrainSelector;
        private IGraphMap _map;
        private IGraphReadOnly<ITerrain> _area;
        private BuildingGame _game;

        public BuildingGame BuildingGame
        {
            get => _game;
            set
            {
                if (value == null) return;

                _game = value;
                _selector = new Selector(new RaycastSelectionProvider());
                _terrainSelector = new TerrainSelectionProvider(_game.Map);
                _map = _game.Map as IGraphMap;
                _pathfinder = new MapPathfinder(_map);
                _pathfinder.PathResolver = new NoUnitPathResolver();
            }
        }

        private void Update()
        {
            if (_game == null) return;

            HandleGeneralInput();

            if (_game.CurrentStage == _game.AssignStage)
            {
                HandleAssignStageInput();
            }
        }

        private void HandleGeneralInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _selector.UpdateSelectionAt(clickPosition);
                
                if (_selector.GetSelection<IEntity>().First != null&& _selector.GetSelection<IEntity>().First.TryGetComponent(out IPlacedOnTerrain terrainComponent) && _selector.GetSelection<IEntity>().First.TryGetComponent(out IMapMovementComponent movementComponent))
                {
                    _area = _pathfinder.GetAvailableMovement(_map.GetNode(terrainComponent.PlacedOn.Entity as ITerrain) ,movementComponent.AvailableMovementPoints).Graph;
                }
            }
        }

        private void HandleAssignStageInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _game.AssignStage.EndTurn();
            }
            
            if (Input.GetKeyDown(KeyCode.C) && _selector.GetSelection<IEntity>().First.TryGetComponent(out IBuildingComponent buildingComponent))
            {
                buildingComponent.AddToQueue(new DefaultUnitFactory(_game.EntityRegister));
            }

            if (Input.GetMouseButtonDown(1))
            {
                Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ITerrain targetTerrain = _terrainSelector.SelectAt<ITerrain>((Vector2)clickPosition).First;
                IEntity unit = _selector.GetSelection<IEntity>().First;
                
                new MoveUnitCommandHandler().Handle(
                    new MoveUnitCommand(unit, targetTerrain.TerrainArea,_pathfinder)
                );
            }
        }

        protected void OnDrawGizmos()
        {
            if (_area != null)
            {
                Gizmos.color = Color.blue;

                foreach (INode<ITerrain> node in _area.Nodes)   
                {
                    Gizmos.DrawSphere(node.Value.Transform.Position, 0.2f);
                }

                foreach (IEdge<ITerrain> edge in _area.Edges)
                {

                    Gizmos.DrawLine(edge.From.Value.Transform.Position, edge.To.Value.Transform.Position);
                }
            }
        }
    }
}
