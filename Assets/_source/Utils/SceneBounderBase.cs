﻿using UnityEngine;

namespace Utils
{
    public abstract class SceneBounderBase : MonoBehaviour
    {
        public abstract Vector3 Min { get; }
        public abstract Vector3 Max { get; }

        public Vector3 Center => (Min + Max) / 2f;


#if UNITY_EDITOR
        protected virtual void OnDrawGizmos()
        {
            UnityEditor.Handles.color = Color.cyan;
            Vector3 ll = Min;
            Vector3 ur = Max;
            Vector3 ul = new(ll.x, ur.y);
            Vector3 lr = new(ur.x, ll.y);

            UnityEditor.Handles.DrawDottedLines(new Vector3[] { ll, ul, ul, ur, ur, lr, lr, ll }, 5);
        }
#endif

        public float Clamp(float v, int dimentionIndex)
        {
            var min = Min;
            var max = Max;

            if (v < min[dimentionIndex])
                v = min[dimentionIndex];
            else if (v > max[dimentionIndex])
                v = max.x;

            return v;
        }

        public bool TryClamp(float v, int dimentionIndex, out float clampedV)
        {
            var min = Min;
            var max = Max;

            bool clamped = false;
            clampedV = v;

            if (clampedV < min[dimentionIndex])
            {
                clampedV = min[dimentionIndex];
                clamped = true;
            }
            else if (clampedV > max[dimentionIndex])
            {
                clampedV = max[dimentionIndex];
                clamped = true;
            }

            return clamped;
        }

        public Vector3 Clamp(Vector3 v)
        {
            for (int i = 0; i < 3; i++)
            {
                v[i] = Clamp(v[i], i);
            }

            return v;
        }

        public bool TryClamp(Vector3 v, out Vector3 clampedV)
        {
            bool clamped = false;
            clampedV = v;

            for (int i = 0; i < 3; i++)
            {
                if (TryClamp(clampedV[i], i, out var clampedV0))
                {
                    clampedV[i] = clampedV0;
                    clamped = true;
                }
            }

            return clamped;
        }

        public Vector2 ClampBox2D(Vector2 center, Vector2 extents)
        {
            ClampBox2DHelper(center, extents, out var clampedX, out var clampedY,
                out _, out _);

            return new Vector2(clampedX, clampedY);
        }

        private void ClampBox2DHelper(Vector2 center, Vector2 extents,
            out float clampedX, out float clampedY,
            out bool changedX, out bool changedY)
        {
            Vector2 delta = center - (Vector2)Center;
            float offsetX = delta.x < 0 ? -extents.x : extents.x;
            changedX = TryClamp(center.x + offsetX, 0, out clampedX);
            clampedX -= offsetX;
            float offsetY = delta.y < 0 ? -extents.y : extents.y;
            changedY = TryClamp(center.y + offsetY, 1, out clampedY);
            clampedY -= offsetY;
        }

        public bool Contains2D(Vector2 point)
        {
            var min = Min;
            var max = Max;

            return point.x >= min.x && point.x <= max.x
                && point.y >= min.y && point.y <= max.y;
        }

        public bool Contains(Vector3 point)
        {
            var min = Min;
            var max = Max;

            return point.x >= min.x && point.x <= max.x
                && point.y >= min.y && point.y <= max.y
                && point.z >= min.z && point.z <= max.z;
        }

        public bool Contains(Vector3 point, out Vector3Int outOfBounds)
        {
            var min = Min;
            var max = Max;
            outOfBounds = Vector3Int.zero;

            if (point.x < min.x)
                outOfBounds.x = -1;
            else if (point.x > max.x)
                outOfBounds.x = 1;

            if (point.y < min.y)
                outOfBounds.y = -1;
            else if (point.y > max.y)
                outOfBounds.y = 1;

            if (point.z < min.z)
                outOfBounds.z = -1;
            else if (point.z > max.z)
                outOfBounds.z = 1;

            return outOfBounds == Vector3Int.zero;
        }
    }
}