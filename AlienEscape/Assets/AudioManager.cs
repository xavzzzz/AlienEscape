using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    

    public void PlayCasette() {

        this.GetComponent<AudioSource>().Play();
    }

    public void PauseCasette()
    {

        this.GetComponent<AudioSource>().Pause();
    }

    public void RewindCasette()
    {

        this.GetComponent<AudioSource>().Stop();
    }

    public void ChangeCasette(AudioClip newTape)
    {
        this.GetComponent<AudioSource>().clip = newTape;
    }



}
