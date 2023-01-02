using UnityEngine;

namespace Game.Stats
{
    public sealed class StatRegeneration : MonoBehaviour
    {
        [SerializeField] private Component _statComponent;
        [SerializeField] private float _regenPerSecond;
        [SerializeField] private float _ticksPerSecond;

        private IStat _stat;
        private float _cd;


        private void Awake()
        {
            _stat = (IStat)_statComponent;
            ResetCD();
        }


        private void Update()
        {
            if ((_cd -= Time.deltaTime) > 0)
                return;

            ResetCD();
            Regenerate();
        }

        private void ResetCD()
        {
            _cd = 1f / _ticksPerSecond;
        }

        private void Regenerate()
        {
            _stat.ChangeStatValue(_regenPerSecond / _ticksPerSecond);
        }
    }
}
