using UnityEngine;

namespace Game.Core
{
    public sealed class EnemyStatsEvaluator : ProviderComponent<EnemyStats>
    {
        [SerializeField] private GameManager _gm;
        [SerializeField] private CurvesOverDistanceProcessor _processor;

        [Space]
        [SerializeField] private AnimationCurve _emeniesHealthOverDistance;
        [SerializeField] private AnimationCurve _enemiesShootingRateOverDistance;
        [SerializeField] private AnimationCurve _enemiesBulletsSpeedOverDistance;
        [SerializeField] private AnimationCurve _enemiesShootingDamageOverDistance;

        private readonly EnemyStats _stats = new();


        private void Awake()
        {
            _gm.OnPassedDistanceChanged += HandleDistanceChanged;
        }

        private void HandleDistanceChanged(double dist)
        {
            _stats.Health = _processor.Evaluate(_emeniesHealthOverDistance);
            _stats.ShootingRate = _processor.Evaluate(_enemiesShootingRateOverDistance);
            _stats.BulletsSpeed = _processor.Evaluate(_enemiesBulletsSpeedOverDistance);
            _stats.BulletsDamage = _processor.Evaluate(_enemiesShootingDamageOverDistance);
        }


        public override EnemyStats GetItem()
        {
            return _stats;
        }
    }
}