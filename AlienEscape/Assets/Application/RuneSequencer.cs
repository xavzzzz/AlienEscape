using System.Collections;
using System.Collections.Generic;
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
        RuneRight = FMODUnity.RuntimeManager.CreateInstance("event:/Artefact/Artefact_Artefact_RuneWin");
        RuneFail.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        RuneRight.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }

    public void TrySequence(Rune a)
    {
        Debug.Log("try");

        if (tries >= MaxSequence) { Debug.Log("Loser let's reset"); RuneFail.start(); }


        if (a.OrderInSequence == counter || a.OrderInSequence == MaxSequence-counter+1)
        {
            RuneRight.start();

            if (counter == MaxSequence) { Debug.Log("T TRO FORT SALE RACISTE"); return; } 
            Debug.Log("Can continue");
            counter++;
        }
        else
        {
            Debug.Log("Already Lost");
        }

        tries++;
    }
}
