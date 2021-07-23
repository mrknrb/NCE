using UnityEngine;
using UnityEngine.UI;

namespace Resources.Menu.Elemek.MenuElemek.CustomGameMenu
{
    public class StudentCountMaxValue : MonoBehaviour
    {
        // Start is called before the first frame update
        public Slider rowCountSlider;

        public Slider columnCountSlider;

        public Slider studentCountSlider;
        public Toggle egyHelyKihagy;

        // Start is called before the first frame update
        void Start()
        {
            rowCountSlider.onValueChanged.AddListener (delegate {ValueChanged ();});
            columnCountSlider.onValueChanged.AddListener (delegate {ValueChanged ();});
            egyHelyKihagy.onValueChanged.AddListener (delegate {ValueChanged ();});
            ValueChanged();
        }

        void ValueChanged()
        {
            var osztas = 1;
            if (egyHelyKihagy.isOn)
            {
                osztas = 2;
            }

            studentCountSlider.minValue = 0;
            studentCountSlider.maxValue = (rowCountSlider.value*columnCountSlider.value*2/osztas-1);

        }
    }
}
