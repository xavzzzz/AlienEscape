using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class RuneSequencer : MonoBehaviour
{
    public GameObject MANAGER;

    public int MaxSequence;
    public Animator UnlockAnimator;


    private int counter;
    private int tries;

    private FMOD.Studio.EventInstance RuneFail;
    private FMOD.Studio.EventInstance RuneRight;
    private FMOD.Studio.EventInstance PuzzleOpening;


    public void Awake()
    {
        counter = 1;
        tries = 0;
        RuneFail = FMODUnity.RuntimeManager.CreateInstance("event:/Artefact/Artefact_RuneFailed");
        RuneRight = FMODUnity.RuntimeManager.CreateInstance("event:/Artefact/Artefact_RuneWin");
        PuzzleOpening = FMODUnity.RuntimeManager.CreateInstance("event:/Artefact/Artefact_FirstOpen");

        RuneFail.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        RuneRight.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        PuzzleOpening.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }

    public void TrySequence(Rune a)
    {
        
        Debug.Log("try");

        if (tries >= MaxSequence) { 
            Debug.Log("Loser let's reset"); 
            
            tries = 0;
        }


        if (a.OrderInSequence == counter) 
        {
            //RuneRight.start();
            FMODUnity.RuntimeManager.PlayOneShot("event:/Artefact/Artefact_RuneWin", GetComponent<Transform>().position);
            if (counter == MaxSequence) {

                UnlockAnimator.SetBool("Unlock", true);
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Operture", +1);
                FMODUnity.RuntimeManager.PlayOneShot("event:/Artefact/Artefact_FirstOpen", GetComponent<Transform>().position);
                MANAGER.GetComponent<PUZZLEMANAGER>().LightRunePuzzleCheck = true;
                MANAGER.GetComponent<PUZZLEMANAGER>().CheckIfAdvanceToSecondScene();
                return;
            } 

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
