using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(SimpleProjectile2D))]
    public sealed class SimpleProjectile2DOnHitDestroyer : MonoBehaviour
    {

        private void Awake()
        {
            var sp = GetComponent<SimpleProjectile2D>();
            sp.OnHit += (x, y) => Destroy(gameObject);
        }
    }
}
