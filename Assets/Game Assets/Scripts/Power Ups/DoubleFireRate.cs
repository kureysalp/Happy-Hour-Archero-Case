using ArcheroCase.Game;
using UnityEngine;

namespace ArcheroCase.PowerUps
{
    [CreateAssetMenu(fileName = "SO_Fire_Rate_Power_Up", menuName = "Scriptable Objects/Power Ups/Fire Rate")]
    public class DoubleFireRate : PowerUp
    {
        public override void Activate(Player player)
        {
            player.Config.SetFireRateMultiplier(2);
        }

        public override void Deactivate(Player player)
        {
            player.Config.SetFireRateMultiplier(1);
        }
    }
}