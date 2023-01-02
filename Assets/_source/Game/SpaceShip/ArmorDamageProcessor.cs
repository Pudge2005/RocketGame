using UnityEngine;

namespace Game
{
    public sealed class ArmorDamageProcessor : ReceivingDamageProcessor
    {
        [SerializeField, Range(0, 1f)] private float _dmgResist = 0.4f;


        public override float ProcessDmg(float dmg)
        {
            dmg -= dmg * _dmgResist;
            return dmg;
        }

    }
}
