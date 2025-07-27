namespace TDS.Maps
{
    public interface ITerrain : IHaveName
    {
        IArea Area { get; }
    }
}