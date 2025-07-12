using TDS;

namespace BuildingsTestGame
{
    public class BuildingType : IHaveName
    {
        public string Name { get; set; }
        public IFactory<IBuilding> Factory { get; set; }

        public BuildingType(string name, IFactory<IBuilding> factory)
        {
            Name = name;
            Factory = factory;
        }
    }
}