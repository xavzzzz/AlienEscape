using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class RuneSequencer : MonoBehaviour
{
    public List<Rune> Runes;
    public int MaxSequence;


    private int counter;
    private int tries;

    private FMOD.Studio.EventInstance RuneFail;
    private FMOD.Studio.EventInstance RuneRight;


    public void Awake()
    {

        counter = 1;
        tries = 0;
        RuneFail = FMODUnity.RuntimeManager.CreateInstance("event:/Artefact/Artefact_RuneFailed");
        RuneRight = FMODUnity.RuntimeManager.CreateInstance("event:/Artefact/Artefact_RuneWin");
        RuneFail.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        RuneRight.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }

    public void TrySequence(Rune a)
    {
        
        Debug.Log("try");

        if (tries >= MaxSequence) { 
            Debug.Log("Loser let's reset"); 
            
            tries = 0;
        }


        if (a.OrderInSequence == counter || a.OrderInSequence == MaxSequence-counter+1) 
        {
            //RuneRight.start();
            FMODUnity.RuntimeManager.PlayOneShot("event:/Artefact/Artefact_RuneWin", GetComponent<Transform>().position);
            if (counter == MaxSequence) { Debug.Log("T TRO FORT SALE RACISTE"); return; } 
            Debug.Log("Can continue");
            counter++;
        }
        else
        {
            Debug.Log("Already Lost");
            // RuneFail.start();
            FMODUnity.RuntimeManager.PlayOneShot("event:/Artefact/Artefact_RuneFailed", GetComponent<Transform>().position);
            counter = 1;
        }

        tries++;
    }


}
