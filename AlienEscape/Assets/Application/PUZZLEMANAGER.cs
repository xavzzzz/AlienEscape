using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUZZLEMANAGER : MonoBehaviour
{
    public bool AudioPuzzleCheck, LightRunePuzzleCheck;

    public GameObject XrRef;
    public Animator OverlayRef;

    public Animator NoyauRef;
    private FMOD.Studio.EventInstance SceneFinalAmbiant;

    void Start()
    {
        SceneFinalAmbiant = FMODUnity.RuntimeManager.CreateInstance("event:/Ambiance/Final_Ambiance");
        
    }


    public void CheckIfAdvanceToSecondScene()
    {
        //TP TO SECOND LOCATION

        if (LightRunePuzzleCheck && AudioPuzzleCheck)
        {
            
            StartCoroutine(Teleport());
        }

        
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(6f);
        NoyauRef.SetBool("Flash", true);
        OverlayRef.SetBool("Unlock", true);
        yield return new WaitForSeconds(6f);
        XrRef.transform.position = new Vector3(0,0,20);
        SceneFinalAmbiant.start();
    }

}
