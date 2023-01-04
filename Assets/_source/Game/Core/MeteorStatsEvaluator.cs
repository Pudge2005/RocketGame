using UnityEngine;

namespace Game.Core
{
    public sealed class MeteorStatsEvaluator : ProviderComponent<MeteorStats>
    {
        [SerializeField] private GameManager _gm;
        [SerializeField] private CurvesOverDistanceProcessor _processor;

        [Space]
        [SerializeField] private AnimationCurve _meteorsSpeedOverDistance;
        [SerializeField] private AnimationCurve _meteorsDamageOverDistance;

        [SerializeField] private AnimationCurve _meteorsMinRadiusOverDistance;
        [SerializeField] private AnimationCurve _meteorsMaxRadiusOverDistance;

        [SerializeField] private AnimationCurve _meteorsHealthOverDistance;

        [SerializeField] private Vector2 _meteorsDirectionFrom = Vector2.down;
        [SerializeField] private Vector2 _meteorsDirectionTo = Vector2.down;

        private readonly MeteorStats _stats = new();


        private void Awake()
        {
            _stats.DirectionFrom = _meteorsDirectionFrom;
            _stats.DirectionTo = _meteorsDirectionTo;

            _gm.OnPassedDistanceChanged += HandleDistanceChanged;
        }

        private void HandleDistanceChanged(double dist)
        {
            _stats.Speed = _processor.Evaluate(_meteorsSpeedOverDistance);
            _stats.Damage = _processor.Evaluate(_meteorsDamageOverDistance);
            _stats.MinRadius = _processor.Evaluate(_meteorsMinRadiusOverDistance);
            _stats.MaxRadius = _processor.Evaluate(_meteorsMaxRadiusOverDistance);
            _stats.Health = _processor.Evaluate(_meteorsHealthOverDistance);
        }


        public override MeteorStats GetItem()
        {
            return _stats;
        }
    }
}