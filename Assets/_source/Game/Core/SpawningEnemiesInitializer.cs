using System;
using UnityEngine;

namespace Game.Core
{
    public sealed class SpawningEnemiesInitializer : SpawningEntitiesInitializer<Enemy>
    {
        [SerializeField] private CurvesOverDistanceProcessor _curvesOverDistanceProcessor;
        [SerializeField] private EnemyStatsEvaluator _enemyStatsEvaluator;



        protected override void InitializeSpawnedEntity(Enemy entity)
        {
            entity.InitEnemy(_enemyStatsEvaluator.GetItem());
        }
    }
}