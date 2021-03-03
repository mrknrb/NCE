using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Szamcsuszka : MonoBehaviour
{
    public Slider csuszka;
    public TextMeshProUGUI csuszkaValue;

    void Start()
    {
        csuszka.onValueChanged.AddListener (delegate {ValueChanged ();});
        ValueChanged();
    }

   void ValueChanged()
    {
        var  elozoValue = Convert.ToInt32(Math.Floor(csuszka.value));
                    csuszkaValue.text = elozoValue.ToString();
                    
    }
    
    void Update()
    {
      
     
    }
}
