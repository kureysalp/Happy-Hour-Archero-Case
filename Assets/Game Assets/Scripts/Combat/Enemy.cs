using System;
using UnityEngine;
using UnityEngine.UI;

namespace ArcheroCase.Combat
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private EnemyConfig _config;
        private float _currentHealth;
        
        [SerializeField] private Image _healthBar;

        public static event Action OnEnemyDeath;
        
        private bool _isDead;
        
        private void SetEnemy()
        {
            _currentHealth = _config.MaximumHealth;
            SetHealthBar();
            _isDead = false;
        }

        private void SetHealthBar()
        {
            _healthBar.fillAmount = _currentHealth / _config.MaximumHealth;
        }
        
        public void TakeDamage(float damage)
        {
            if (_isDead) return;
            
            _currentHealth -= damage;
            SetHealthBar();

            if (_currentHealth <= 0)
                Die();
        }

        private void Die()
        {
            _isDead = true;
            OnEnemyDeath?.Invoke();
            // TODO: Return this to the pool.
        }
    }
}