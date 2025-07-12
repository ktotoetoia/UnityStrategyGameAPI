using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class UnitType : IHaveName
    {
        public string Name { get; set; }
        public IFactory<IUnit> Factory { get; set; }

        public UnitType(string name, IFactory<IUnit> factory)
        {
            Name = Name;
            Factory = factory;
        }
    }
}