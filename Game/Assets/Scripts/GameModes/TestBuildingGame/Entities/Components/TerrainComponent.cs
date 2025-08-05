using TDS.Components;

namespace BuildingsTestGame
{
    public class TerrainComponent : Component, ITerrainComponent
    {
        private IGameTerrain _terrain;

        public IGameTerrain Terrain
        {
            get => _terrain;
            set
            {
                ThrowExceptionIfDestroyed();
                _terrain = value;
                Entity.Transform.SetPosition(value.Area.Position);
            }
        }
    }
}