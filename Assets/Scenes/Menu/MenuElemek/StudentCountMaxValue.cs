using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentCountMaxValue : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider rowCountSlider;

    public Slider columnCountSlider;

    public Toggle doublePad;
    public Slider studentCountSlider;
    // Start is called before the first frame update
    void Start()
    {
        rowCountSlider.onValueChanged.AddListener (delegate {ValueChanged ();});
        columnCountSlider.onValueChanged.AddListener (delegate {ValueChanged ();});
        doublePad.onValueChanged.AddListener (delegate {ValueChanged ();});
        ValueChanged();
    }

    void ValueChanged()
    {
        float doublePadSzorzo = 1;
        if (doublePad.isOn)
        {
            doublePadSzorzo = 2;
        }
        
        
        studentCountSlider.maxValue = rowCountSlider.value*columnCountSlider.value*doublePadSzorzo;

    }
}
