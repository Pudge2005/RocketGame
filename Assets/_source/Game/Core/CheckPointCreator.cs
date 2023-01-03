using UnityEngine;

namespace Game.Core
{
    [System.Serializable]
    public class CheckPointCreator
    {
        [SerializeField] private float _distance;
        [SerializeField] private long _reward;

        public CheckPointCreator(float distance, long reward)
        {
            _distance = distance;
            _reward = reward;
        }


        public float Distance => _distance;
        public long Reward => _reward;
    }
}