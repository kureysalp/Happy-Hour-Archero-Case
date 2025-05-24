using System;
using TMPro;
using UnityEngine;

namespace ArcheroCase.PowerUps
{
    public class PowerUpButton : MonoBehaviour
    {
        [SerializeField] private PowerUp _powerUp;
        [SerializeField] private TextMeshProUGUI _powerUpName;
        [SerializeField] private GameObject _activeOutline;

        private bool _isActive;
        
        public static event Action<PowerUp> OnPowerUpActivate;
        public static event Action<PowerUp> OnPowerUpDeactivate;

        private void Start()
        {
            _powerUpName.text = _powerUp.Name;
        }

        public void TogglePowerUp()
        {
            _isActive = !_isActive;
            _activeOutline.SetActive(_isActive);
            
            if(_isActive)
                OnPowerUpActivate?.Invoke(_powerUp);
            else
                OnPowerUpDeactivate?.Invoke(_powerUp);
        }
    }
}