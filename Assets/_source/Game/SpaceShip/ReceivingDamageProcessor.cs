using UnityEngine;

namespace Game
{
    public abstract class ReceivingDamageProcessor : MonoBehaviour
    {
        public abstract float ProcessDmg(float dmg);
    }
}
