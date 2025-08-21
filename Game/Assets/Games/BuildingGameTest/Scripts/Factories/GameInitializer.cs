using System.Linq;
using TDS;
using TDS.Entities;
using TDS.Handlers;
using TDS.Maps;
using TDS.SelectionSystem;
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

            FirstBuilding building = new FirstBuildingFactory(game.EntityRegistry).Create();
            
            building.GetComponent<IPlacedOnTerrain>().MoveTo( terrain);
            
            new UpdateEntitiesOnTurnStart(game.PlayerStage,game.EntityRegistry).Subscribe();
            game.PlayerStage.Services.Add(new MoveService(() => game.CurrentStage == game.PlayerStage, new MapPathfinder(game.Map) { PathResolver = new NoUnitPathResolver() }));
            game.PlayerStage.Services.Add(new EndTurnService(() => game.CurrentStage == game.PlayerStage, game.PlayerStage));
            game.PlayerStage.Services.Add(new UnitCreationService(() => game.CurrentStage == game.PlayerStage));
        }
    }
}