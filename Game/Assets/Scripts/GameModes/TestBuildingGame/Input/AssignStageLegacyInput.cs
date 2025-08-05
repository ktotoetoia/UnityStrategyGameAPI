using System.Linq;
using BuildingsTestGame;
using TDS.Commands;
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
        private IMapPathfinder _pathfinder;
        private ISelector _selector;
        private ISelectionProvider _terrainSelector;
        private IGraphMap _map;
        private ICommandSequencer _commandSequencer;
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
                _pathfinder = new MapPathfinder(_game.Map);
                _map = _game.Map as IGraphMap;
                _commandSequencer = _game.AssignStage.CommandSequencer;
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
            }
        }

        private void HandleAssignStageInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _commandSequencer.IssueCommand(new EndTurnCommand(_game.AssignStage));
            }
            
            if (Input.GetKeyDown(KeyCode.C) && _selector.GetSelection<IEntity>().First.TryGetComponent(out IBuildingComponent buildingComponent))
            {
                _commandSequencer.IssueCommand(new AddUnitCreationToBuildingQueue(buildingComponent , new DefaultUnitFactory(_game.EntityRegister)));
            }

            if (Input.GetMouseButtonDown(1))
            {
                IGameTerrain selectedTerrain = _selector.GetSelection<IEntity>().First.GetComponent<ITerrainComponent>().Terrain;
                
                if (selectedTerrain == null) return;

                _area = _pathfinder.GetAvailableMovement(_map.GetNode(selectedTerrain) ,_f);

                Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ITerrain targetTerrain = _terrainSelector.SelectAt<ITerrain>((Vector2)clickPosition).First;
                INode<ITerrain> from = _area.Nodes.FirstOrDefault(n => n.Value == selectedTerrain);
                INode<ITerrain> to = _area.Nodes.FirstOrDefault(n => n.Value == targetTerrain);

                IEntity unit = _selector.GetSelection<IEntity>().First;
                if (from != null && to != null && unit != null)
                {
                    _commandSequencer.IssueCommand(
                        new MoveUnitCommand(unit, _pathfinder.GetPath(_area, from, to))
                    );
                }
            }
        }

        protected void OnDrawGizmos()
        {
            if (_area != null)
            {
                Gizmos.color = Color.blue;

                foreach (INode<ITerrain> node in _area.Nodes)   
                {
                    Gizmos.DrawSphere(node.Value.Area.Position, 0.2f);
                }

                foreach (IEdge<ITerrain> edge in _area.Edges)
                {

                    Gizmos.DrawLine(edge.From.Value.Area.Position, edge.To.Value.Area.Position);
                }
            }
        }
    }
}
