using UnityEngine;

namespace Utils
{
    public sealed class DestroyCallbackComponent : MonoBehaviour
    {
        public event System.Action<DestroyCallbackComponent> OnObjectDestroyed;


        private void OnDestroy()
        {
            OnObjectDestroyed?.Invoke(this);
        }
    }
}