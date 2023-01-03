using UnityEngine;

namespace Utils
{
    public abstract class EntityPositionTranslator : MonoBehaviour
    {
        protected virtual void Update()
        {
            var pos = transform.position;
            transform.position = Translate(pos);
        }


        protected abstract Vector3 Translate(Vector3 currentPosition);
    }
}