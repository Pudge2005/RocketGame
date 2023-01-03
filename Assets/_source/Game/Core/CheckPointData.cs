namespace Game.Core
{
    public class CheckPointData
    {
        private readonly double _distance;
        private readonly long _money;

        private readonly float _shipHealth;
        private readonly float _shieldDurability;


        public CheckPointData(double distance, long money, float shipHealth, float shieldDurability)
        {
            _distance = distance;
            _money = money;
            _shipHealth = shipHealth;
            _shieldDurability = shieldDurability;
        }


        public double Distance => _distance;
        public long Money => _money;
        public float ShipHealth => _shipHealth;
        public float ShieldDurability => _shieldDurability;
    }
}