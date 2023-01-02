﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace DevourDev.Unity.Helpers
{
    public static class AnimationHelpers
    {
        public static AnimationCurve CurveStartEnd(float startV, float endV)
        {
            return new AnimationCurve(new Keyframe(0, startV), new Keyframe(1f, endV));
        }
    }

    public static class CachingAccessors
    {
        private static readonly Dictionary<Type, Component> _dict = new();


        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Clear()
        {
            _dict.Clear();
        }


        public static T Get<T>() where T : UnityEngine.Component
        {
            //return (T)GameObject.FindObjectOfType(typeof(T));

            if (!_dict.TryGetValue(typeof(T), out var x))
            {
                x = (Component)GameObject.FindObjectOfType(typeof(T));

                if (x != null)
                {
                    _dict.Add(typeof(T), x);
                }
            }

            if (x == null)
                x = (Component)GameObject.FindObjectOfType(typeof(T));

            if (x == null)
                _dict.Remove(typeof(T));
            else
                _dict[typeof(T)] = x;

            return (T)x;
        }
    }
}
