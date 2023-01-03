using UnityEngine;

namespace Game.Core
{
    public abstract class EntitiesSpawnerBase : MonoBehaviour
    {
        public abstract GameObject Spawn();
    }
}