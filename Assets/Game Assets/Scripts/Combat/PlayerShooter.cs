using System;
using ArcheroCase.Enums;
using ArcheroCase.Game;
using ArcheroCase.Mangers;
using UnityEngine;

namespace ArcheroCase.Combat
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private Transform _projectileSpawnPosition;
        
        private Player _player;
        private Enemy _currentTarget;

        private float _lastShootTime;
        
        private float FireRate => _player.Config.BaseFireRate * _fireRateMultiplier;

        private float _fireRateMultiplier = 1f;
        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        private void Start()
        {
            EnemyDetector.OnEnemyDetected += TargetEnemy;
        }

        private void Update()
        {
            if (_player.CharacterState == CharacterState.Attacking)
                Shoot();
        }

        private void TargetEnemy(Enemy enemy)
        {
            _currentTarget = enemy;
            _player.ChangeState(CharacterState.Attacking);
        }

        private void Shoot()
        {
            if (Time.time - _lastShootTime < 1 / FireRate) return;
            if (_currentTarget is null) return;
            
            var projectile = Poolable.Get<Projectile>();
            projectile.transform.position = _projectileSpawnPosition.position;
            var lookAtPosition = _currentTarget.transform.position;
            lookAtPosition.y = 0;
            projectile.transform.LookAt(lookAtPosition);
            
            //TODO: Add power up modifiers.
            
            _lastShootTime = Time.time;
        }
        
        private void OnDisable()
        {
            EnemyDetector.OnEnemyDetected -= TargetEnemy;
        }
    }
}