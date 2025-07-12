using TDS.Entities;
using TDS.Factions;
using TDS.Worlds;
using UnityEngine;

namespace TDS.Systems
{
    public class UnitCreationSystem : ISystem
    {
        private IWorld _world;
        public IFactory<IFactionUnit,IFaction> Factory { get; set; }

        public UnitCreationSystem(IWorld world) : this(world, new FactionUnitFactory())
        {
            
        }
        
        public UnitCreationSystem(IWorld world, IFactory<IFactionUnit,IFaction> factory)
        {
            _world = world;
            Factory = factory;
        }
        
        public IFactionUnit CreateUnit(IFaction faction, Vector3 position)
        {
            IFactionUnit unit = Factory.Create(faction);
            
            unit.Transform.SetPosition(position);
            _world.EntityRegister.AddEntity(unit);
            
            return unit;
        }
    }
}