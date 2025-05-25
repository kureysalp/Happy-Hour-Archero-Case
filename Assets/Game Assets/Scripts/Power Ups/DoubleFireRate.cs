using System;
using ArcheroCase.Game;
using UnityEngine;

namespace ArcheroCase.PowerUps
{
    [CreateAssetMenu(fileName = "SO_Fire_Rate_Power_Up", menuName = "Scriptable Objects/Power Ups/Fire Rate")]
    public class DoubleFireRate : PowerUp
    {
        private int _doubleAmount;
        public override void Activate(Player player)
        {
            player.Config.SetFireRateMultiplier(_doubleAmount);
        }

        public override void Deactivate(Player player)
        {
            player.Config.SetFireRateMultiplier(1);
        }

        public override void EnableRage(Player player)
        {
            _doubleAmount = 4;
            if (player.HasPowerUp(this))
                player.Config.SetFireRateMultiplier(_doubleAmount);
        }

        public override void DisableRage(Player player)
        {
            _doubleAmount = 2;
            if (player.HasPowerUp(this))
                player.Config.SetFireRateMultiplier(_doubleAmount);
        }

        private void OnValidate()
        {
            _doubleAmount = 2;
        }
    }
}