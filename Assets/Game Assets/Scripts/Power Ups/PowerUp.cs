using ArcheroCase.Game;
using UnityEngine;

namespace ArcheroCase.PowerUps
{
    public abstract class PowerUp : ScriptableObject
    {
        [SerializeField] private string _name;
        public string Name => _name;
        
        public abstract void Activate(Player player);
        
        public abstract void Deactivate(Player player);
        
        public virtual void EnableRage(Player player) {}
        public virtual void DisableRage(Player player) {}
        
    }
}