using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class UnitInfo : IUnitInfo
    {
        public IFactory<IBuilder<IEntity>> Factory { get; }
        public string Name { get; set; }
        
        public UnitInfo(IFactory<IBuilder<IEntity>> factory, string name)
        {
            Factory = factory;
            Name = name;
        }
    }
}