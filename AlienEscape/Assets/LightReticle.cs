using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightReticle : MonoBehaviour
{
    public LightManager TorchLight;
    public Color ReticleColor;


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Slot")  TorchLight.AddLight(ReticleColor);
    }

    void OnTriggerExit(Collider other)
    {
        //change remove light because can be called multiple times but should only be added once
        if (other.tag == "Slot") TorchLight.RemoveLight(ReticleColor); 
    }
}
