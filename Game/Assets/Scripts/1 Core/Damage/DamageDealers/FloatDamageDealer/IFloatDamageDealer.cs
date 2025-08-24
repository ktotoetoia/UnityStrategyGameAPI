namespace TDS.Damage
{
    public interface IFloatDamageDealer : IDamageDealer
    {
        public float Damage { get; set; }
    }
}