using UnityEngine;

namespace Game.Core
{
    public abstract class EntitiesSpawner<T> : EntitiesSpawnerBase where T : UnityEngine.Component
    {
        [SerializeField] private T[] _prefabs;
        [SerializeField] private ProviderComponent<Vector3> _spawnPositionProvider;
        [SerializeField] private ProviderComponent<Quaternion> _spawnRotationProvider;


        public event System.Action<T> OnEntitySpawned;


        public sealed override GameObject Spawn()
        {
            T prefabToSpawn = _prefabs[UnityEngine.Random.Range(0, _prefabs.Length)];

            var inst = Instantiate(prefabToSpawn,
                _spawnPositionProvider.GetItem(),
                _spawnRotationProvider.GetItem());

            OnEntitySpawned?.Invoke(inst);
            return inst.gameObject;
        }
    }
}