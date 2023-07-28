using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class AudioCheckingManager : MonoBehaviour
{
    private float Slider1, Slider2, Knob;
    public WaveManager one,two,three;

    public GameObject MANAGER;
    private bool OneKill,TwoKill,ThreeKill;

    private bool DoingCheck;


    public void SliderOneChangeValue(float x)
    {
        
        Slider1 = x;
        if (!DoingCheck) CheckKillCurve();
    }

    public void SliderTwoChangeValue(float x)
    {
        Slider2 = x;
        if (!DoingCheck) CheckKillCurve();
    }

    public void KnobChangeValue(float x)
    {
        Knob = x;
        if(!DoingCheck)CheckKillCurve();
    }

    private void CheckPuzzleComplete()
    {
        if (OneKill && TwoKill && ThreeKill) { 
            // END FMOD EVENT 

            
            MANAGER.GetComponent<PUZZLEMANAGER>().AudioPuzzleCheck = true;
            MANAGER.GetComponent<PUZZLEMANAGER>().CheckIfAdvanceToSecondScene();
        }
    }

    public void CheckKillCurve()
    {
        DoingCheck = true;
        if (Slider1 <= 0.48 && Slider1 >= 0.28)
        {
            if (Knob <= 0.71 && Knob >= 0.51)
            {
                if (Slider2 <= 0.88 && Slider2 >= 0.68)
                {
                    Debug.Log("KILL CURVE ONE");
                    OneKill = true;
                    one.StartLerpToZero();
                }
            }
        }

        if (Slider1 <= 0.75 && Slider1 >= 0.55)
        {
            if (Knob <= 0.19 && Knob >= 0.13)
            {
                if (Slider2 <= 0.33 && Slider2 >= 0.39)
                {
                    Debug.Log("KILL CURVE TWO");
                    TwoKill = true;
                    two.StartLerpToZero();
                }
            }
        }

        if (Slider1 <= 0.78 && Slider1 >= 0.98)
        {
            if (Knob <= 0.43 && Knob >= 0.39)
            {
                if (Slider2 <= 0.16 && Slider2 >= 0.07)
                {
                    Debug.Log("KILL CURVE THREE");
                    ThreeKill = true;
                    three.StartLerpToZero();
                }
            }
        }
        DoingCheck = false;
    }



}
