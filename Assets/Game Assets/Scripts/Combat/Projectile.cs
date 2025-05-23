using System;
using ArcheroCase.Mangers;
using UnityEngine;

namespace ArcheroCase.Combat
{
    public class Projectile : Poolable
    {
        [SerializeField] private ProjectileConfig _config;
        
        protected Rigidbody _rigidbody;

        private bool _isTravelling;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (_isTravelling)
                Travel();
        }

        private void Travel()
        {
            var eulerRotation = _rigidbody.transform.eulerAngles;
            var newRotation =
                Quaternion.Euler(Quaternion.AngleAxis(Physics.gravity.y*Time.deltaTime, transform.right) *
                                 eulerRotation);
            _rigidbody.MoveRotation(newRotation);
        }

        private void OnCollisionEnter(Collision other)
        {
            _rigidbody.isKinematic = true;
            _isTravelling = false;
            
            if (other.transform.TryGetComponent(out IDamageable iDamageable))
            {
               ProjectileHit(iDamageable);
               ReturnToPool();
            }
        }

        public void SetVelocity(Vector3 velocity)
        {
            _isTravelling = true;
            _rigidbody.isKinematic = false;
            _rigidbody.velocity = velocity;
        }

        protected virtual void ProjectileHit(IDamageable iDamageable)
        {
            iDamageable.TakeDamage(_config.Damage);
        }
    }
}