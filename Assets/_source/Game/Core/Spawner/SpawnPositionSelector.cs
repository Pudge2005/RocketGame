using UnityEngine;

namespace Game.Core
{
    public abstract class SpawnPositionSelector : MonoBehaviour
    {
        public abstract Vector3 GetSpawnPosition();
    }
}