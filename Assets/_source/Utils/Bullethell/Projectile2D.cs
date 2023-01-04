using System;
using System.Collections.Generic;
using DevourDev.Unity.Helpers;
using UnityEngine;

namespace Game
{
    public sealed class Projectile2D : MonoBehaviour
    {
        private Action<ReadOnlyMemory<RaycastHit2D>> _hitsHandler;

        private Collider2D _collider;
        private Vector2 _velocity;

        private ContactFilter2D _filter;
        private bool _hitEachTargetOnes;
        private HashSet<Collider2D> _ignoringColliders;


        public event System.Action<Projectile2D, Vector3> OnHit;


        public void InitProjectile2D(Action<ReadOnlyMemory<RaycastHit2D>> hitsHandler,
            Collider2D collider, Vector2 velocity, ContactFilter2D filter,
            bool hitEachTargetOnes, params Collider2D[] ignoringColliders)
        {
            _hitsHandler = hitsHandler;
            _collider = collider;
            _velocity = velocity;
            _filter = filter;
            _hitEachTargetOnes = hitEachTargetOnes;

            bool flag0 = ignoringColliders != null && ignoringColliders.Length > 0;
            bool flag1 = hitEachTargetOnes;

            if (flag0 || flag1)
            {
                _ignoringColliders = UnityEngine.Pool.HashSetPool<Collider2D>.Get();
            }

            if (flag0)
            {
                foreach (var col in ignoringColliders)
                {
                    _ignoringColliders.Add(col);
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

            var hits = Physics2DHelpers.MemCast(_collider, _velocity, _filter, translation.magnitude);

            if (hits.Length > 0)
            {
                if (_ignoringColliders != null)
                    hits = Physics2DHelpers.Fetch(hits, _ignoringColliders);

                { //stack flushing
                    var span = hits.Span;

                    foreach (var h in span)
                    {
                        if (_hitEachTargetOnes)
                            _ignoringColliders.Add(h.collider);

                        OnHit?.Invoke(this, h.point);
                    }
                }

                _hitsHandler(hits);
            }

            transform.position += (Vector3)translation;
        }
    }
}
