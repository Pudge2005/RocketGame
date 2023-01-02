using Game.Stats;
using UnityEngine;

namespace Game.Ui
{
    public sealed class StatView : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Component _statComponent;
        [SerializeField] private StatsPanelUi _statsPanelUi;
        [SerializeField] private string _statName;
        [SerializeField] private Color _statColor;

        private StatSlotUi _statSlot;


        private void Start()
        {
            InitSlot();
        }

        private void InitSlot()
        {
            IStat statComponent = (IStat)_statComponent;
            _statSlot = _statsPanelUi.BuildSlot();
            _statSlot.Init(_statName, statComponent.StatValue, _statColor);

            statComponent.OnStatValueChanged += HandleStatValueChanged;
        }

        private void HandleStatValueChanged(IStat sender, float raw, float safe)
        {
            _statSlot.Set(sender.StatValue);
        }
    }
}
