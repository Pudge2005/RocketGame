using System;
using Game.Stats;
using UnityEngine;

namespace Game
{
    public sealed class ShieldDamageProcessor : ReceivingDamageProcessor, IStat
    {
        [SerializeField, Range(0, 1f)] private float _blockingDmgRatio = 0.7f;
        [SerializeField, Min(0f)] private float _dmgMultiplier = 0.8f;
        [SerializeField, Min(0f)] private float _durabilityMax = 100f;


        private Stat _internalStat;

        public float StatValue => _internalStat.StatValue;


        public event Action<IStat, float, float> OnStatValueChanged
        {
            add
            {
                _internalStat.OnStatValueChanged += value;
            }

            remove
            {
                _internalStat.OnStatValueChanged -= value;
            }
        }

        public event Action<IStat, float, float> OnStatValueReachedMin
        {
            add
            {
                _internalStat.OnStatValueReachedMin += value;
            }

            remove
            {
                _internalStat.OnStatValueReachedMin -= value;
            }
        }


        private void Awake()
        {
            _internalStat = new Stat(_durabilityMax, _durabilityMax);
        }


        public override float ProcessDmg(float dmg)
        {
            float shipDmg = dmg;
            float shieldDmg = dmg * _blockingDmgRatio;
            shieldDmg *= _dmgMultiplier;

            float duraLeft = _internalStat.StatValue - shieldDmg;

            if (duraLeft < 0)
            {
                shipDmg += -duraLeft / _dmgMultiplier / _blockingDmgRatio;
                duraLeft = 0;
            }

            shipDmg -= shieldDmg;
            _internalStat.SetStatValue(duraLeft);
            return shipDmg;
        }

        void IStat.ChangeStatValue(float rawDelta)
        {
            _internalStat.ChangeStatValue(rawDelta);
        }
    }
}
