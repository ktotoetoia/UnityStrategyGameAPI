using System;
using System.Collections;
using System.Collections.Generic;
using TDS;
using TDS.Components;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class BuilderComponent : Component,IEntityCreationComponent
    {
        
        private readonly List<EntityInfo> _unitInfos = new ();
        private IPlacedOnTerrain _onTerrain;
        private IPlacedOnTerrain OnTerrain => _onTerrain ??= Entity.GetComponent<IPlacedOnTerrain>();
        public IReadOnlyList<IEntityInfo> EntityInfos => _unitInfos;

        public override void Init(IEntity entity)
        {
            base.Init(entity);
            
            _unitInfos.Add(new EntityInfo(new FirstBuildingFactory(Entity),"First Building"));
        }

        public void AddToQueue(IEntityInfo entityInfo)
        {
            if (entityInfo is not EntityInfo info || !_unitInfos.Contains(info))
            {
                throw new ArgumentException();
            }
            
            if (OnTerrain.PlacedOn.Building != null)
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