using System.Linq;
using TDS.Entities;
using TDS.Handlers;
using TDS.Maps;
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

        public void Handle(BuildingGame game)
        {
            IGameTerrainComponent terrain = game.Map.Terrains.First(x => x.TerrainArea.Contains(StartingPosition) && x.Components.Any(x => x is IGameTerrainComponent)).GetComponent<IGameTerrainComponent>();

            terrain.Building = new FirstBuildingFactory(game.EntityRegister).Create();
            
            new EventEntityInitializer().Initialize(terrain.Building);
        }
    }
}