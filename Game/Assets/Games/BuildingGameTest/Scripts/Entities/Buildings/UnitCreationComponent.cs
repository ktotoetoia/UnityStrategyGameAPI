using System;
using System.Collections;
using System.Collections.Generic;
using TDS;
using TDS.Entities;
using Component = TDS.Components.Component;

namespace BuildingsTestGame
{
    public class UnitCreationComponent : Component, IEntityCreationComponent
    {
        private IPlacedOnTerrain _onTerrain;
        private IPlacedOnTerrain OnTerrain => _onTerrain ??= Entity.GetComponent<IPlacedOnTerrain>();

        private readonly List<EntityInfo> _unitInfos = new ();
        public IReadOnlyList<IEntityInfo> EntityInfos => _unitInfos;

        public override void Init(IEntity entity)
        {
            base.Init(entity);
            
            _unitInfos.Add(new EntityInfo(new DefaultUnitFactory(Entity),"Default Unit"));
            _unitInfos.Add(new EntityInfo(new BuilderFactory(Entity),"Builder"));
        }

        public void AddToQueue(IEntityInfo entityInfo)
        {
            if (entityInfo is not EntityInfo info || !_unitInfos.Contains(info))
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
            return _unitInfos;
        }
    }
}