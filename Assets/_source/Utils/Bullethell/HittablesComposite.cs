using System;
using DevourDev.Unity.Utils;
using UnityEngine;

namespace Game
{
    public sealed class HittablesComposite : MonoBehaviour, IHittable
    {
        [SerializeField] private Hittable[] _hittables;

        public Type TargetType => typeof(object);


        public void HitObjectTarget(object target)
        {
            var t = target.GetType();
            foreach (var h in _hittables)
            {
                if (h.TargetType.Equals(t))
                {
                    h.HitObjectTarget(target);

                    if (target == null)
                        return;
                }
            }  
        }

        public void HitGameObjectTarget(GameObject target)
        {
            var comps = target.GetComponentsNonAlloc(typeof(Component)).Span;

            foreach (var h in _hittables)
            {
                foreach (var cmp in comps)
                {
                    h.HitComponentTarget(cmp);
                }
            }
        }
    }
}
