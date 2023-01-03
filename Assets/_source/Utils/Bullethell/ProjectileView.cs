using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(PoolableProjectile2D))]
    public class ProjectileView : MonoBehaviour
    {
        [SerializeField] private AudioClip _onHitSound;
        [SerializeField] private ParticleSystem _onHitParticles;
        [SerializeField] private TrailRenderer _trail;

        private PoolableProjectile2D _projectile;


        private void Awake()
        {
            _projectile = GetComponent<PoolableProjectile2D>();
            _projectile.OnHit += HandleHit;
            _projectile.OnInit += HandleInit;
        }

        private void HandleInit(PoolableProjectile2D projectile)
        {
            _trail.Clear();
        }

        private void HandleHit(PoolableProjectile2D arg1, Vector2 arg2)
        {

            if (_onHitSound != null)
            {
                Debug.LogError("on hit sound is not implemented yet");
                //var pool = CachingAccessors.Get<AudioSourcesPool>();
                //var audioSource = pool.GetForOneShot(_onHitSound);
                //audioSource.transform.position = transform.position;
            }

            if (_onHitParticles != null)
            {
                Debug.LogError("on hit sound is not implemented yet");
            }
        }
    }
}
