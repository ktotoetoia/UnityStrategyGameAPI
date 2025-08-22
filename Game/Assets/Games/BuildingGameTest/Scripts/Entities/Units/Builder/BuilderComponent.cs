namespace BuildingsTestGame
{
    public class BuilderComponent : EntityCreationComponent
    {
        public override void OnRegistered()
        {
            base.OnRegistered();
            
            _unitInfos.Add(new EntityInfo(new FirstBuildingFactory(Entity.EntityRegistry, _factionComponent.Faction),"First Building"));
        }

        public override void AddToQueue(IEntityInfo entityInfo)
        {
            if (_onTerrain.PlacedOn.Building == null)
            {
                base.AddToQueue(entityInfo);
            }
        }
    }
}