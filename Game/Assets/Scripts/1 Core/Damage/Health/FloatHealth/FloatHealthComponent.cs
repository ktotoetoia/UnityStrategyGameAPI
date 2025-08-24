using TDS.Components;
using TDS.Economy;

namespace TDS.Damage
{
    public class FloatHealthComponent : Component, IFloatHealth
    {
        public IFloatHealth FloatHealthImplementation { get; set; }
        public ICappedValueReadOnly<float> Health => FloatHealthImplementation.Health;
        
        public FloatHealthComponent() : this(new RawFloatHealth(0,100,100))
        {
            
        }

        public FloatHealthComponent(float health) : this(new RawFloatHealth(0, health, health))
        {
            
        }

        public FloatHealthComponent(IFloatHealth floatHealthImplementation)
        {
            FloatHealthImplementation = floatHealthImplementation;
        }
        
        public float PreviewDamage(float incomingDamage)
        {
            return FloatHealthImplementation.PreviewDamage(incomingDamage);
        }

        public void ApplyDamage(float damage)
        {
            FloatHealthImplementation.ApplyDamage(damage);
        }
    }
}