using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneManager : MonoBehaviour
{
    public Material RuneLook;
    public Material DefaultLook;

    public bool Unlocked;

    private void Awake()
    {
        Unlocked = false;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rune" && Unlocked) other.GetComponent<Renderer>().material = RuneLook;
    }

    void OnTriggerExit(Collider other)
        {
        if (other.tag == "Rune" && Unlocked) other.GetComponent<Renderer>().material = DefaultLook;
        }
    
}
