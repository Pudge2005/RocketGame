using System.IO;

namespace Game.Core
{
    public sealed class PlayerData
    {
        public long ScoreRecord { get; set; }
        public long Money { get; set; }

        public int TurrelSpeedUpgrade { get; set; }
        public int TurrelDamageUpgrade { get; set; }
        public int TurrelMultishotUpgrade { get; set; }
        public int ShieldUpgrade { get; set; }
        public int ShipHealthUpgrade { get; set; }
        public int ShipMobilityUpgrade { get; set; }

        public int MoneyEarningMultiplierUpgrade { get; set; }

        public int ShipSkinID { get; set; }
        public int BulletsSkinID { get; set; }


        internal void LoadData(BinaryReader reader)
        {
            ScoreRecord = reader.ReadInt64();
            Money = reader.ReadInt64();

            TurrelSpeedUpgrade = reader.ReadInt32();
            TurrelDamageUpgrade = reader.ReadInt32();
            TurrelMultishotUpgrade = reader.ReadInt32();
            ShieldUpgrade = reader.ReadInt32();
            ShipHealthUpgrade = reader.ReadInt32();
            ShipMobilityUpgrade = reader.ReadInt32();

            MoneyEarningMultiplierUpgrade = reader.ReadInt32();

            ShipSkinID = reader.ReadInt32();
            BulletsSkinID = reader.ReadInt32();
        }

        internal void SaveData(BinaryWriter writer)
        {
            writer.Write(ScoreRecord);
            writer.Write(Money);

            writer.Write(TurrelSpeedUpgrade);
            writer.Write(TurrelDamageUpgrade);
            writer.Write(TurrelMultishotUpgrade);
            writer.Write(ShieldUpgrade);
            writer.Write(ShipHealthUpgrade);
            writer.Write(ShipMobilityUpgrade);

            writer.Write(MoneyEarningMultiplierUpgrade);

            writer.Write(ShipSkinID);
            writer.Write(BulletsSkinID);
        }
    }
}