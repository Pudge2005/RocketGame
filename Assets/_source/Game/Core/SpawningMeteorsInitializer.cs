using UnityEngine;

namespace Game.Core
{
   
    public sealed class SpawningMeteorsInitializer : SpawningEntitiesInitializer<Meteor>
    {
        [SerializeField] private CurvesOverDistanceProcessor _curvesOverDistanceProcessor;
        [SerializeField] private MeteorStatsEvaluator _meteorStatsEvaluator;


        protected override void InitializeSpawnedEntity(Meteor entity)
        {
            entity.InitMeteor(_meteorStatsEvaluator.GetItem());
        }
    }
}