using Game.Stats;
using UnityEngine;

namespace Game
{
    public class DamagingComponent : Hittable<HealthComponent>
    {
        [SerializeField] private float _dmg;


        protected override void HandleTargetHit(HealthComponent target)
        {
            target.DealDamage(_dmg);
        }
    }
}
