using UnityEngine;

namespace Game.Core
{
    public sealed class CurvesOverDistanceProcessor : MonoBehaviour
    {
        [SerializeField] private GameManager _gm;


        private float Distance => (float)_gm.DistancePassed;


        public float Evaluate(AnimationCurve curve) => curve.Evaluate(Distance);
    }
}