using TDS;
using TDS.Components;
using TDS.Entities;

namespace BuildingsTestGame
{
    public interface IBuildingComponent : IComponent
    {
        void AddToQueue(IFactory<IEntity> unitFactory);
    }
}