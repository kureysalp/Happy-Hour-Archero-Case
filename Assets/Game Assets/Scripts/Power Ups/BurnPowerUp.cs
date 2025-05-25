using System;
using ArcheroCase.Auras;
using ArcheroCase.Game;
using UnityEngine;

namespace ArcheroCase.PowerUps
{
    [CreateAssetMenu(fileName = "SO_Burn_Power_Up", menuName = "Scriptable Objects/Power Ups/Burn Enemy")]
    public class BurnPowerUp : PowerUp
    {
        [SerializeField] private float _duration;
        [SerializeField] private float _damage;
        
        private BurnAura _burnAura;

        private void OnEnable()
        {
            _burnAura = new BurnAura(_duration, _damage);
        }

        public override void Activate(Player player)
        {
            player.Config.ProjectileConfig.AddAura(_burnAura);
        }

        public override void Deactivate(Player player)
        {
            player.Config.ProjectileConfig.RemoveAura(_burnAura);
        }

        public override void EnableRage(Player player)
        {
            _burnAura.ChangeDuration(_duration * 2);
        }

        public override void DisableRage(Player player)
        {
            _burnAura.ChangeDuration(_duration);
        }

        private void OnValidate()
        {
            _duration = 3f;
        }
    }
}