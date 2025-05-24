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
            player.Config.ProjectileConfig.AddBounceCountModifier(_bounceCount);
        }

        public override void Deactivate(Player player)
        {
            player.Config.ProjectileConfig.RemoveBounceCountModifier(_bounceCount);
        }
    }
}