using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public interface IProductionBuilding : IBuilding
    {
        void AddToQueue(IFactory<IUnit> entityFactory);
    }
}