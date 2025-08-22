namespace BuildingsTestGame
{
    public class UnitCreationComponent : EntityCreationComponent
    {
        public override void OnRegistered()
        {
            base.OnRegistered();
            
            _unitInfos.Add(new EntityInfo(new DefaultUnitFactory(Entity.EntityRegistry,_factionComponent.Faction), "Default Unit"));
            _unitInfos.Add(new EntityInfo(new BuilderFactory(Entity.EntityRegistry,_factionComponent.Faction), "Builder"));
        }

        public override void AddToQueue(IEntityInfo entityInfo)
        {
            if (_onTerrain.PlacedOn.Unit == null)
            {
                base.AddToQueue(entityInfo);
            }
        }
    }
}