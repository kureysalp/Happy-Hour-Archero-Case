using System;
using ArcheroCase.Mangers;
using UnityEngine;

namespace ArcheroCase.Combat
{
    public class Projectile : Poolable
    {
        [SerializeField] private ProjectileConfig _config;
        
        protected Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Travel();
        }

        private void Travel()
        {
            var gravity = Physics.gravity;
            var forwardVelocity = _config.Speed * Time.deltaTime * transform.forward; 
            var finalVelocity = forwardVelocity + gravity;
            _rigidbody.velocity = finalVelocity;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.TryGetComponent(out IDamageable iDamageable))
            {
               ProjectileHit(iDamageable);
                ReturnToPool();
            }
        }

        protected virtual void ProjectileHit(IDamageable iDamageable)
        {
            iDamageable.TakeDamage(_config.Damage);
        }
    }
}