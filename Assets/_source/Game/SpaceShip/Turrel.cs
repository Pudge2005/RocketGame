using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.SpaceShip
{
    public sealed class Turrel : MonoBehaviour
    {
        [Tooltip("Shoots per minute")]
        [SerializeField] private float _shootRate = 50f;

        [SerializeField] private ProjectilesPool _projectilesPool;
        [SerializeField] private Collider2D _ignoringCollider;

        private float _shootCD;


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

            ContactFilter2D filter = new()
            {
                layerMask = GameRules.CollidablesLayerMask,
                useLayerMask = true,
                useTriggers = false,
            };

            projectile.transform.position = transform.position;
            projectile.Init(Vector2.up * 10, filter, _ignoringCollider);
        }

        private void ResetShootCD()
        {
            _shootCD = 60f / _shootRate;
        }
    }
}
