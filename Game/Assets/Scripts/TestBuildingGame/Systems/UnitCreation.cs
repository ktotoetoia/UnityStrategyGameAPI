using System.Collections.Generic;
using System.Linq;
using TDS;
using TDS.Entities;
using TDS.Systems;
using UnityEditor;

namespace BuildingsTestGame
{
    public class UnitCreation : ISystem
    {
        private IEntityRegister _register;
        private List<UnitType> _unitTypes;

        public UnitCreation(IEntityRegister register) : this(register, new List<UnitType>() {new ("Default",new DynamicFactory<IUnit>(() => new DefaultUnit()))})
        {
            
        }

        public UnitCreation(IEntityRegister register, List<UnitType> unit)
        {
            _register = register;
            _unitTypes = unit;
        }

        public IUnit Create()
        {
            return Create(_unitTypes[0]);
        }
        
        public IUnit Create(UnitType unitType)
        {
            IUnit unit = unitType.Factory.Create();
            
            _register.AddEntity(unit);
            
            return unit;
        }

        public void Destroy(IUnit unit)
        {
            unit.Destroy();
            _register.RemoveEntity(unit);
        }

        public IEnumerable<UnitType> AvailableUnits()
        {
            return _unitTypes;
        }
    }
}