using System;
using System.Linq;
using BuildingsTestGame;
using TDS.Commands;
using TDS.Entities;
using TDS.Graphs;
using TDS.SelectionSystem;
using TDS.Maps;
using UnityEngine;

namespace TDS
{
    public class AssignStageLegacyInput : MonoBehaviour
    {
        private IMapPathfinder _pathfinder;
        private ISelector _selector;
        private IGraphMap _map;
        private ICommandSequencer _commandSequencer;

        private BuildingGame _game;

        public BuildingGame BuildingGame
        {
            get => _game;
            set
            {
                _game = value;

                if (_game == null) return;

                _selector = new TerrainSelector(_game.Map);
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
                _selector.UpdateSelection(clickPosition);
            }
        }

        private void HandleAssignStageInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _commandSequencer.IssueCommand(new EndTurnCommand(_game.AssignStage));
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                if (_selector.SelectionOfType<BuildingTerrain>().First.Building is IProductionBuilding selectedBuilding)
                {
                    _commandSequencer.IssueCommand(
                        new CreateUnitCommand(AssignStageUnit.Builder, selectedBuilding, _game.EntityRegister)
                    );
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                ITerrain selectedTerrain = _selector.SelectionOfType<ITerrain>().First;
                if (selectedTerrain == null) return;

                IGraphReadOnly<ITerrain> path = _pathfinder.GetAvailableMovement(_map.GetNode(selectedTerrain), 3);

                INode<ITerrain> from = path.Nodes.FirstOrDefault(n => n.Value == selectedTerrain);
                Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ITerrain targetTerrain = _selector.GetSelection<ITerrain>((Vector2)clickPosition).First;
                INode<ITerrain> to = path.Nodes.FirstOrDefault(n => n.Value == targetTerrain);

                IEntity unit = _selector.SelectionOfType<BuildingTerrain>().First.Unit;
                if (from != null && to != null && unit != null)
                {
                    _commandSequencer.IssueCommand(
                        new MoveUnitCommand(unit, _pathfinder.GetPath(path, from, to))
                    );
                }
            }
        }
    }
}
