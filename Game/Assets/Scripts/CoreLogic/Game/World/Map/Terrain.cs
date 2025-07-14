namespace TDS.Worlds
{
    public class Terrain : ITerrain
    {
        public string Name { get; set; }
        public IArea Area { get; set; }

        public Terrain(IArea area) :this("no name", area)
        {
            
        }
        
        public Terrain(string name, IArea area)
        {
            Name = name;
            Area = area;
        }
    }
}