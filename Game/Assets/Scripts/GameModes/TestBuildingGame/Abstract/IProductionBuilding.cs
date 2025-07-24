using System.Collections.Generic;
using TDS.Entities;
using TDS.Events;

namespace BuildingsTestGame
{
    public interface IProductionBuilding : IBuilding
    {
        void AddToQueue(IUnit unit);
    }
}