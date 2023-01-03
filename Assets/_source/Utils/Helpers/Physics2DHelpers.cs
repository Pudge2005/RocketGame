using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevourDev.Unity.Helpers
{
    public static class CastComponents2DHelpers<TComp> where TComp : UnityEngine.Component
    {
        private static readonly TComp[] _compsBuffer = new TComp[1024];
        private static readonly ReadOnlyMemory<TComp> _compsMem = new(_compsBuffer);


        public static ReadOnlyMemory<TComp> MemRayCast(Vector2 origin, Vector2 direction, float distance)
        {
            return MemRayCast(origin, direction, Physics2DHelpers.AllDetectingFilter, distance);
        }

        public static ReadOnlyMemory<TComp> MemRayCast(Vector2 origin, Vector2 direction, ContactFilter2D contactFilter, float distance)
        {
            var mem = Physics2DHelpers.MemRayCast(origin, direction, contactFilter, distance);
            var span = mem.Span;

            var buffer = _compsBuffer;
            int compsCount = -1;
            int c = span.Length;

            for (int i = 0; i < c; i++)
            {
                if (span[i].collider.TryGetComponent<TComp>(out var desiredComp))
                {
                    buffer[++compsCount] = desiredComp;
                }
            }

            ++compsCount;

            if (compsCount > 0)
            {
                return _compsMem[..compsCount];
            }

            return ReadOnlyMemory<TComp>.Empty;
        }
    }

    public static class Physics2DHelpers
    {
        public static readonly ContactFilter2D AllDetectingFilter = new()
        {
            useDepth = false,
            useLayerMask = false,
            useNormalAngle = false,
            useOutsideDepth = false,
            useOutsideNormalAngle = false,
            useTriggers = true,
        };


        public const float MinRadius = 0.05f;

        private static readonly RaycastHit2D[] _hitsBuffer = new RaycastHit2D[1024];
        private static readonly ReadOnlyMemory<RaycastHit2D> _hitsMem = new(_hitsBuffer);


        public static RaycastHit2D CircleCast(Vector2 fromPoint, Vector2 toPoint, float radius, Collider2D exceptingCollider)
        {
            if (radius < MinRadius)
                return RayCast(fromPoint, toPoint, exceptingCollider);

            var mem = MemCircleCast(fromPoint, toPoint, radius, AllDetectingFilter);

            if (TryFindClosest(mem, out var closest, exceptingCollider))
            {
                return closest;
            }

            return default;
        }

        public static RaycastHit2D CircleCast(Vector2 fromPoint, Vector2 toPoint, float radius, ContactFilter2D filter, Collider2D exceptingCollider)
        {
            if (radius < MinRadius)
                return RayCast(fromPoint, toPoint, filter, exceptingCollider);

            var mem = MemCircleCast(fromPoint, toPoint, radius, filter);

            if (TryFindClosest(mem, out var closest, exceptingCollider))
            {
                return closest;
            }

            return default;
        }

        public static ReadOnlyMemory<RaycastHit2D> MemCircleCast(Vector2 fromPoint, Vector2 toPoint, float radius, ContactFilter2D filter)
        {
            Vector2 vec = toPoint - fromPoint;
            float distance = vec.magnitude;
            int count = Physics2D.defaultPhysicsScene.CircleCast(fromPoint, radius, vec, distance, filter, _hitsBuffer);

            if (count == 0)
                return ReadOnlyMemory<RaycastHit2D>.Empty;

            return _hitsMem[..count];
        }

        public static RaycastHit2D RayCast(Vector2 fromPoint, Vector2 toPoint, Collider2D exceptingCollider)
        {
            Vector2 vec = toPoint - fromPoint;
            float distance = vec.magnitude;
            var hits = MemRayCast(fromPoint, vec, distance);

            if (TryFindClosest(hits, out var closest, exceptingCollider))
            {
                return closest;
            }

            return default;
        }

        public static RaycastHit2D RayCast(Vector2 fromPoint, Vector2 toPoint, ContactFilter2D filter, Collider2D exceptingCollider)
        {
            Vector2 vec = toPoint - fromPoint;
            float distance = vec.magnitude;
            var hits = MemRayCast(fromPoint, vec, filter, distance);

            if (exceptingCollider != null)
            {
                if (TryFindClosest(hits, out var closest, exceptingCollider))
                    return closest;
            }
            else
            {
                if (TryFindClosest(hits, out var closest))
                    return closest;
            }

            return default;
        }

        public static ReadOnlyMemory<RaycastHit2D> MemRayCast(Vector2 origin, Vector2 direction, float distance)
        {
            return MemRayCast(origin, direction, AllDetectingFilter, distance);
        }

        public static ReadOnlyMemory<RaycastHit2D> MemRayCast(Vector2 origin, Vector2 direction, ContactFilter2D contactFilter, float distance)
        {
            var count = Physics2D.Raycast(origin, direction, contactFilter, _hitsBuffer, distance);

            if (count == 0)
                return ReadOnlyMemory<RaycastHit2D>.Empty;

            return _hitsMem[..count];
        }


        public static ReadOnlyMemory<RaycastHit2D> MemCast(this Collider2D collider, Vector2 direction, float distance)
        {
            int count = collider.Cast(direction, _hitsBuffer, distance, false);

            if (count == 0)
                return ReadOnlyMemory<RaycastHit2D>.Empty;

            return _hitsMem[..count];
        }

        public static ReadOnlyMemory<RaycastHit2D> MemCast(this Collider2D collider, Vector2 direction, ContactFilter2D filter, float distance)
        {
            switch (collider)
            {
                case CircleCollider2D circleCollider2D:
                    Vector2 fromPoint = circleCollider2D.bounds.center;
                    return MemCircleCast(fromPoint, fromPoint + direction * distance, circleCollider2D.radius, filter);
                default:
                    break;
            }

            int count = collider.Cast(direction, filter, _hitsBuffer, distance, false);

            if (count == 0)
                return ReadOnlyMemory<RaycastHit2D>.Empty;

            return _hitsMem[..count];
        }


        public static RaycastHit2D MemCastClosest(this Collider2D collider, Vector2 direction, ContactFilter2D filter, float maxDistance)
        {
            if (TryFindClosest(MemCast(collider, direction, filter, maxDistance), out var closest))
                return closest;

            return default;
        }

        public static ReadOnlyMemory<RaycastHit2D> Fetch(ReadOnlyMemory<RaycastHit2D> allHits, ICollection<Collider2D> exceptingColliders)
        {
            var span = allHits.Span;
            var length = span.Length;
            var fetchedBuffer = _hitsBuffer.AsMemory(length).Span;
            int i = -1;

            for (int j = 0; j < length; j++)
            {
                var hit = span[j];

                if (exceptingColliders.Contains(hit.collider))
                    continue;

                fetchedBuffer[++i] = hit; //??????????? MB WONT WORK xdd
            }

            return _hitsMem.Slice(length, i + 1);
        }


        public static bool TryFindClosest(ReadOnlyMemory<RaycastHit2D> hits, out RaycastHit2D closest)
        {
            closest = default;
            var count = hits.Length;

            if (count == 0)
                return false;

            float closestDist = float.PositiveInfinity;
            var span = hits.Span;

            for (int i = 0; i < count; i++)
            {
                var hit = span[i];
                var dist = hit.distance;

                if (dist < closestDist)
                {
                    closestDist = dist;
                    closest = hit;
                }
            }

            return closest;
        }

        public static bool TryFindClosest(ReadOnlyMemory<RaycastHit2D> hits, out RaycastHit2D closest, Collider2D exceptingCollider)
        {
            if (exceptingCollider == null)
                return TryFindClosest(hits, out closest);

            closest = default;
            var count = hits.Length;

            if (count == 0)
                return false;

            float closestDist = float.PositiveInfinity;
            var span = hits.Span;

            for (int i = 0; i < count; i++)
            {
                var hit = span[i];

                if (hit.collider == exceptingCollider)
                    continue;

                var dist = hit.distance;

                if (dist < closestDist)
                {
                    closestDist = dist;
                    closest = hit;
                }
            }

            return closest;
        }

        public static bool TryFindClosest(ReadOnlyMemory<RaycastHit2D> hits, out RaycastHit2D closest, ICollection<Collider2D> exceptingColliders)
        {
            if (exceptingColliders == null || exceptingColliders.Count == 0)
                return TryFindClosest(hits, out closest);

            closest = default;
            var count = hits.Length;

            if (count == 0)
                return false;

            float closestDist = float.PositiveInfinity;
            var span = hits.Span;

            for (int i = 0; i < count; i++)
            {
                var hit = span[i];

                if (exceptingColliders.Contains(hit.collider))
                    continue;

                var dist = hit.distance;

                if (dist < closestDist)
                {
                    closestDist = dist;
                    closest = hit;
                }
            }

            return closest;
        }
    }
}
