using Game.Core;
using Utils;

namespace Game
{
    public sealed class SceneBounderFromRuntimeAccessorsProvider : ProviderComponent<SceneBounderBase>
    {
        public override SceneBounderBase GetItem()
        {
            return RuntimeAccessors.MainSceneBounder;
        }
    }
}
