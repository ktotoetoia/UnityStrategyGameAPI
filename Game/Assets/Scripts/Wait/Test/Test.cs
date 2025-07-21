using System;
using System.Linq;
using BuildingsTestGame;
using TDS.Entities;
using TDS.Graphs;
using TDS.Pathfinding;
using TDS.TurnSystem;
using TDS.Worlds;
using UnityEngine;

namespace TDS
{
    [DefaultExecutionOrder(100)]
    public class Test : MonoBehaviour
    {
        [SerializeField] private Vector2Int _size;
        [SerializeField] private Vector2Int _firstBuildingPosition;
        [SerializeField] private BuildingGameUI _buildingGameUI;
        [SerializeField] private int _f;
        private BuildingGame _game;
        
        private void Awake()
        {
            _game = new BuildingGameFactory(_size){StartingPosition = _firstBuildingPosition }.Create();
            GetComponent<MapUIDebug>().Map = _game.World.Map;
            _buildingGameUI.Game = _game;
        }

        private void Update()
        {
            _game.Update();
        }

        private void OnDrawGizmos()
        {
            if (_game == null)
            {
                return;
            }

            if (_game.GameContext.Selector.Selection.First != null)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawSphere(_game.GameContext.Selector.GetSelectionOfType<ITerrain>().First.Area.Position,0.2f);
            }
            Gizmos.color = Color.blue;

            IGraphReadOnly<ITerrain> graph = new BreadthFirstTraversal()
                .FindReachableSubgraph(
                    (_game.GameContext.World.Map as IGraphMap).GetNode(_game.GameContext.Selector
                        .GetSelectionOfType<ITerrain>().First),
                    x => x.Count() < 4);
            
            foreach (INode<ITerrain> node in graph.Nodes)
            {
                Gizmos.DrawSphere(node.Value.Area.Position,0.2f);
            }

            foreach (IEdge<ITerrain> edge in graph.Edges)
            {
                Gizmos.DrawLine(edge.From.Value.Area.Position,edge.To.Value.Area.Position);
            }
        }
    }
}