using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Content.Interaction;

public class PotentiometreValue : MonoBehaviour
{
    public float value;
    public string potentiometreID;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        value = GetComponent<XRKnob>().value;
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("potentiomètre " + potentiometreID, value);
        
    }
}
