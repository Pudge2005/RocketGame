using DevourDev.Pools;
using DevourDev.Unity.Helpers;
using UnityEngine;

namespace Game
{
    public class PoolableProjectile2D : PoolableComponent<PoolableProjectile2D>
    {
        [SerializeField] private float _radius = 1f;
        [SerializeField] private HittablesComposite _hittablesComposite;

        private Vector2 _velocity;
        private ContactFilter2D _contactFilter;
        private Collider2D _ignoringCollider;

        public event System.Action<PoolableProjectile2D, Vector2> OnHit;
        public event System.Action<PoolableProjectile2D> OnInit;



#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            UnityEditor.Handles.color = Color.cyan;
            UnityEditor.Handles.DrawWireDisc(transform.position, transform.forward, _radius, 5);
        }
#endif



        public void Init(Vector2 velocity, ContactFilter2D filter, Collider2D ignoringCollider = null)
        {
            _velocity = velocity;
            _contactFilter = filter;
            _ignoringCollider = ignoringCollider;
            OnInit?.Invoke(this);
        }


        private void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector2 fromPoint = transform.position;
            Vector2 translation = _velocity * Time.deltaTime;

            //var hit = Physics2D.CircleCast(fromPoint, _radius, _velocity, translation.magnitude,
            //    _contactFilter.layerMask);

            var hit = Physics2DHelpers.CircleCast(fromPoint, fromPoint + translation, _radius, _contactFilter, _ignoringCollider);

            if (!hit)
            {
                transform.position += (Vector3)translation;
                return;
            }

            if (_hittablesComposite != null)
            {
                _hittablesComposite.HitGameObjectTarget(hit.collider.gameObject);
            }

            OnHit?.Invoke(this, hit.point);
            ReturnToPool();
        }

        protected override void HandleRentingInternal()
        {
            gameObject.SetActive(true);
        }

        protected override void HandleReturnedInternal()
        {
            gameObject.SetActive(false);
        }
    }
}
