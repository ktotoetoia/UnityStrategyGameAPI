using TDS;

namespace BuildingsTestGame
{
    public interface IProductionBuilding : IBuilding
    {
        void AddToQueue(IFactory<IUnit> entityFactory);
    }
}