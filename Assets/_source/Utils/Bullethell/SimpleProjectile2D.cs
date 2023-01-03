using System.Collections.Generic;
using DevourDev.Unity.Helpers;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// TOREFACTOR: reimplement via <see cref="Projectile2D"/>
    /// </summary>
    public sealed class SimpleProjectile2D : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Vector2 _velocity;
        [SerializeField] private HittablesComposite _hittablesComposite;
        [SerializeField] private bool _hitEachTargetOnes = true;

        private ContactFilter2D _contactFilter;
        private HashSet<Collider2D> _ignoringColliders;


        public event System.Action<SimpleProjectile2D, Vector2> OnHit;


        private void OnDestroy()
        {
            if (_ignoringColliders != null)
                UnityEngine.Pool.HashSetPool<Collider2D>.Release(_ignoringColliders);
        }

        public void Init(Collider2D collider, Vector2 velocity,
            HittablesComposite hittablesComposite, bool hitEachTargetOnce,
            ContactFilter2D contactFilter, params Collider2D[] ignoringColliders)
        {
            _collider = collider;
            _velocity = velocity;
            _hittablesComposite = hittablesComposite;
            _hitEachTargetOnes = hitEachTargetOnce;
            _contactFilter = contactFilter;

            if (ignoringColliders != null && ignoringColliders.Length > 0)
            {
                _ignoringColliders = UnityEngine.Pool.HashSetPool<Collider2D>.Get();

                foreach (var icol in ignoringColliders)
                {
                    _ignoringColliders.Add(icol);
                }
            }
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector2 fromPoint = transform.position;
            Vector2 translation = _velocity * Time.deltaTime;

            var hits = Physics2DHelpers.MemCast(_collider, _velocity, _contactFilter, translation.magnitude);

            if (Physics2DHelpers.TryFindClosest(hits, out var closestHit, _ignoringColliders))
            {
                transform.position += (Vector3)translation;
                return;
            }

            if (_hittablesComposite != null)
            {
                _hittablesComposite.HitGameObjectTarget(closestHit.collider.gameObject);
            }

            if (_hitEachTargetOnes)
            {
                _ignoringColliders.Add(closestHit.collider);
            }

            OnHit?.Invoke(this, closestHit.point);
        }

    }
}
