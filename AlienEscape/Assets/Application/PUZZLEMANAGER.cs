using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUZZLEMANAGER : MonoBehaviour
{
    public bool AudioPuzzleCheck, LightRunePuzzleCheck;

    public GameObject XrRef;
    private FMOD.Studio.EventInstance SceneFinalAmbiant;

    void Start()
    {
        SceneFinalAmbiant = FMODUnity.RuntimeManager.CreateInstance("event:/Ambiance/Final_Ambiance");
        
    }


    public void CheckIfAdvanceToSecondScene()
    {
        //TP TO SECOND LOCATION

        if (LightRunePuzzleCheck && LightRunePuzzleCheck)
        {
            SceneFinalAmbiant.start();
            Teleport();
        }

        
    }

    public void Teleport()
    {
        XrRef.transform.position = new Vector3(0,0,20);
    }

}
