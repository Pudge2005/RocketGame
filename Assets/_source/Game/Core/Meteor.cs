using System;
using Game.Stats;
using UnityEngine;

namespace Game.Core
{
    [RequireComponent(typeof(Projectile2D), typeof(CircleCollider2D))]
    public sealed class Meteor : Hittable<HealthComponent>
    {
        [SerializeField] private HealthComponent _health;


        public MeteorStats Stats { get; private set; }


        public void InitMeteor(MeteorStats stats)
        {
            Stats = stats;
            transform.localScale = Vector3.one * UnityEngine.Random.Range(stats.MinRadius, stats.MaxRadius);

            var projectile = GetComponent<Projectile2D>();
            CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
            Vector2 velocity = Vector2.Lerp(stats.DirectionFrom, stats.DirectionTo, UnityEngine.Random.value);
            velocity = velocity.normalized * stats.Speed;

            if(_health != null)
            {
                _health.InitHealth(stats.Health);
            }


            projectile.InitProjectile2D(HandleHits, circleCollider, velocity,
                GameRules.CollidablesContactFilter2D, true, circleCollider);


        }

        private void HandleHits(ReadOnlyMemory<RaycastHit2D> hits)
        {
            var span = hits.Span;

            foreach (var h in span)
            {
                if (h.collider.TryGetComponent<HealthComponent>(out var health))
                    health.DealDamage(Stats.Damage);
            }
        }

        protected override void HandleTargetHit(HealthComponent target)
        {
            target.DealDamage(Stats.Damage);
        }
    }
}