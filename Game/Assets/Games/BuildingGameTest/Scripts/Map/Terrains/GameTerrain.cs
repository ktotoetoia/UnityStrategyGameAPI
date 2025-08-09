using System;
using Codice.Client.BaseCommands.BranchExplorer;
using TDS.Entities;
using TDS.Events;
using TDS.Maps;

namespace BuildingsTestGame
{
    public class GameTerrain : Terrain
    {
        public IGameTerrainComponent GameTerrainComponent { get; }

        public GameTerrain(ITerrainArea terrainArea) : base(terrainArea)
        {
            GameTerrainComponent = new GameTerrainComponent();
            AddComponent(new EventComponent());
            AddComponent(GameTerrainComponent);
        }
    }
}