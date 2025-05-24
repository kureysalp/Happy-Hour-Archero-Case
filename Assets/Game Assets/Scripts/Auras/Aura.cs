using ArcheroCase.Combat;
using ArcheroCase.Enums;
using UnityEngine;

namespace ArcheroCase.Auras
{
    public abstract class Aura
    {
        protected AuraType AuraType { get; set; }
        protected float AuraDuration { get; set; }
        protected float _auraTimer;


        protected virtual void RemoveAura(Enemy enemy)
        {
            enemy.RemoveAura(this);
        }

        public virtual void AuraUpdateTick(Enemy enemy)
        {
            _auraTimer += Time.deltaTime;
            if (_auraTimer >= AuraDuration)
                RemoveAura(enemy);
        }



    }
}