using System;
using ArcheroCase.Game;
using UnityEngine;

namespace ArcheroCase.PowerUps
{
    [CreateAssetMenu(fileName = "SO_Multi_Shot_Power_Up", menuName = "Scriptable Objects/Power Ups/Multi Shot")]

    public class MultiShot : PowerUp
    {
        [SerializeField] private int _multiShotAmount;
        
        public override void Activate(Player player)
        {
            player.Config.SetMultishotCountModifier(_multiShotAmount);
        }

        public override void Deactivate(Player player)
        {
            player.Config.SetMultishotCountModifier(0);
        }

        public override void EnableRage(Player player)
        {
            _multiShotAmount++;
            if (player.HasPowerUp(this))
                player.Config.SetMultishotCountModifier(_multiShotAmount);
        }

        public override void DisableRage(Player player)
        {
            _multiShotAmount--;
            if (player.HasPowerUp(this))
                player.Config.SetMultishotCountModifier(_multiShotAmount);
            
        }

        private void OnValidate()
        {
            _multiShotAmount = 1;
        }
    }
}