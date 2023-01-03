using System.IO;
using Utils;

namespace Game.Core
{
    /// <summary>
    /// todo: rename
    /// </summary>
    public static class RuntimeAccessors
    {
        private const string _saveFileName = "UserData.dat";

        private static readonly string _savePath;
        private static readonly PlayerData _playerData;


        static RuntimeAccessors()
        {
            _savePath = Path.Combine(UnityEngine.Application.persistentDataPath, _saveFileName);
            _playerData = new();

            if (File.Exists(_savePath))
            {
                var fs = File.OpenRead(_savePath);
                using var br = new BinaryReader(fs);
                _playerData.LoadData(br);
            }
        }


        public static SceneBounder MainSceneBounder { get; set; }

        public static PlayerData PlayerData => _playerData;



        public static void SavePlayerData()
        {
            var fs = new FileStream(_savePath, FileMode.OpenOrCreate, FileAccess.Write);
            using var bw = new BinaryWriter(fs);
            _playerData.SaveData(bw);
        }
    }
}