using UnityEngine;

namespace Game.Core
{
    public sealed class IdentityRotationProviderComponent : ProviderComponent<Quaternion>
    {
        public override Quaternion GetItem()
        {
            return Quaternion.identity;
        }
    }
}