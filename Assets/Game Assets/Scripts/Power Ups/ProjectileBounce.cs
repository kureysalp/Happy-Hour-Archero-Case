using System;
using ArcheroCase.Game;
using UnityEngine;

namespace ArcheroCase.PowerUps
{
    [CreateAssetMenu(fileName = "SO_Projectile_Bounce_Power_Up", menuName = "Scriptable Objects/Power Ups/Projectile Bounce")]

    public class ProjectileBounce : PowerUp
    {
        [SerializeField] private int _bounceCount;
        
        public override void Activate(Player player)
        {
            player.Config.ProjectileConfig.SetBouneCountModifier(_bounceCount);
        }

        public override void Deactivate(Player player)
        {
            player.Config.ProjectileConfig.SetBouneCountModifier(0);
        }

        public override void EnableRage(Player player)
        {
            _bounceCount++;
            if(player.HasPowerUp(this))
                player.Config.ProjectileConfig.SetBouneCountModifier(_bounceCount);
        }

        public override void DisableRage(Player player)
        {
            _bounceCount--; 
            if(player.HasPowerUp(this))
                player.Config.ProjectileConfig.SetBouneCountModifier(_bounceCount);
        }

        private void OnValidate()
        {
            _bounceCount = 1;
        }
    }
}