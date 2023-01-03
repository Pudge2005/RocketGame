using UnityEngine;

namespace Game.Core
{
    public sealed class MeteorStats
    {
        public float Speed { get; set; }
        public float Damage { get; set; }
        public float MinRadius { get; set; }
        public float MaxRadius { get; set; }

        public Vector2 DirectionFrom { get; set; }
        public Vector2 DirectionTo { get; set; }
    }
}