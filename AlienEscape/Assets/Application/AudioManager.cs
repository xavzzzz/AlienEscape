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

    public void UpdateID(int x)
    {
        CurrentCassetteID = x;
    }
}
