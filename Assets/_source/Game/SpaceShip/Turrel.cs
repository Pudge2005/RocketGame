using UnityEngine;

namespace Game.SpaceShip
{
    public sealed class Turrel : MonoBehaviour
    {
        [Tooltip("Shoots per minute")]
        [SerializeField] private float _shootRate = 50f;
        [SerializeField] private Vector2 _shootDirection = Vector2.down;

        [SerializeField] private ProjectilesPool _projectilesPool;
        [SerializeField] private Collider2D _ignoringCollider;

        private float _shootCD;


        public float ShootRate { get => _shootRate; set => _shootRate = value; }
        public Vector2 ShootDirection { get => _shootDirection; set => _shootDirection = value; }
        public ProjectilesPool ProjectilesPool { get => _projectilesPool; set => _projectilesPool = value; }


        private void Awake()
        {
            ResetShootCD();
        }


        private void Update()
        {
            TryShoot();
        }

        private void TryShoot()
        {
            if ((_shootCD -= Time.deltaTime) > 0)
                return;

            ResetShootCD();

            Shoot();
        }

        private void Shoot()
        {
            var projectile = _projectilesPool.Rent();
            projectile.transform.position = transform.position;
            projectile.Init(Vector2.up * 10, GameRules.CollidablesContactFilter2D, _ignoringCollider);
        }

        private void ResetShootCD()
        {
            _shootCD = 60f / _shootRate;
        }
    }
}
