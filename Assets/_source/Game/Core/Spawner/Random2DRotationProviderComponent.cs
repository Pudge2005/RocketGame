using UnityEngine;

namespace Game.Core
{
    public sealed class Random2DRotationProviderComponent : ProviderComponent<Quaternion>
    {
        public override Quaternion GetItem()
        {
            return Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360));
        }
    }
}