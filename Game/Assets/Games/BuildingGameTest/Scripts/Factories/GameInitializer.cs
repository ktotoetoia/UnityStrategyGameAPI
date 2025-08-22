using System.Linq;
using TDS.Entities;
using TDS.Factions;
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

            FactionContext hoomansContext = new FactionContext( new Faction("Hoomans", Color.cyan),game.EntityRegistry );
            FactionContext zombiesContext = new FactionContext( new Faction("Zombies", Color.red),game.EntityRegistry );
           
            game.PlayerStage.FactionContext = hoomansContext;
            game.EnemyStage.FactionContext = zombiesContext;
            game.FactionsManager.FactionContexts.Add( hoomansContext );
            game.FactionsManager.FactionContexts.Add( zombiesContext );
            
            FirstBuilding building = new FirstBuildingFactory(game.EntityRegistry,hoomansContext.Faction).Create();
            
            building.GetComponent<IPlacedOnTerrain>().MoveTo( terrain);
            
            game.PlayerStage.Services.Add(new MoveService(() => game.CurrentStage == game.PlayerStage, new MapPathfinder(game.Map) { PathResolver = new NoUnitPathResolver() },hoomansContext.Faction));
            game.PlayerStage.Services.Add(new EndTurnService(() => game.CurrentStage == game.PlayerStage, game.PlayerStage));
            game.PlayerStage.Services.Add(new UnitCreationService(() => game.CurrentStage == game.PlayerStage));
            
            game.EnemyStage.Services.Add(new EndTurnService(() => game.CurrentStage == game.EnemyStage, game.EnemyStage));

            game.EnemyStage.ActionOnStart += () =>
            {
                var terrainC = game.Map.Terrains.WithComponent<IGameTerrainComponent>().Where(x => x.Item2.Unit == null).ToList();
                
                int randomIndex = Random.Range(0, terrainC.Count);

                new DefaultUnitFactory(game.EntityRegistry,zombiesContext.Faction).Create().GetComponent<IPlacedOnTerrain>().MoveTo(terrainC[randomIndex].Item2);
            };
        }
    }
}