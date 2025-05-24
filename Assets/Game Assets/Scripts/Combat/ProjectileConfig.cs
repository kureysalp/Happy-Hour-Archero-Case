using System.Collections.Generic;
using ArcheroCase.Auras;
using UnityEngine;
using UnityEngine.Serialization;

namespace ArcheroCase.Combat
{
    [CreateAssetMenu(fileName = "SO_Projectile_Config", menuName = "Scriptable Objects/Projectile Config")]
    public class ProjectileConfig : ScriptableObject
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _speed;
        [SerializeField] private LayerMask _hitLayer;
        [SerializeField] private int _baseBounceCount;
        [SerializeField] private float _bounceRadius;

        private int _bounceCountModifier = 0;

        public float Damage => _damage;
        public float Speed => _speed;
        public LayerMask HitLayer => _hitLayer;
        public int BounceCount => _baseBounceCount +  _bounceCountModifier;
        public float BounceRadius => _bounceRadius;

        public List<Aura> ActiveAuras { get; } = new();

        public void AddBounceCountModifier(int modifier)
        {
            _bounceCountModifier += modifier;
        }
        
        public void RemoveBounceCountModifier(int modifier)
        {
            _bounceCountModifier -= modifier;
        }

        public void AddAura(Aura aura)
        {
            ActiveAuras.Add(aura);
        }

        public void RemoveAura(Aura aura)
        {
            ActiveAuras.Remove(aura);
        }

    }
}