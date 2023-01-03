using System;
using System.Collections;
using UnityEngine;

namespace DevourDev.Unity.Utils
{
    public static class GameObjectExtentions
    {
        private static readonly ExposableList<Component> _componentsBuffer = new();


        public static ReadOnlyMemory<Component> GetComponentsNonAlloc(this GameObject go, Type type)
        {
            _componentsBuffer.Clear(); //for gc
            go.GetComponents(type, _componentsBuffer.GetInternalList());
            return _componentsBuffer.AsMemory();
        }


        public static Coroutine ExecuteDelayed(this MonoBehaviour monobeh, System.Action action, float delay)
        {
            return monobeh.StartCoroutine(DelayedExecutor(action, delay));
        }

        private static IEnumerator DelayedExecutor(System.Action action, float delay)
        {
            yield return new WaitForSecondsRealtime(delay);
            action();
        }
    }

}