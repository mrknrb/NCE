using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        ValueChanged();
    }

    void ValueChanged()
    {
        var osztas = 1;
        if (egyHelyKihagy)
        {
            osztas = 2;
        }
        
        
        studentCountSlider.maxValue = (rowCountSlider.value*columnCountSlider.value*2/osztas)-1;

    }
}
