using Game.Stats;
using UnityEngine;

namespace Game
{
    public class DamagingComponent : Hittable<HealthComponent>
    {
        [SerializeField] private float _dmg;


        public float Dmg { get => _dmg; set => _dmg = value; }


        protected override void HandleTargetHit(HealthComponent target)
        {
            target.DealDamage(_dmg);
        }
    }
}
