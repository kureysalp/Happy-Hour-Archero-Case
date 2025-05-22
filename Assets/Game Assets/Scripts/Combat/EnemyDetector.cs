using System;
using ArcheroCase.Character_Controller;
using ArcheroCase.Enums;
using ArcheroCase.Game;
using UnityEngine;

namespace ArcheroCase.Combat
{
    public class EnemyDetector : MonoBehaviour
    {
        private Player _player;
        private Collider[] _enemyColliders;

        public static event Action<Enemy> OnEnemyDetected;
        
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
            if (_player.CharacterState != CharacterState.LookingForEnemy) return;

            var maxColliderCount = 5;
            
            _enemyColliders= new Collider[maxColliderCount];

            var enemyCountInRange =
                Physics.OverlapSphereNonAlloc(transform.position, _player.Config.EnemyDetectRange, _enemyColliders);

            var distanceBetweenEnemy = _player.Config.EnemyDetectRange;
            Transform closestEnemy = null;
            for (int i = 0; i < enemyCountInRange; i++)
            {
                var currentEnemyTransform = _enemyColliders[i].transform;
                var tempDistanceBetweenEnemy = (transform.position - currentEnemyTransform.position).sqrMagnitude;
                if (tempDistanceBetweenEnemy > distanceBetweenEnemy) continue;
                distanceBetweenEnemy = tempDistanceBetweenEnemy;
                closestEnemy = currentEnemyTransform;
            }
            
            if(closestEnemy is null) return;
            
            if(transform.TryGetComponent(out Enemy enemy))
                OnEnemyDetected?.Invoke(enemy);
        }
    }
}