using System;
using UnityEngine;

namespace Game
{
    public abstract class Hittable : MonoBehaviour, IHittable
    {
        public abstract Type TargetType { get; }

        public abstract void HitObjectTarget(object target);

        public abstract void HitComponentTarget(Component cmp);
    }

    public abstract class Hittable<TTarget> : Hittable
        where TTarget : UnityEngine.Component
    {
        public sealed override System.Type TargetType => typeof(TTarget);


        public sealed override void HitObjectTarget(object target)
        {
            if (target is TTarget safeTarget)
                HitTarget(safeTarget);
        }

        public sealed override void HitComponentTarget(Component cmp)
        {
            if(cmp is TTarget safeTarget)
            {
                HitTarget(safeTarget);
            }
        }

        public void HitTarget(TTarget target)
        {
            HandleTargetHit(target);
        }


        protected abstract void HandleTargetHit(TTarget target);
    }
}
