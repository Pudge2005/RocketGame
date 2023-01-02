using UnityEngine;

namespace Game
{
    public sealed class GameRulesInitializer : MonoBehaviour
    {
        [SerializeField] private LayerMask _collidablesLayerMask;


        private void Awake()
        {
            GameRules.CollidablesLayerMask = _collidablesLayerMask;
        }
    }
}
