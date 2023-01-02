using UnityEngine;

namespace Game.Controller
{
    public abstract class Controller2DEndPositionProcessor : MonoBehaviour
    {
        public abstract Vector2 ProcessPosition(Vector2 desiredPosition);
    }
}