using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightReticle : MonoBehaviour
{
    public LightManager TorchLight;
    public Color ReticleColor;
    private bool inSlot;

    // Start is called before the first frame update
    void Start()
    {
        inSlot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inSlot) TorchLight.AddLight(ReticleColor);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Slot") inSlot = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Slot") inSlot = false; TorchLight.RemoveLight(ReticleColor);
    }
}
