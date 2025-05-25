using ArcheroCase.Combat;
using UnityEngine;

namespace ArcheroCase.Auras
{
    public class BurnAura : Aura
    {
        private float _burnDamage;

        private float _executionTimer;
        
        public BurnAura(float duration, float damage)
        {
            AuraDuration = duration;
            _burnDamage = damage;
        }
        
        public BurnAura(BurnAura aura)
        {
            AuraDuration = aura.AuraDuration;
            _burnDamage = aura._burnDamage;
        }
        
        public override void AuraUpdateTick(Enemy enemy)
        {
            base.AuraUpdateTick(enemy);
            
            _executionTimer += Time.deltaTime;
            if(_executionTimer >= 1)
            {
                _executionTimer -= 1;
                enemy.TakeDamage(_burnDamage);
            }
        }

        public void ChangeDuration(float duration)
        {
            AuraDuration = duration;
        }
        
    }
}