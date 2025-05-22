using UnityEngine;

namespace ArcheroCase.Combat
{
    [CreateAssetMenu(fileName = "SO_Projectile_Config", menuName = "Scriptable Objects/Projectile Config")]
    public class ProjectileConfig : ScriptableObject
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _speed;
        [SerializeField] private LayerMask _hitLayer;

        public float Damage => _damage;
        public float Speed => _speed;
        public LayerMask HitLayer => _hitLayer;
    }
}