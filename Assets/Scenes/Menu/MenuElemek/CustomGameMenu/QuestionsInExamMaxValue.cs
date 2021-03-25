using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Menu.MenuElemek
{
    public class QuestionsInExamMaxValue : MonoBehaviour
    {
        public Slider maxslider;

        public Slider examQuestionsSlider;
        // Start is called before the first frame update
        void Start()
        {
            maxslider.onValueChanged.AddListener (delegate {ValueChanged ();});
            ValueChanged();
        }

        void ValueChanged()
        {

            examQuestionsSlider.maxValue = maxslider.value;

        }
    }
}
