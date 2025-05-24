using ArcheroCase.Combat;
using UnityEngine;

namespace ArcheroCase.Game
{
    [CreateAssetMenu(fileName = "SO_Player_Config", menuName = "Scriptable Objects/Player Config")]
    public class PlayerConfig : ScriptableObject
    {
        [Header("Movement")]
        [SerializeField] private float _forwardSpeed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _movementThreshold;
        [SerializeField] private float _rotationThreshold;
        [Header("Combat")]
        [SerializeField] private float _enemyDetectRange;
        [SerializeField] private float _baseFireRate;
        [SerializeField] private int _baseMultishotCount;
        [SerializeField] private float _timeBetweenMultishots;
        
        [SerializeField] private ProjectileConfig  _projectileConfig;
        
        private float _fireRateMultiplier = 1.0f;
        private int _multishotCountModifier = 0;

        public float ForwardSpeed => _forwardSpeed;
        public float RotateSpeed => _rotateSpeed;

        public float MovementThreshold => _movementThreshold;
        public float RotationThreshold => _rotationThreshold;

        public float EnemyDetectRange => _enemyDetectRange;

        public float FireRate => _baseFireRate * _fireRateMultiplier;

        public int MultishotCount => _baseMultishotCount + _multishotCountModifier;


        public float TimeBetweenMultishots => _timeBetweenMultishots;

        public ProjectileConfig ProjectileConfig => _projectileConfig;

        public void SetFireRateMultiplier(int multiplier)
        {
            _fireRateMultiplier = multiplier;
        }

        public void SetMultishotCountModifier(int modifier)
        {
            _multishotCountModifier = modifier;
        }

        
    }
}