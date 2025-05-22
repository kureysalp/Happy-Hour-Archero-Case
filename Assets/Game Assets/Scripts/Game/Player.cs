using ArcheroCase.Enums;
using UnityEngine;

namespace ArcheroCase.Game
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _config;
        public PlayerConfig Config => _config;

        
        private CharacterState _characterState;
        public CharacterState CharacterState => _characterState;


        public void ChangeState(CharacterState newState)
        {
            _characterState = newState;
        }


    }
}