using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningFaceSon : MonoBehaviour
{
    private void CursedSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Artefact/Artefact_SecondOpen", GetComponent<Transform>().position);
    }

    private void StoneMove()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Artefact/OpeningAnimRunes/Artefact_Opening_StoneMove 2", GetComponent<Transform>().position);
    }
}
