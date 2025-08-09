using TDS.Components;
using TDS.Entities;
using TDS.Maps;

namespace BuildingsTestGame
{
    public interface IGameTerrainComponent : ITerrainComponent
    {
        public IEntity Unit { get; set; }
        public IEntity Building { get; set; }
    }
}