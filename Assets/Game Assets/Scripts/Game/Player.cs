using System;
using ArcheroCase.Enums;
using ArcheroCase.PowerUps;
using UnityEngine;

namespace ArcheroCase.Game
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _config;
        public PlayerConfig Config => _config;

        
       [SerializeField] private CharacterState _characterState;
        public CharacterState CharacterState => _characterState;
        

        public bool IsPlayerMoving { get; private set; }
        
        public Joystick Joystick { get; private set; }

        private void Awake()
        {
            PowerUpButton.OnPowerUpActivate += ActivatePowerUp;
            PowerUpButton.OnPowerUpDeactivate += DeactivatePowerUp;
        }


        private void Start()
        {
            Joystick = Joystick.Instance;  
        }

        private void Update()
        {
            IsPlayerMoving = Joystick.Direction.magnitude > 0;
        }

        private void ActivatePowerUp(PowerUp powerUp)
        {
            powerUp.Activate(this);
        }
        
        private void DeactivatePowerUp(PowerUp powerUp)
        {
            powerUp.Deactivate(this);
        }

        private void OnDisable()
        {
            PowerUpButton.OnPowerUpActivate -= ActivatePowerUp;
            PowerUpButton.OnPowerUpDeactivate -= DeactivatePowerUp;
        }
    }
}