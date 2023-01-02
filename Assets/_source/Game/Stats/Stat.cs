namespace Game.Stats
{
    public sealed class Stat : IStat
    {
        private float _maxStatValue;
        private float _statValue;


        public Stat(float maxStatValue, float statValue)
        {
            _maxStatValue = maxStatValue;
            _statValue = statValue;
        }


        public float StatValue => _statValue;


        public event System.Action<IStat, float, float> OnStatValueChanged;
        public event System.Action<IStat, float, float> OnStatValueReachedMin;


        public void SetStatValue(float v)
        {
            ChangeStatValue(v - _statValue);
        }

        public void ChangeStatValue(float rawDelta)
        {
            float safeDelta = rawDelta;
            float desired = _statValue + rawDelta;
            bool reachedMin = desired <= 0;
            bool reachedMax = !reachedMin && desired >= _maxStatValue;

            if (reachedMin)
            {
                safeDelta = -_statValue;
                _statValue = 0;
            }
            else if (reachedMax)
            {
                safeDelta = _maxStatValue - _statValue;
                _statValue = _maxStatValue;
            }
            else
            {
                _statValue += safeDelta;
            }

            OnStatValueChanged?.Invoke(this, rawDelta, safeDelta);

            if (reachedMin)
                OnStatValueReachedMin?.Invoke(this, rawDelta, safeDelta);
        }
    }
}
