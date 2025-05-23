using ArcheroCase.Enums;
using UnityEngine;

namespace ArcheroCase.Game
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _config;
        public PlayerConfig Config => _config;

        
       [SerializeField] private CharacterState _characterState;
        public CharacterState CharacterState => _characterState;
        

        public bool IsPlayerMoving { get; private set; }
        
        public Joystick Joystick { get; private set; }


        private void Start()
        {
            Joystick = Joystick.Instance;  
        }

        private void Update()
        {
            IsPlayerMoving = Joystick.Direction.magnitude > 0;
        }
    }
}