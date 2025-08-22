using System;
using System.Collections;
using System.Collections.Generic;
using TDS.Entities;
using TDS.Factions;
using Component = TDS.Components.Component;

namespace BuildingsTestGame
{
    public class EntityCreationComponent : Component, IEntityCreationComponent
    {
        protected readonly List<EntityInfo> _unitInfos = new();
        protected IPlacedOnTerrain _onTerrain;
        protected IFactionComponent _factionComponent;
        
        public IReadOnlyList<IEntityInfo> EntityInfos => _unitInfos;

        public virtual void AddToQueue(IEntityInfo entityInfo)
        {
            if (entityInfo is not EntityInfo info || !_unitInfos.Contains(info))
            {
                throw new ArgumentException();
            }
            
            IEntity entity = info.Factory.Create();
            
            entity.GetComponent<IPlacedOnTerrain>().MoveTo(_onTerrain.PlacedOn);
        }

        public override void OnRegistered()
        {
            _onTerrain = Entity.GetComponent<IPlacedOnTerrain>();
            _factionComponent = Entity.GetComponent<IFactionComponent>();
        }

        public IList GetItemSource()
        {
            return _unitInfos;
        }
    }
}