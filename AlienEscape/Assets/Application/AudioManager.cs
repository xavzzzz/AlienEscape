using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AudioManager : MonoBehaviour
{
    public int CurrentCassetteID = 0;
    private FMOD.Studio.EventInstance Cassette_1;
    private FMOD.Studio.EventInstance Cassette_2;
    private FMOD.Studio.EventInstance Cassette_3;

    private bool Cas1Paused;
    private bool Cas2Paused;
    private bool Cas3Paused;

    private bool FromRewind;
    private bool FromForward;


    void Start()
    {
        Cassette_1 = FMODUnity.RuntimeManager.CreateInstance("event:/Cassetes/Cassette 1");
        Cassette_2 = FMODUnity.RuntimeManager.CreateInstance("event:/Cassetes/Cassette 2");
        Cassette_3 = FMODUnity.RuntimeManager.CreateInstance("event:/Cassetes/Cassette 3");

    }


    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        int i = args.interactable.gameObject.GetComponent<CasetteAudio>().CasetteNumber;
        UpdateID(i);
    }

    public void EjectCasette()
    {

        if (CurrentCassetteID != 0)
        {

            if (CurrentCassetteID == 1)
            {
                Cassette_1.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                CurrentCassetteID = 0;
            }

            if (CurrentCassetteID == 2)
            {
                Cassette_2.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                CurrentCassetteID = 0;
            }

            if (CurrentCassetteID == 3)
            {
                Cassette_3.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                CurrentCassetteID = 0;
            }
        }
        
    }



    public void UpdateID(int x)
    {
        CurrentCassetteID = x;
        Cassette_1.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        Cassette_2.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        Cassette_3.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }

    public void PlayCasette()
    {
        if (CurrentCassetteID != 0)
        {

            if (CurrentCassetteID == 1)
            {
                if (FromRewind == true)
                {
                    Cassette_1.getTimelinePosition(out int TimePosition);
                    Cassette_1.setTimelinePosition((63097) - TimePosition);
                    FromRewind = false;
                    FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Cassette1_Rewind", 0);

                }
                else if( FromForward == true)
                {
                    FromForward = false;
                    FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Cassette1_FastForward", 0);
                }

                else if (Cas1Paused)
                {

                    //Play FMOD event 1
                    Cassette_1.setPaused(false);
                    Cas1Paused = false;
                }
                else
                {
                    
                    //Play FMOD event 1
                    Cassette_1.start();
                }
                
            }

            if (CurrentCassetteID == 2)
            {
                if (FromRewind == true)
                {
                    Cassette_2.getTimelinePosition(out int TimePosition);
                    Cassette_2.setTimelinePosition((63097) - TimePosition);
                    FromRewind = false;
                    FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Cassette1_Rewind", 0);

                }
                else if (FromForward == true)
                {
                    FromForward = false;
                    FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Cassette1_FastForward", 0);
                }

                else if (Cas1Paused)
                {

                    //Play FMOD event 1
                    Cassette_2.setPaused(false);
                    Cas2Paused = false;
                }
                else
                {

                    //Play FMOD event 1
                    Cassette_2.start();
                }

            }

            if (CurrentCassetteID == 3)
            {
                if (FromRewind == true)
                {
                    Cassette_3.getTimelinePosition(out int TimePosition);
                    Cassette_3.setTimelinePosition((63097) - TimePosition);
                    FromRewind = false;
                    FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Cassette1_Rewind", 0);

                }
                else if (FromForward == true)
                {
                    FromForward = false;
                    FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Cassette1_FastForward", 0);
                }

                else if (Cas1Paused)
                {

                    //Play FMOD event 1
                    Cassette_3.setPaused(false);
                    Cas3Paused = false;
                }
                else
                {

                    //Play FMOD event 1
                    Cassette_3.start();
                }

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
                Cassette_1.setPaused(true);
                Cas1Paused = true;
            }

            if (CurrentCassetteID == 2)
            {
                //Play FMOD event 2
                Cassette_2.setPaused(true);
                Cas2Paused = true;
            }

            if (CurrentCassetteID == 3)
            {
                //Play FMOD event 3
                Cassette_3.setPaused(true);
                Cas3Paused = true;
            }
        }
    }
    public void RewindCasette()
    {
        if (CurrentCassetteID != 0)
        {

            if (CurrentCassetteID == 1)
            {
                //PAUSE FMOD event 1
                FromRewind = true;
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Cassette1_Rewind", 1);

            }

            if (CurrentCassetteID == 2)
            {
                //Play FMOD event 2
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Cassette1_Rewind", 1);
                FromRewind = true;
                
            }

            if (CurrentCassetteID == 3)
            {
                //Play FMOD event 3
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Cassette1_Rewind", 1);
                FromRewind = true;
                
            }
        }
    }

    public void ForwardCasette()
    {
        if (CurrentCassetteID != 0)
        {

            if (CurrentCassetteID == 1)
            {
                //PAUSE FMOD event 1
                FromForward = true;
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Cassette1_FastForward", 1);

            }

            if (CurrentCassetteID == 2)
            {
                //Play FMOD event 2
                FromForward = true;
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Cassette1_FastForward", 1);
            }

            if (CurrentCassetteID == 3)
            {
                //Play FMOD event 3
                FromForward = true;
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Cassette1_FastForward", 1);
            }
        }
    }

}
