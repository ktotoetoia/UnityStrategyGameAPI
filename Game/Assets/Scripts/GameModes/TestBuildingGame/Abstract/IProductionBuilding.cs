using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public interface IProductionBuilding : IBuilding
    {
        void AddToQueue(IFactory<IEntity> entityFactory);
    }
}