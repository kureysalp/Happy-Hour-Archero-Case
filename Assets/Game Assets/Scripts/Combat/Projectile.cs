using ArcheroCase.Auras;
using ArcheroCase.Mangers;
using ArcheroCase.Utility;
using UnityEngine;

namespace ArcheroCase.Combat
{
    public class Projectile : Poolable
    {
        [SerializeField] private ProjectileConfig _config;
        
        private Rigidbody _rigidbody;

        private bool _isTravelling;
        
        private int _bounceCountLeft;

        private Transform _lastHitEnemyTransform;

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
            if(other.transform == _lastHitEnemyTransform) return;
            
            if (other.transform.TryGetComponent(out IDamageable iDamageable))
            { 
                _lastHitEnemyTransform = other.transform;
                ProjectileHit(iDamageable);
            }
            else ReturnToPool();
        }

        public void ShootBullet(Vector3 velocity)
        {
            _isTravelling = true;
            _rigidbody.isKinematic = false;
            _rigidbody.velocity = velocity;

            _bounceCountLeft = _config.BounceCount;
        }

        private void ProjectileHit(IDamageable iDamageable)
        {
            iDamageable.TakeDamage(_config.Damage);
            foreach (var aura in _config.ActiveAuras)
            {
                var newBurnAura = new BurnAura(aura as BurnAura);
                iDamageable.ApplyAura(newBurnAura);
            }

            if (_bounceCountLeft > 0)
                BounceToEnemy();
            else
                ReturnToPool();
            
        }


        private void BounceToEnemy()
        {
            _isTravelling = false;
            
            _bounceCountLeft--;
            var enemyInBounceRange =
                Utilities.GetClosestEnemy(transform.position, _config.BounceRadius, _config.HitLayer, _lastHitEnemyTransform);
            
            if(enemyInBounceRange is null)
            {
                ReturnToPool();
                return;
            }

            var lookAtPosition = enemyInBounceRange.position;
            lookAtPosition.y = 0;
            transform.LookAt(lookAtPosition);
            
            _rigidbody.velocity = _config.Speed * transform.forward;
        }

        protected override void Reset()
        {
            base.Reset();
            _rigidbody.isKinematic = true;
            _isTravelling = false;
            _lastHitEnemyTransform = null;
        }
    }
}