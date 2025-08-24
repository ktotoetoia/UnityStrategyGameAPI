using TDS.Economy;

namespace TDS.Damage
{
    public interface IFloatHealth : IDamageable
    {
        public ICappedValueReadOnly<float> Health { get; }
    }
}