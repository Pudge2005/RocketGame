using Game.Core;
using Utils;

namespace Game
{
    public sealed class SceneBounderFromRuntimeAccessorsProvider : ProviderComponent<SceneBounder>
    {
        public override SceneBounder GetItem()
        {
            return RuntimeAccessors.MainSceneBounder;
        }
    }
}
