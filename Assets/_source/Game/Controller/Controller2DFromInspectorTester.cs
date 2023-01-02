using UnityEngine;

namespace Game.Controller
{
    public sealed class Controller2DFromInspectorTester : MonoBehaviour
    {
        [SerializeField] private Controller2D _controller;
        [SerializeField] private Vector2 _direction;
        [SerializeField] private float _speed;


        private void Update()
        {
            Vector2 velocity = _direction.normalized * _speed;
            _controller.Velocity = velocity;
        }
    }
}