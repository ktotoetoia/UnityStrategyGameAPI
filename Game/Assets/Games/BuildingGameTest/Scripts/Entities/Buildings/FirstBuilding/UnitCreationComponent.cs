using TDS.Entities;

namespace BuildingsTestGame
{
    public class UnitCreationComponent : EntityCreationComponent
    {
        public override void Init(IEntity entity)
        {
            base.Init(entity);

            _unitInfos.Add(new EntityInfo(new DefaultUnitFactory(Entity), "Default Unit"));
            _unitInfos.Add(new EntityInfo(new BuilderFactory(Entity), "Builder"));
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