using Game.Core;
using TMPro;
using UnityEngine;

namespace Game.Ui
{
    public sealed class ScorePanelUi : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _moneyText;
        [SerializeField] private GameManager _gm;


        private void Start()
        {
            _gm.OnEarnedMoneyChanged += HandleEarnedMoneyChanged;
            _gm.OnPassedDistanceChanged += HandlePassedDistanceChanged;
        }

        private void HandlePassedDistanceChanged(double value)
        {
            _scoreText.text = value.ToString("N1");
        }

        private void HandleEarnedMoneyChanged(long value, long delta)
        {
            //todo: add long to string converter (k, kk, m, b...)
            _moneyText.text = value.ToString();
        }

    }
}
