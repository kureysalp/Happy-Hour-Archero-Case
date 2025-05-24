using ArcheroCase.Auras;

namespace ArcheroCase.Combat
{
    public interface IDamageable
    {
        void TakeDamage(float damage);

        void Die();
        
        void ApplyAura(Aura aura);
    }
}