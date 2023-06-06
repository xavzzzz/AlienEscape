using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasetteAudio : MonoBehaviour
{
   public AudioClip AudioFile;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AudioSlot") other.GetComponent<AudioManager>().ChangeCasette(AudioFile); Debug.Log("in");
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "AudioSlot") Debug.Log("exit");
    }
}
