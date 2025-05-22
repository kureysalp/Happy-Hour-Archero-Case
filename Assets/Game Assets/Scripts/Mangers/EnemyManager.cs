using System;
using ArcheroCase.Combat;
using UnityEngine;

namespace ArcheroCase.Game_Assets.Scripts.Mangers
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private int _maxEnemyCountAtATime;
        
        
        private void Start()
        {
            Enemy.OnEnemyDeath += SpawnNewEnemy;
            
            SpawnInitialEnemies();
        }

        private void SpawnInitialEnemies()
        {
            for (int i = 0; i < _maxEnemyCountAtATime; i++)
            {
                SpawnNewEnemy();
            }
        }

        private void SpawnNewEnemy()
        {
            
        }

        private void OnDisable()
        {
            Enemy.OnEnemyDeath -= SpawnNewEnemy;
        }
    }
}