using ArcheroCase.Game;
using UnityEngine;

namespace ArcheroCase.PowerUps
{
    [CreateAssetMenu(fileName = "SO_Rage_Mode_Power_Up", menuName = "Scriptable Objects/Power Ups/Rage Mode")]
    public class RageMode : PowerUp
    {
        [SerializeField] private PowerUp[] _powerUpsToApply;
        
        public override void Activate(Player player)
        {
            foreach (var powerUp in _powerUpsToApply)
                powerUp.EnableRage(player);
        }

        public override void Deactivate(Player player)
        {
            foreach (var powerUp in _powerUpsToApply)
                powerUp.DisableRage(player);
        }
    }
}