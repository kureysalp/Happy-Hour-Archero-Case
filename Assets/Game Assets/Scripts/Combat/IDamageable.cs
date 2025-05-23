namespace ArcheroCase.Combat
{
    public interface IDamageable
    {
        void TakeDamage(float damage);

        void Die();
    }
}