using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class OpeningAnimationAudio : MonoBehaviour
{

    public Material RuneLook;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FallingStone()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Artefact/OpeningAnimRunes/Artefact_Opening_PartFall", GetComponent<Transform>().position);
    }

    public void OpeningStone()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Artefact/OpeningAnimRunes/Artefact_Opening_StoneMove", GetComponent<Transform>().position);
    }

    public void OpeningSounde()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Artefact/Artefact_FirstOpen", GetComponent<Transform>().position);
    }

    public void FirstRune()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Artefact/OpeningAnimRunes/Artefact_RuneWinOpening", GetComponent<Transform>().position);
    }

    public void SecondRune()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Artefact/OpeningAnimRunes/Artefact_RuneWin Opening 2", GetComponent<Transform>().position);
    }

    public void ThirdRune()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Artefact/OpeningAnimRunes/Artefact_RuneWin Opening 3", GetComponent<Transform>().position);
    }

    public void FourthRune()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Artefact/OpeningAnimRunes/Artefact_RuneWin Opening 4", GetComponent<Transform>().position);
    }
}
