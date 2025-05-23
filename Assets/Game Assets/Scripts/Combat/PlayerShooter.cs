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
        [SerializeField] private float _shootAngle;
        
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
            EnemyDetector.OnEnemyOutOfRange += UnTargetEnemy;
            Enemy.OnEnemyDeath += CheckIsTargetDead;
        }

        private void Update()
        {
            if (_currentTarget is not null && !_player.IsPlayerMoving)
                Shoot();
        }

        private void TargetEnemy(Enemy enemy)
        {
            _currentTarget = enemy;
        }

        private void UnTargetEnemy()
        {
            _currentTarget = null;
        }

        private void CheckIsTargetDead(Enemy enemy)
        {
            if (enemy == _currentTarget)
                UnTargetEnemy();
        }

        private void Shoot()
        {
            if (Time.time - _lastShootTime < 1 / FireRate) return;
            if (_currentTarget is null) return;
            
            var projectile = Poolable.Get<Projectile>();
            projectile.transform.position = _projectileSpawnPosition.position;

            var directionOfEnemy =  _currentTarget.transform.position- transform.position;

            var targetDistance = directionOfEnemy.magnitude;
            var targetHeight = _currentTarget.transform.position.y;
            var gravity = -Physics.gravity.y;
            
            var v1 = Mathf.Pow(targetDistance, 2) * gravity;
            var v2 = 2 * targetDistance * Mathf.Sin(_shootAngle) * Mathf.Cos(_shootAngle);
            var v3 = 2 * targetHeight * Mathf.Pow(Mathf.Cos(_shootAngle), 2);

            var rotateAxis = Quaternion.AngleAxis(90, Vector3.up) * directionOfEnemy.normalized;
            var projectileDirection = Quaternion.AngleAxis(-_shootAngle, rotateAxis) * directionOfEnemy.normalized;

            var initialVelocity = Mathf.Sqrt(v1 / (v2 - v3)) * projectileDirection; 
            projectile.SetVelocity(initialVelocity);

            projectile.transform.rotation = Quaternion.LookRotation(projectileDirection);
            
            
            
            /*var lookAtPosition = _currentTarget.transform.position;
            lookAtPosition.y = 0;
            projectile.transform.LookAt(lookAtPosition);
            */
            
            //TODO: Add power up modifiers.
            
            _lastShootTime = Time.time;
        }
        
        private void OnDisable()
        {
            EnemyDetector.OnEnemyDetected -= TargetEnemy;
            EnemyDetector.OnEnemyOutOfRange -= UnTargetEnemy;
            Enemy.OnEnemyDeath -= CheckIsTargetDead;
        }
    }
}