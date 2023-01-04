using DevourDev.Unity.Utils;
using UnityEngine;
using Utils;

namespace Game.Core
{
    public sealed class FromOutsideOfBoundsPosition2DSelector : ProviderComponent<Vector3>
    {
        private enum Sides
        {
            Up = 0b0000,
            Right = 0b0010,
            Down = 0b0100,
            Left = 0b1000,
        }


        [System.Serializable]
        private struct Zone
        {
            [SerializeField] private Sides _side;
            //todo: add covering zones

            public Sides Side => _side;
        }


        [SerializeField] private SceneBounderBase _bounder;
        [SerializeField] private Zone[] _zones;
        [SerializeField, Min(0f)] private float _distanceToBounds = 2f;

        private System.Random _rnd;


        private void Awake()
        {
            _rnd = new System.Random(UnityEngine.Random.Range(0, int.MaxValue));
        }

        public override Vector3 GetItem()
        {
            Zone zone = _zones[UnityEngine.Random.Range(0, _zones.Length)];
            Vector3 spawnPos = Vector3.zero;
            Vector2 boundsMin = _bounder.Min;
            Vector2 boundsMax = _bounder.Max;

            switch (zone.Side)
            {
                case Sides.Up:
                    spawnPos.x = Rnd(boundsMin.x, boundsMax.x);
                    spawnPos.y = boundsMax.y + _distanceToBounds;
                    break;
                case Sides.Right:
                    spawnPos.x = boundsMax.x + _distanceToBounds;
                    spawnPos.y = Rnd(boundsMin.y, boundsMax.y);
                    break;
                case Sides.Down:
                    spawnPos.x = Rnd(boundsMin.x, boundsMax.x);
                    spawnPos.y = boundsMin.y - _distanceToBounds;
                    break;
                default:
                    spawnPos.x = boundsMin.x - _distanceToBounds;
                    spawnPos.y = Rnd(boundsMin.y, boundsMax.y);
                    break;
            }

            return spawnPos;


            float Rnd(float min, float max) => RandomHelpers.NextFloat(min, max, _rnd);
        }
    }
}