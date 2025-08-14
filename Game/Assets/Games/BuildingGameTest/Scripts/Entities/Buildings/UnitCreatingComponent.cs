using System;
using System.Collections;
using System.Collections.Generic;
using TDS;
using TDS.Entities;
using Component = TDS.Components.Component;

namespace BuildingsTestGame
{
    public class UnitCreatingComponent : Component, IUnitCreatingComponent
    {
        private IPlacedOnTerrain _onTerrain;
        private IPlacedOnTerrain OnTerrain => _onTerrain ??= Entity.GetComponent<IPlacedOnTerrain>();

        private readonly List<UnitInfo> _units = new ();
        public IReadOnlyList<IUnitInfo> UnitInfos => _units;

        public override void Init(IEntity entity)
        {
            base.Init(entity);
            
            _units.Add(new UnitInfo(new DefaultUnitFactory(Entity),"Default unit"));
        }

        public void AddToQueue(IUnitInfo unitInfo)
        {
            if (unitInfo is not UnitInfo info || !_units.Contains(info))
            {
                throw new ArgumentException();
            }
            
            if (OnTerrain.PlacedOn.Unit != null)
            {
                return;
            }
            
            IBuilder<IEntity> builder = info.Factory.Create();
            
            try
            {
                builder.Value.GetComponent<IPlacedOnTerrain>().PlacedOn = OnTerrain.PlacedOn;
            }
            catch
            {
                builder.CancelInitialization();
                
                return;
            }
            
            builder.FinishInitialization();
        }

        public IList GetItemSource()
        {
            return _units;
        }
    }
}