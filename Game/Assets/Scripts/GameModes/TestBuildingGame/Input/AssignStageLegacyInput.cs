using System.Linq;
using TDS.Commands;
using TDS.Graphs;
using TDS.Worlds;
using UnityEngine;

namespace BuildingsTestGame
{
    public class AssignStageLegacyInput : IInputHandler
    {
        private IBuildingGameContext _context;
        private IGraphReadOnly<ITerrain> _path;
        private IGraphMap _map;
        
        public AssignStageLegacyInput(IBuildingGameContext context)
        {
            _context = context;
            _map = _context.World.Map as IGraphMap;
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
                _path = _context.Pathfinder.GetAvailableMovement(_map.GetNode(_context.Selector.GetSelectionOfType<ITerrain>().First), 3);

                INode<ITerrain> from = _path.Nodes.FirstOrDefault(x => x.Value == _context.Selector.GetSelectionOfType<ITerrain>().First);
                INode<ITerrain> to = _path.Nodes.FirstOrDefault(x => x.Value == _context.Selector.GetSelection<ITerrain>((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition)).First);
                
                handler.DoCommand(new MoveUnitCommand(_context.Selector.GetSelectionOfType<BuildingTerrain>().First.Unit,
                    _context.Pathfinder.GetPath(_path,from, to)));
            }

            if (_path != null)
            {
                for (int i = 0; i < _path.Nodes.Count - 1; i++)
                {
                    Debug.DrawLine(_path.Nodes[i].Value.Area.Position,_path.Nodes[i+1].Value.Area.Position);
                }
            }
        }
    }
}