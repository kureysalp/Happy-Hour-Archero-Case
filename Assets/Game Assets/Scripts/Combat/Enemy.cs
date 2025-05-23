using System;
using ArcheroCase.Mangers;
using UnityEngine;
using UnityEngine.UI;

namespace ArcheroCase.Combat
{
    public class Enemy : Poolable, IDamageable
    {
        [SerializeField] private EnemyConfig _config;
        private float _currentHealth;
        
        [SerializeField] private Image _healthBar;

        public static event Action<Enemy> OnEnemyDeath;
        
        private bool _isDead;
        
        public void SetEnemy()
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

        public void Die()
        {
            _isDead = true;
            OnEnemyDeath?.Invoke(this);
        }
    }
}