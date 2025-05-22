using UnityEngine;

namespace ArcheroCase.Game
{
    [CreateAssetMenu(fileName = "SO_Player_Config", menuName = "Scriptable Objects/Player Config")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private float _forwardSpeed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _movementThreshold;
        [SerializeField] private float _rotationThreshold;
        [SerializeField] private float _enemyDetectRange;
        [SerializeField] private float _baseFireRate;

        public float ForwardSpeed => _forwardSpeed;
        public float RotateSpeed => _rotateSpeed;

        public float MovementThreshold => _movementThreshold;
        public float RotationThreshold => _rotationThreshold;

        public float EnemyDetectRange => _enemyDetectRange;

        public float BaseFireRate => _baseFireRate;
    }
}