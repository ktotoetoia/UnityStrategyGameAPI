using TDS.Entities;

namespace BuildingsTestGame
{
    public class BuilderComponent : EntityCreationComponent
    {
        public override void Init(IEntity entity)
        {
            base.Init(entity);
            
            _unitInfos.Add(new EntityInfo(new FirstBuildingFactory(Entity),"First Building"));
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