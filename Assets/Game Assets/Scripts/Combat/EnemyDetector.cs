using System;
using ArcheroCase.Character_Controller;
using ArcheroCase.Enums;
using ArcheroCase.Game;
using ArcheroCase.Utility;
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

            var closestEnemy = Utilities.GetClosestEnemy(transform.position, _player.Config.EnemyDetectRange, _enemyLayer);

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