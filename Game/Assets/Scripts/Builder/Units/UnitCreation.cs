using System.Collections.Generic;
using TDS.Entities;
using TDS.Systems;

namespace BuildingsTestGame
{
    public class UnitCreation : ISystem
    {
        private IEntityRegister _register;

        public UnitCreation(IEntityRegister register)
        {
            _register = register;
        }

        public IUnit Create()
        {
            IUnit unit = new DefaultUnit();
            
            _register.AddEntity(unit);
            
            return unit;
        }

        public IEnumerable<IUnit> AvailableUnits()
        {
            throw new System.NotImplementedException();
        }
    }
}