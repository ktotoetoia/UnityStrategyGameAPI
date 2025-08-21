namespace TDS.Entities
{
    public interface IHaveEntityRegistry
    {
        public IEntityRegistry EntityRegistry { get; set; }
    }
}