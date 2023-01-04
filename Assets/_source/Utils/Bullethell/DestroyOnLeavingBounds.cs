using UnityEngine;
using Utils;

namespace Game
{
    public sealed class DestroyOnLeavingBounds : MonoBehaviour
    {
        [SerializeField] private ProviderComponent<SceneBounder> _bounderProvider;
        [SerializeField] private float _minLifeTime = 5f;
        [SerializeField] private bool _resetOnEnterBounds = true;

        private SceneBounder _bounder;
        private float _minLifeTimeLeft;


        private void Awake()
        {
            _bounder = _bounderProvider.GetItem();
            ResetTtlLeft();
        }

        private void ResetTtlLeft()
        {
            Debug.Log($"{name} ttl reseted");
            _minLifeTimeLeft = _minLifeTime;
        }

        private void Update()
        {
            if (_minLifeTimeLeft > 0)
            {
                if ((_minLifeTimeLeft -= Time.deltaTime) > 0)
                    return;
            }

            if (!_bounder.Contains2D(transform.position))
                Destroy(gameObject);

            if (_resetOnEnterBounds)
                ResetTtlLeft();
        }
    }
}
