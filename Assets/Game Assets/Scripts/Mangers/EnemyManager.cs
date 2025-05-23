using ArcheroCase.Combat;
using ArcheroCase.Mangers;
using UnityEngine;

namespace ArcheroCase.Game_Assets.Scripts.Mangers
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private int _maxEnemyCountAtATime;
        [SerializeField] private float _enemyOverlapRadius;
        [SerializeField] private BoxCollider _enemySpawnBounds;

        [SerializeField] private LayerMask _enemyLayer;
        
        
        private void Start()
        {
            Enemy.OnEnemyDeath += HandleEnemyDeath;
            
            SpawnInitialEnemies();
        }

        private void SpawnInitialEnemies()
        {
            for (int i = 0; i < _maxEnemyCountAtATime; i++)
            {
                SpawnNewEnemy();
            }
        }

        private void HandleEnemyDeath(Enemy deathEnemy)
        {
            deathEnemy.ReturnToPool();
            SpawnNewEnemy();
        }

        private void SpawnNewEnemy()
        {
            var enemyToSpawn = Poolable.Get<Enemy>();
            enemyToSpawn.SetEnemy();

            Vector3 enemySpawnPosition;

            do
            {
                enemySpawnPosition = RandomPositionInBounds();
            } while (CheckEnemyOverlap(enemySpawnPosition));

            enemyToSpawn.transform.position = enemySpawnPosition;
        }

        private Vector3 RandomPositionInBounds()
        {
            return new Vector3(
                Random.Range(_enemySpawnBounds.bounds.min.x, _enemySpawnBounds.bounds.max.x),
                0,
                Random.Range(_enemySpawnBounds.bounds.min.z, _enemySpawnBounds.bounds.max.z)
            );
        }

        private bool CheckEnemyOverlap(Vector3 position)
        {
            return Physics.CheckSphere(position, _enemyOverlapRadius, _enemyLayer);
        }

        private void OnDisable()
        {
            Enemy.OnEnemyDeath -= HandleEnemyDeath;
        }
    }
}