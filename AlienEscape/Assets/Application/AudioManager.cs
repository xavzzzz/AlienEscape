using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AudioManager : MonoBehaviour
{
    public int CurrentCassetteID = 0;

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        int i = args.interactable.gameObject.GetComponent<CasetteAudio>().CasetteNumber;
        UpdateID(i);
    }

    public void EjectCasette()
    {
        CurrentCassetteID = 0;
    }



    public void UpdateID(int x)
    {
        CurrentCassetteID = x;
    }

    public void PlayCasette()
    {
        if (CurrentCassetteID != 0)
        {

            if (CurrentCassetteID == 1)
            {
                //Play FMOD event 1
            }

            if (CurrentCassetteID == 2)
            {
                //Play FMOD event 2
            }

            if (CurrentCassetteID == 3)
            {
                //Play FMOD event 3
            }
        }
    }

    public void PauseCasette()
    {
        if (CurrentCassetteID != 0)
        {

            if (CurrentCassetteID == 1)
            {
                //PAUSE FMOD event 1
            }

            if (CurrentCassetteID == 2)
            {
                //Play FMOD event 2
            }

            if (CurrentCassetteID == 3)
            {
                //Play FMOD event 3
            }
        }
    }
}
