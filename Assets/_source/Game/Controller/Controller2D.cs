using System;
using UnityEngine;

namespace Game.Controller
{


    public sealed class Controller2D : MonoBehaviour
    {
        public Vector2 Velocity { get; set; }
        public Func<Vector2, Vector2> EndPositionProcessor { get; set; }


        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (Velocity == Vector2.zero)
                return;

            Vector3 curPos = transform.position;
            Vector2 translation = Time.deltaTime * Velocity;
            Vector2 desiredPos = (Vector2)curPos + translation;
            desiredPos = EndPositionProcessor(desiredPos);

            if (gameObject == null)
                return;

            curPos.x = desiredPos.x;
            curPos.y = desiredPos.y;
            transform.position = curPos;
        }
    }
}