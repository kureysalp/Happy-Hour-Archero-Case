using UnityEngine;


namespace ArcheroCase.Character_Controller
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorController : MonoBehaviour
    {
        private Joystick _joystick;
        private Animator _animator;
        private bool _normalizeJoystickInput;

        private static readonly int InputHash = Animator.StringToHash("input");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _joystick = Joystick.Instance;
        }

        private void Update()
        {
            MovementAnimation();
        }

        private void MovementAnimation()
        {
            var input = _normalizeJoystickInput
                ? _joystick.Direction.normalized.magnitude
                : _joystick.Direction.magnitude;
            _animator.SetFloat(InputHash, input);
        }

        public void SetNormalizedInput()
        {
            _normalizeJoystickInput = true;
        }
    }
}