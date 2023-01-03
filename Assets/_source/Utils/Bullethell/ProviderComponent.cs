using UnityEngine;

namespace Game
{
    public abstract class ProviderComponent<T> : MonoBehaviour
    {
        public abstract T GetItem();
    }
}
