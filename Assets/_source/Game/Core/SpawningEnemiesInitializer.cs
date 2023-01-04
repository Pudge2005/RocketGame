using DevourDev.Unity.Utils;
using Game.Stats;
using UnityEngine;

namespace Game.Core
{
    public sealed class SpawningEnemiesInitializer : SpawningEntitiesInitializer<Enemy>
    {
        [SerializeField] private CurvesOverDistanceProcessor _curvesOverDistanceProcessor;
        [SerializeField] private EnemyStatsEvaluator _enemyStatsEvaluator;
        [SerializeField] private ProjectilesPool _projectilesPool;

        [SerializeField] private Vector2 _shootDirFrom = new(-0.2f, -1);
        [SerializeField] private Vector2 _shootDirTo = new(0.2f, -1);


        protected override void InitializeSpawnedEntity(Enemy entity)
        {
            var stats = _enemyStatsEvaluator.GetItem();
            entity.InitEnemy(stats);
            var turrel = entity.Turrel;

            if(entity.TryGetComponent<HealthComponent>(out var health))
            {
                health.InitHealth(stats.Health);
            }

            if (turrel != null)
            {
                turrel.ProjectilesPool = _projectilesPool;
                turrel.ShootRate = stats.ShootingRate;
                turrel.BulletsSpeed = stats.BulletsSpeed;
                turrel.ShootDirection = Vector2.Lerp(_shootDirFrom, _shootDirTo, UnityEngine.Random.value);
            }

            if (!entity.TryGetComponent<InBoundsTranslator2D>(out var translator))
                translator = entity.gameObject.AddComponent<InBoundsTranslator2D>();

            translator.OnReachedDestination += (x) =>
            {
                var randomMover = x.gameObject.AddComponent<RandomMoverComponent>();
                randomMover.Bounder = RuntimeAccessors.MainSceneBounder;
                randomMover.SpeedRange = new Vector2(stats.BulletsSpeed / 10f, stats.BulletsSpeed / 2f);
                Destroy(x);
            };

            translator.InitInBoundsTranslator(RuntimeAccessors.MainSceneBounder, stats.BulletsSpeed);
        }
    }
}