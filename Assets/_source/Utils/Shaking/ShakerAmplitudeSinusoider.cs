using UnityEngine;

namespace DevourDev.Unity.Utils.Shake
{
    public sealed class ShakerAmplitudeSinusoider : MonoBehaviour
    {
        [SerializeField] private Shaker _shaker;


        private void Update()
        {
            _shaker.CurveTime = (float)System.Math.Abs(System.Math.Sin(Time.timeAsDouble));
        }
    }

}