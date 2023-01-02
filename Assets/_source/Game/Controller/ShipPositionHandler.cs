using UnityEngine;

namespace Game.Controller
{
    [RequireComponent(typeof(Controller2D))]
    public sealed class ShipPositionHandler : MonoBehaviour
    {
        [SerializeField] private Controller2DEndPositionProcessor[] _positionProcessors;

        private Controller2D _controller;


        private void Awake()
        {
            _controller = GetComponent<Controller2D>();
            _controller.EndPositionProcessor = ChainProcessPosition;
        }

        private Vector2 ChainProcessPosition(Vector2 desiredPos)
        {
            foreach (var processor in _positionProcessors)
            {
                desiredPos = processor.ProcessPosition(desiredPos);
            }

            return desiredPos;
        }
    }
}