using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class EntityInfo : IEntityInfo
    {
        public IFactory<IBuilder<IEntity>> Factory { get; }
        public string Name { get; set; }
        
        public EntityInfo(IFactory<IBuilder<IEntity>> factory, string name)
        {
            Factory = factory;
            Name = name;
        }
    }
}