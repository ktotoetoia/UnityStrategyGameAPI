using TDS;

namespace BuildingsTestGame
{
    public class ObjectInfo : IHaveName
    {
        public string Name { get; set; }

        public ObjectInfo(string name)
        {
            Name = name;
        }
    }
}