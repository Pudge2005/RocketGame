using UnityEngine;
using Utils;

namespace Game.Core
{
    public sealed class InBoundsTranslator2D : EntityPositionTranslator
    {
        private SceneBounder _bounder;
        private float _speed;
        private Vector2 _speedVector;
        private Vector2 _destination;
        private Vector2? _box;


        public event System.Action<InBoundsTranslator2D> OnReachedDestination;


        public void InitInBoundsTranslator(SceneBounder bounder, float speed)
        {
            var min = bounder.Min;
            var max = bounder.Max;

            float x = UnityEngine.Random.Range(min.x, max.x);
            float y = UnityEngine.Random.Range(min.y, max.y);

            InitInBoundsTranslator(bounder, speed, new Vector2(x, y));
        }

        public void InitInBoundsTranslator(SceneBounder bounder, float speed, Vector2 destination)
        {
            _bounder = bounder; 
            _destination = destination;
            _speed = speed;

            if (TryGetComponent<Collider2D>(out var col))
                _box = col.bounds.extents;
            else
                _box = null;

            RecalculateSpeedVector();
        }

        protected override Vector3 Translate(Vector3 currentPosition)
        {
            EnsureDestinationInBounds();
            float deltaTime = Time.deltaTime;
            Vector3 pos;

            if (_speed * _speed * deltaTime >= ((Vector2)currentPosition - _destination).sqrMagnitude)
            {
                OnReachedDestination?.Invoke(this);
                pos = _destination;
                pos.z = currentPosition.z;
                return pos;
            }

            Vector2 translation = _speedVector * Time.deltaTime;
            pos = currentPosition + (Vector3)translation;
            return pos;
        }

        private void EnsureDestinationInBounds()
        {
            Vector2 tmpDest = _destination;

            if (_box.HasValue)
            {
                _destination = _bounder.ClampBox2D(_destination, _box.Value);
            }
            else
            {
                Vector2 clamped = _destination;
                clamped.x = _bounder.Clamp(clamped.x, 0);
                clamped.y = _bounder.Clamp(clamped.y, 1);
                _destination = clamped;
            }

            if (tmpDest != _destination)
            {
                RecalculateSpeedVector();
            }
        }

        private void RecalculateSpeedVector()
        {
            _speedVector = (_destination - (Vector2)transform.position).normalized * _speed;
        }
    }
}