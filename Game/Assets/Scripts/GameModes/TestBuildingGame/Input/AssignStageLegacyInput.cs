using System.Collections.Generic;
using System.Linq;
using TDS;
using TDS.Commands;
using TDS.Graphs;
using TDS.Pathfinding;
using TDS.Worlds;
using UnityEngine;

namespace BuildingsTestGame
{
    public class AssignStageLegacyInput : IInputHandler
    {
        private IBuildingGameContext _context;
        private List<INode> _path;
        private BuildingTerrainSelector _ss;
        private DijkstraAlgorithm _a;
        
        public AssignStageLegacyInput(IBuildingGameContext context)
        {
            _context = context;
            _ss = new BuildingTerrainSelector(_context.World.Map);
            _a = new DijkstraAlgorithm();
        }
        
        public void HandleInput(ICommandHandler handler)
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                handler.DoCommand(new EndTurnCommand(_context.CurrentStage));
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                handler.DoCommand(new CreateUnitCommand(AssignStageUnit.Builder,(_context.Selector.Selection.First.Object as BuildingTerrain) .Building as IProductionBuilding,_context.World.EntityRegister));
            }

            if (Input.GetMouseButtonDown(1))
            {
                _ss.UpdateSelection((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
                Debug.Log( (_context.World.Map as RectangleTileMap).Graph.Nodes.ToList());
                Debug.Log( GetNode(_context.Selector.Selection.First.Object as BuildingTerrain));
                Debug.Log( _ss.Selection.First.Object as BuildingTerrain);
                _path = _a
                    .GetPath(
                    (_context.World.Map as RectangleTileMap).Graph.Nodes.ToList(),
                    GetNode(_context.Selector.Selection.First.Object as BuildingTerrain),
                    GetNode(_ss.Selection.First.Object as BuildingTerrain),
                    x => 1);
            }

            if (_path != null)
            {
                for (int i = 0; i < _path.Count - 1; i++)
                {
                    Debug.DrawLine((_path[i].Value as ITerrain).Area.Position,(_path[i+1].Value as ITerrain).Area.Position);
                }
            }
        }

        private INode GetNode(ITerrain terrain)
        {
            return (_context.World.Map as RectangleTileMap).Graph.Nodes.FirstOrDefault(x => x.Value == terrain);
        }
    }
}