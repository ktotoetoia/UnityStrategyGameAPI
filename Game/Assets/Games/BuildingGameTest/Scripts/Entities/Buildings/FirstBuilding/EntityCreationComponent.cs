using System;
using System.Collections;
using System.Collections.Generic;
using TDS;
using TDS.Components;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class EntityCreationComponent : Component, IEntityCreationComponent
    {
        protected readonly List<EntityInfo> _unitInfos = new();
        protected IPlacedOnTerrain _onTerrain;
        
        public IReadOnlyList<IEntityInfo> EntityInfos => _unitInfos;

        public virtual void AddToQueue(IEntityInfo entityInfo)
        {
            if (entityInfo is not EntityInfo info || !_unitInfos.Contains(info))
            {
                throw new ArgumentException();
            }
            
            IBuilder<IEntity> builder = info.Factory.Create();

            try
            {
                builder.Value.GetComponent<IPlacedOnTerrain>().PlacedOn = _onTerrain.PlacedOn;
            }
            catch
            {
                builder.CancelInitialization();

                return;
            }

            builder.FinishInitialization();
        }

        public override void OnRegistered()
        {
            _onTerrain = Entity.GetComponent<IPlacedOnTerrain>();
        }

        public IList GetItemSource()
        {
            return _unitInfos;
        }
    }
}