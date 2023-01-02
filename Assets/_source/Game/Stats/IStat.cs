using System;

namespace Game.Stats
{
    public interface IStat
    {
        float StatValue { get; }


        event Action<IStat, float, float> OnStatValueChanged;
        event Action<IStat, float, float> OnStatValueReachedMin;


        void ChangeStatValue(float rawDelta);
    }
}