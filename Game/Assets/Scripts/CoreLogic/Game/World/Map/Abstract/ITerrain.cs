namespace TDS.Worlds
{
    public interface ITerrain : IHaveName
    {
        IArea Area { get; }
    }
}