using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Content.Interaction;

public class PotentiometreValue : MonoBehaviour
{
    public float value;
    public string potentiometreID;

    public bool IsSlider;



    // Update is called once per frame
    void Update()
    {
        if (IsSlider) { 
            value = GetComponent<XRSlider>().value;
        }
        else
        {
            value = GetComponent<XRKnob>().value;
        }
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("potentiomètre " + potentiometreID, value);
        
    }
}
