using UnityEngine;
using UnityEngine.Serialization;


namespace ArcheroCase.Character_Controller
{
    [CreateAssetMenu(fileName = "SO_Character_Controller_Config", menuName = "Scriptable Objects/Character Controller Config")]
    public class ControllerConfig : ScriptableObject
    {
        [SerializeField] private float _forwardSpeed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _movementThreshold;
        [SerializeField] private float _rotationThreshold;

        public float ForwardSpeed => _forwardSpeed;
        public float RotateSpeed => _rotateSpeed;

        public float MovementThreshold => _movementThreshold;
        public float RotationThreshold => _rotationThreshold;
    }
}