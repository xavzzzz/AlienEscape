using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUZZLEMANAGER : MonoBehaviour
{
    public bool AudioPuzzleCheck, LightRunePuzzleCheck;

    public GameObject XrRef;

    public void CheckIfAdvanceToSecondScene()
    {
        //TP TO SECOND LOCATION

        if (LightRunePuzzleCheck && LightRunePuzzleCheck)
        {
            Teleport();
        }

        
    }

    public void Awake()
    {
        Teleport();
    }

    public void Teleport()
    {
        XrRef.transform.position = new Vector3(0,0,20);
    }

}
