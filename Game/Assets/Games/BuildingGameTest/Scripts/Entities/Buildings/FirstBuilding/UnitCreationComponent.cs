using TDS.Entities;

namespace BuildingsTestGame
{
    public class UnitCreationComponent : EntityCreationComponent
    {
        public override void OnRegistered()
        {
            base.OnRegistered();
            
            _unitInfos.Add(new EntityInfo(new DefaultUnitFactory(Entity.EntityRegistry), "Default Unit"));
            _unitInfos.Add(new EntityInfo(new BuilderFactory(Entity.EntityRegistry), "Builder"));
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