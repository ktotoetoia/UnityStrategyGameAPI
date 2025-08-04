using System.Linq;
using TDS.Handlers;
using UnityEngine;

namespace BuildingsTestGame
{
    public class GameInitializer : IHandler<BuildingGame>
    {
        public Vector2 StartingPosition { get; set; }
        
        public GameInitializer(Vector2 startingPosition)
        {
            StartingPosition = startingPosition;
        }

        public bool CanHandle(BuildingGame game)
        {
            return !game.Map.Terrains.Any(x => x is IGameTerrain terrain && terrain.Building != null);
        }

        public void Handle(BuildingGame game)
        {
            IGameTerrain terrain = game.Map.Terrains.First(x => x.Area.Contains(StartingPosition) && x is IGameTerrain) as IGameTerrain;

            terrain.Building = new FirstBuildingFactory(game.EntityRegister).Create();
        }
    }
}