using DevourDev.Pools;
using UnityEngine;

namespace Game
{
    public class ProjectilesPool : PoolableComponentsPool<PoolableProjectile2D>
    {
        [SerializeField] private PoolableProjectile2D _prefab;

        protected override PoolableProjectile2D CreateItem()
        {
            return Instantiate(_prefab);
        }

        protected override void DisposeItem(PoolableProjectile2D item)
        {
            if (item != null)
                Destroy(item.gameObject);
        }
    }
}
