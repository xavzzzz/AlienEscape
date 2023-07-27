using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneManager : MonoBehaviour
{
    public Material RuneLook;
    public Material DefaultLook;

    private FMOD.Studio.EventInstance Glow;

    public bool Unlocked;

    private void Awake()
    {
        Unlocked = false;
        Glow = FMODUnity.RuntimeManager.CreateInstance("event:/Artefact/Artefact_RuneGlowing");

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rune" && Unlocked)
        {
            Glow.start();
            other.GetComponent<Renderer>().material = RuneLook;
            Glow.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(other.gameObject.transform.position));
        }
    }

    void OnTriggerExit(Collider other)
        {
        Glow.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        if (other.tag == "Rune" && Unlocked) other.GetComponent<Renderer>().material = DefaultLook;
        }
    
}
