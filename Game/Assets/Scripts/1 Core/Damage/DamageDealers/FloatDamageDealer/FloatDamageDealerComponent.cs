using TDS.Components;

namespace TDS.Damage
{
    public class FloatDamageDealerComponent : Component, IFloatDamageDealer
    {
        private IFloatDamageDealer FloatDamageDealerImplementation { get; set; }
        public float Damage {get => FloatDamageDealerImplementation.Damage; set => FloatDamageDealerImplementation.Damage = value; }

        public FloatDamageDealerComponent() : this(10)
        {
            
        }
        
        public FloatDamageDealerComponent(float damage) :this (new RawFloatDamageDealer(damage)) 
        {
            
        }

        public FloatDamageDealerComponent(IFloatDamageDealer floatDamageDealerImplementation)
        {
            FloatDamageDealerImplementation = floatDamageDealerImplementation;
        }
        
        public float PreviewDamage(IDamageable target)
        {
            return FloatDamageDealerImplementation.PreviewDamage(target);
        }

        public void DealDamage(IDamageable target)
        {
            FloatDamageDealerImplementation.DealDamage(target);
        }
    }
}