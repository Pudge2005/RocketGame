using UnityEngine;

namespace Game.Core
{
    public abstract class EntitiesSpawner<T> : EntitiesSpawnerBase where T : UnityEngine.Component
    {
        [SerializeField] private T[] _prefabs;


        public event System.Action<T> OnEntitySpawned;


        public sealed override GameObject Spawn()
        {
            T prefabToSpawn = _prefabs[UnityEngine.Random.Range(0, _prefabs.Length)];
            var inst = Instantiate(prefabToSpawn);
            OnEntitySpawned?.Invoke(inst);
            return inst.gameObject;
        }
    }
}