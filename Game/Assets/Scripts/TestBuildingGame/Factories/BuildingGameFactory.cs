using System.Collections.Generic;
using TDS;
using TDS.Entities;
using TDS.Systems;
using TDS.TurnSystem;
using TDS.Worlds;
using UnityEngine;

namespace BuildingsTestGame
{
    public class BuildingGameFactory : IFactory<TurnBasedGame>
    {
        public Vector2Int Size { get; set; }

        public BuildingGameFactory() :this(Vector2Int.one * 5)
        {
            
        }

        public BuildingGameFactory(Vector2Int size)
        {
            Size = size;
        }
        
        public TurnBasedGame Create()
        {
            World world = CreateWorld();
            SystemManager systems = new SystemManager();
            List<ITurnUser> users = new List<ITurnUser>();
            
            systems.Systems.Add(new UnitCreation(world.EntityRegister));
            systems.Systems.Add(new TerrainSelector(world.Map));
            systems.Systems.Add(new Assigner());
            systems.Systems.Add(new BuildingCreation());
            
            users.Add(new AssignStage());
            users.Add(new BuildStage());
            users.Add(new EventStage());

            var turnSwitcher = new TurnSwitcher(users);

            return new TurnBasedGame(world, turnSwitcher, systems);
        }

        private World CreateWorld()
        {
            return new World(new RectangleTileMap(Size,new BuildingTerrainFactory()));
        }
    }
}