using System;
using UnityEngine;

namespace Game.Stats
{
    public sealed class HealthComponent : MonoBehaviour, IStat
    {
        [SerializeField] private float _healthMax;
        [SerializeField] private ReceivingDamageProcessor[] _dmgProcessors;

        private Stat _internalStat;
        private bool _inited;

        public float StatValue => _internalStat.StatValue;


        public event System.Action<HealthComponent> OnDeath;

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


        public void InitHealth(float max)
        {
            _healthMax = max;
            Start();
        }


        private void Start()
        {
            if (_inited)
                return;

            _inited = true;
            _internalStat = new Stat(_healthMax, _healthMax);
            _internalStat.OnStatValueReachedMin += HandleHealthReachedMin;
        }


        private void HandleHealthReachedMin(IStat arg1, float arg2, float arg3)
        {
            Die();
        }

        public void DealDamage(float dmg)
        {
            foreach (var processor in _dmgProcessors)
            {
                dmg = processor.ProcessDmg(dmg);
            }

            ReceiveDamage(dmg);
        }

        public void Heal(float heal)
        {
            _internalStat.ChangeStatValue(heal);
        }


        public void Kill()
        {
            //...
            Die();
        }


        private void ReceiveDamage(float dmg)
        {
            _internalStat.ChangeStatValue(-dmg);
        }

        private void Die()
        {
            OnDeath?.Invoke(this);
        }

        void IStat.ChangeStatValue(float rawDelta)
        {
            _internalStat.ChangeStatValue(rawDelta);
        }

        void IStat.SetStatValue(float value)
        {
            _internalStat.SetStatValue(value);
        }
    }
}
