using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Ui
{

    public class StatsPanelUi : MonoBehaviour
    {
        [SerializeField] private StatSlotUi _slotPrefab;
        [SerializeField] private Transform _slotsParent;

        private readonly List<StatSlotUi> _slots = new();
        

        public StatSlotUi BuildSlot()
        {
            var slot = Instantiate(_slotPrefab, _slotsParent);
            _slots.Add(slot);
            return slot;
        }
    }
}
