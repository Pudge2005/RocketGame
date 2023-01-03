using UnityEngine;
using Utils;

namespace Game.Core
{
    public sealed class TimerSpawnerOverDistance : MonoBehaviour
    {
        [SerializeField] private EntitiesSpawnerBase _spawner;
        [SerializeField] private CurvesOverDistanceProcessor _overDistanceProcessor;

        [SerializeField] private bool _dontSpawnInSafeZone;
        [SerializeField] private GameManager _gm;

        [Header("Curves")]
        [SerializeField] private AnimationCurve _coolDownOverDistance;
        [SerializeField] private AnimationCurve _countOverDistance;


        private float _cd;
        private int _aliveEntites;


        private void Start()
        {
            ResetCD();
        }


        private void ResetCD()
        {
            _cd = _overDistanceProcessor.Evaluate(_coolDownOverDistance);
        }

        private void Update()
        {
            if ((_cd -= Time.deltaTime) > 0)
                return;

            ResetCD();

            if (_dontSpawnInSafeZone && _gm.InSafeZone)
                return;

            if (_aliveEntites >= _overDistanceProcessor.Evaluate(_coolDownOverDistance))
                return;

            ++_aliveEntites;

            var inst = _spawner.Spawn();

            if (!inst.TryGetComponent<DestroyCallbackComponent>(out var destroyCallbackComponent))
                destroyCallbackComponent = inst.AddComponent<DestroyCallbackComponent>();

            destroyCallbackComponent.OnObjectDestroyed += OnSpawnedEntityDestroyed;
        }

        private void OnSpawnedEntityDestroyed(DestroyCallbackComponent sender)
        {
            sender.OnObjectDestroyed -= OnSpawnedEntityDestroyed;
            --_aliveEntites;
        }
    }
}