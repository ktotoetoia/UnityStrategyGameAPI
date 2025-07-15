using TDS.Entities;

namespace BuildingsTestGame
{
    public interface IProductionBuilding : IBuilding
    {
        void AddToQueue(IUnit unit);
    }
}