using UnityEngine;

namespace Game
{
    public static class GameRules
    {
        private static ContactFilter2D? _contactFilter;


        public static LayerMask CollidablesLayerMask { get; internal set; }


        public static ContactFilter2D CollidablesContactFilter2D
        {
            get
            {
                if(!_contactFilter.HasValue)
                {
                    _contactFilter = new()
                    {
                        layerMask = CollidablesLayerMask,
                        useLayerMask = true,
                        useTriggers = false,
                    };
                }

                return _contactFilter.Value;
            }
        }
    }
}
