using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public bool opened;
    private bool paused;
    public Animator PlayerAnimator;

    public void Awake()
    {
        paused = false;
    }

    public void PlayCasette() {

        this.GetComponent<AudioSource>().Play();
    }

    public void PauseCasette()
    {
        Debug.Log("pause");
        if(!paused)
        { 
            this.GetComponent<AudioSource>().Pause(); paused = true;
            
        }
        else
        {
            this.GetComponent<AudioSource>().UnPause(); paused = false;
        }
    }

    public void RewindCasette()
    {

        this.GetComponent<AudioSource>().Stop();
    }

    public void ChangeCasette(AudioClip newTape)
    {
        this.GetComponent<AudioSource>().clip = newTape;
    }

    public void CloseCasette()
    {
        PlayerAnimator.SetBool("Show", false);
    }

    public void OpenCasette()
    {
        PlayerAnimator.SetBool("Show", true);
    }



}
