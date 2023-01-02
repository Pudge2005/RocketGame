using UnityEngine;

namespace Game.Ui
{
    public class StatSlotUi : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI _title;
        [SerializeField] private TMPro.TextMeshProUGUI _value;


        public void Init(string title, float value, Color? color = null)
        {
            _title.text = title;

            if (color.HasValue)
                _title.color = color.Value;

            _value.text = value.ToString("N1");

        }

        public void Set(float value)
        {
            _value.text = value.ToString("N1");
        }
    }
}
