using UnityEngine;

namespace Game.Core
{
    public abstract class SpawningEntitiesInitializer<T> : MonoBehaviour
        where T : UnityEngine.Component
    {
        [SerializeField] private EntitiesSpawner<T> _spawner;

        protected virtual void Awake()
        {
            _spawner.OnEntitySpawned += InitializeSpawnedEntity;
        }


        protected abstract void InitializeSpawnedEntity(T entity);
    }
}