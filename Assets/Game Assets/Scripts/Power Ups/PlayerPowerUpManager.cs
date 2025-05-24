using System;
using System.Collections.Generic;
using ArcheroCase.Game;
using UnityEngine;

namespace ArcheroCase.PowerUps
{
    public class PlayerPowerUpManager : MonoBehaviour
    {
        private readonly List<PowerUp> _powerUps = new();
        
        private Player _player;

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        public void AddPowerUp(PowerUp powerUp)
        {
            _powerUps.Add(powerUp);
            powerUp.Activate(_player);
        }
        
        public void RemovePowerUp(PowerUp powerUp)
        {
            _powerUps.Add(powerUp);
            powerUp.Deactivate(_player);
        }
        
        
    }
}