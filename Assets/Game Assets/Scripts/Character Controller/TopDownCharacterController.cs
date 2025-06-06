using ArcheroCase.Enums;
using ArcheroCase.Game;
using UnityEngine;
using UnityEngine.AI;

namespace ArcheroCase.Character_Controller
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    public class TopDownCharacterController : MonoBehaviour
    {
        private Joystick _joystick;
        private Rigidbody _rigidbody;

        [SerializeField] private bool _normalizeJoystickInput;
        [SerializeField] private bool _useAnimator;
        [SerializeField] private bool _useNavmeshForBoundaries;

        private NavMeshAgent _navMeshAgent;
    
        private float _navMeshBoundaryCheckDistance = .1f;
        
        private Player _player;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _player = GetComponent<Player>();
            
            if (!_useAnimator) return;

            var animatorController = gameObject.AddComponent<AnimatorController>();
            if (_normalizeJoystickInput)
                animatorController.SetNormalizedInput();
        }

        private void Start()
        {
            _joystick = Joystick.Instance;
        }

        private void FixedUpdate()
        {
            Rotation();
            Movement();
        }

        private void Movement()
        {
            var input = _normalizeJoystickInput ? _joystick.Direction.normalized.magnitude : _joystick.Direction.magnitude;
            if (input <= _player.Config.MovementThreshold) return;
            
            
            var movementVector = transform.position + _player.Config.ForwardSpeed * input * Time.deltaTime * transform.forward;
            if (_useNavmeshForBoundaries)
            {
                if (NavMesh.SamplePosition(movementVector, out var hit, _navMeshBoundaryCheckDistance, NavMesh.AllAreas))
                    _rigidbody.MovePosition(hit.position);
            }
            else
                _rigidbody.MovePosition(movementVector);
        }

        private void Rotation()
        {
            var input = _joystick.Direction;
            if (input.magnitude <= _player.Config.RotationThreshold) return;

            var dir = Quaternion.Euler(0, Mathf.Atan2(input.x, input.y) * 180 / Mathf.PI, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, dir, Time.deltaTime * _player.Config.RotateSpeed);
        }
    }
}