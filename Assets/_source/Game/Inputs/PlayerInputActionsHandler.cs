using System;
using Game.Controller;
using UnityEngine;

namespace Game.Inputs
{
    public sealed class PlayerInputActionsHandler : MonoBehaviour
    {
        [SerializeField] private Controller2D _shipController;
        [SerializeField] private bool _forcedDestinationPositionRecheck = true;

        private Camera _cam;
        private PlayerControls _controls;
        private bool _awoken;

        private Vector2 _moveInDirection;

        private bool _movingToPoint;
        private Vector2 _destinationPoint;


        private void Awake()
        {
            if (_awoken)
                return;

            _awoken = true;
            _controls = new();
            _cam = Camera.main;
        }

        private void OnDestroy()
        {
            _controls.Dispose();
            _controls = null;
        }

        private void OnEnable()
        {
            if (!_awoken)
                Awake();

            var shipControls = _controls.SpaceShip;
            shipControls.MoveInDirection.performed += MoveInDirection_performed;
            shipControls.MoveToDestinationPoint.performed += MoveToDestinationPoint_performed;
            shipControls.SetDestinationPoint.performed += SetDestinationPoint_performed;
            shipControls.Enable();
        }

        private void OnDisable()
        {
            if (_controls == null)
                return;

            var shipControls = _controls.SpaceShip;
            shipControls.Disable();
            shipControls.MoveInDirection.performed -= MoveInDirection_performed;
            shipControls.MoveToDestinationPoint.performed -= MoveToDestinationPoint_performed;
            shipControls.SetDestinationPoint.performed -= SetDestinationPoint_performed;
        }


        private void SetDestinationPoint_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            Vector2 screenPos = context.ReadValue<Vector2>();
            _destinationPoint = _cam.ScreenToWorldPoint(screenPos);
        }

        private void MoveToDestinationPoint_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            _movingToPoint = context.ReadValue<float>() > 0.5f;
        }

        private void MoveInDirection_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            _moveInDirection = context.ReadValue<Vector2>();
        }


        private void Update()
        {
            MoveInDirection();

            MoveToPoint();
        }

        private void MoveInDirection()
        {
            _shipController.Velocity = _moveInDirection;
        }

        private void MoveToPoint()
        {
            if (!_movingToPoint)
                return;

            if (_forcedDestinationPositionRecheck)
                _destinationPoint = _cam.ScreenToWorldPoint(_controls.SpaceShip.SetDestinationPoint.ReadValue<Vector2>());

            Vector2 direction = _destinationPoint - (Vector2)_shipController.transform.position;
            _shipController.Velocity = direction.normalized;
        }
    }
}
