using UnityEngine;

namespace Game.Stats
{
    [RequireComponent(typeof(HealthComponent))]
    public sealed class DestroyOnDeathComponent: MonoBehaviour
    {
        private void Awake()
        {
            var health = GetComponent<HealthComponent>();
            health.OnDeath += (x) => Destroy(gameObject);
        }
    }
}
