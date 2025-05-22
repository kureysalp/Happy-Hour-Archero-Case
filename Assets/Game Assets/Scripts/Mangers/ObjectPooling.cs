using ArcheroCase.Combat;
using ArcheroCase.Mangers;
using UnityEngine;

namespace ArcheroCase.Game_Assets.Scripts.Mangers
{
    public class ObjectPooling : MonoBehaviour
    {
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private int _projectilePoolSize;
        [SerializeField] private int _projectilePoolExpandSize;
        
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private int _enemyPoolSize;
        [SerializeField] private int _enemyPoolExpandSize;

        private void Awake()
        {
            Poolable.CreatePool<Projectile>(_projectilePrefab, _projectilePoolSize, _projectilePoolExpandSize);
            Poolable.CreatePool<Enemy>(_enemyPrefab, _enemyPoolSize, _enemyPoolExpandSize);
        }    
    }
}