using TDS;
using TDS.Entities;
using Component = TDS.Components.Component;

namespace BuildingsTestGame
{
    public class BuildingComponent : Component, IBuildingComponent
    {
        private IPlacedOnTerrain _onTerrain;
        private IPlacedOnTerrain OnTerrain => _onTerrain ??= Entity.GetComponent<IPlacedOnTerrain>();
        
        public void AddToQueue(IFactory<IBuilder<IEntity>> entityFactory)
        {
            if (OnTerrain.PlacedOn.Unit != null)
            {
                return;
            }
            
            IBuilder<IEntity> builder = entityFactory.Create();
            
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
    }
}