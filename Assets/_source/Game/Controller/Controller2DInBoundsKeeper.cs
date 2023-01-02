using UnityEngine;
using Utils;

namespace Game.Controller
{
    public sealed class Controller2DInBoundsKeeper : Controller2DEndPositionProcessor
    {
        [SerializeField] private SceneBounder _bounder;
        [SerializeField] private Collider2D _collider;


        public override Vector2 ProcessPosition(Vector2 desiredPosition)
        {
            return _bounder.ClampBox2D(desiredPosition, _collider.bounds.extents);
        }
    }
}