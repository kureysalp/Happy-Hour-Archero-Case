using UnityEngine;

namespace ArcheroCase.Combat
{
    [CreateAssetMenu(fileName = "SO_Enemy_Config", menuName = "Scriptable Objects/Enemy Config")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private float _maximumHealth;

        public float MaximumHealth => _maximumHealth;
    }
}