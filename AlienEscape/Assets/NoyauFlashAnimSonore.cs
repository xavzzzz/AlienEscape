using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoyauFlashAnimSonore : MonoBehaviour
{
    private void CorePulse()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Artefact/ArtefactCORE_Flash", GetComponent<Transform>().position);
    }

    private void CoreFlash()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Artefact/ArtefactCORE_Flash Explosion", GetComponent<Transform>().position);
    }
}
