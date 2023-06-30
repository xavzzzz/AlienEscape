using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightReticle : MonoBehaviour
{
    public LightManager TorchLight;
    public Color Color;


    void OnTriggerEnter(Collider other)
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        
    }

    public void NewManipulate() { TorchLight.Manipulated = this; Debug.Log("selected"); }

    public void RemoveManipulate() {  Debug.Log("null"); }

    public void Awake()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color;
    }
}
