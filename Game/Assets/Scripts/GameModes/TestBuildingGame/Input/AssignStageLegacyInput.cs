using System.Collections.Generic;
using System.Linq;
using TDS;
using TDS.Commands;
using TDS.Graphs;
using TDS.Pathfinding;
using TDS.SelectionSystem;
using TDS.Worlds;
using UnityEngine;

namespace BuildingsTestGame
{
    public class AssignStageLegacyInput : IInputHandler
    {
        private IBuildingGameContext _context;
        private List<INode<ITerrain>> _path;
        private RectangleTileMap _map;
        
        public AssignStageLegacyInput(IBuildingGameContext context)
        {
            _context = context;
            _map = _context.World.Map as RectangleTileMap;
        }
        
        public void HandleInput(ICommandHandler handler)
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                handler.DoCommand(new EndTurnCommand(_context.AssignStage));
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                handler.DoCommand(new CreateUnitCommand(AssignStageUnit.Builder,_context.Selector.GetSelectionOfType<BuildingTerrain>().First.Building as IProductionBuilding,_context.World.EntityRegister));
            }

            if (Input.GetMouseButtonDown(1))
            {
                ISelection<ITerrain> selection = _context.Selector.GetSelection<ITerrain>((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
                
                _path = _context.Pathfinder.GetPath(_map.Graph.Nodes.ToList(), 
                    _map.GetNode(_context.Selector.GetSelectionOfType<ITerrain>().First),
                    _map.GetNode(selection.First),
                    x => 1);
            }

            if (_path != null)
            {
                for (int i = 0; i < _path.Count - 1; i++)
                {
                    Debug.DrawLine(_path[i].Value.Area.Position,_path[i+1].Value.Area.Position);
                }
            }
        }
    }
}