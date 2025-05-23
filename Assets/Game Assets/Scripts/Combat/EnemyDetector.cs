using System;
using ArcheroCase.Character_Controller;
using ArcheroCase.Enums;
using ArcheroCase.Game;
using UnityEngine;

namespace ArcheroCase.Combat
{
    public class EnemyDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _enemyLayer;
        
        private Player _player;
        public Collider[] _enemyColliders;

        public static event Action<Enemy> OnEnemyDetected;
        public static event Action OnEnemyOutOfRange;

        private Enemy _currentDetectedEnemy;
        
        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        private void Update()
        {
            LookForEnemy();            
        }

        private void LookForEnemy()
        {
            if (_player.IsPlayerMoving) return;

            var maxColliderCount = 5;
            
            _enemyColliders= new Collider[maxColliderCount];

            var enemyCountInRange =
                Physics.OverlapSphereNonAlloc(transform.position, _player.Config.EnemyDetectRange, _enemyColliders,
                    _enemyLayer);

            var distanceBetweenEnemy = _player.Config.EnemyDetectRange * _player.Config.EnemyDetectRange;
            Transform closestEnemy = null;
            for (int i = 0; i < enemyCountInRange; i++)
            {
                var currentEnemyTransform = _enemyColliders[i].transform;
                var tempDistanceBetweenEnemy = (transform.position - currentEnemyTransform.position).sqrMagnitude;
                if (tempDistanceBetweenEnemy > distanceBetweenEnemy) continue;
                distanceBetweenEnemy = tempDistanceBetweenEnemy;
                closestEnemy = currentEnemyTransform;
            }
            
            if(closestEnemy is null)
            {
                _currentDetectedEnemy = null;
                OnEnemyOutOfRange?.Invoke();
                return;
            }

            if (!closestEnemy.transform.TryGetComponent(out Enemy enemy)) return;
            if (enemy == _currentDetectedEnemy) return;
            
            _currentDetectedEnemy = enemy;
            OnEnemyDetected?.Invoke(enemy);
            
        }

        private void OnDrawGizmos()
        {
            if (!Application.isPlaying) return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _player.Config.EnemyDetectRange);
        }
    }
}