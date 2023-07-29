using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreExplosionAnimAudio : MonoBehaviour
{
    // Start is called before the first frame update
    private void CoreExplosion()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Artefact/ArtefactCORE_Break", GetComponent<Transform>().position);
    }
}
