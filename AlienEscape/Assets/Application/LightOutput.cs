using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Rendering.CameraUI;

public class LightOutput : MonoBehaviour
{
    public GameObject Right;
    public GameObject Left;
    public Color RuneUnlock;

    public void UpdateColorOut()
    {
        Color combined = Right.GetComponent<Renderer>().material.color + Left.GetComponent<Renderer>().material.color;
        this.gameObject.GetComponent<Light>().color = combined;
        Debug.Log("comb "+combined);
        Debug.Log("out" +RuneUnlock);

        if (combined.Equals(RuneUnlock))  this.gameObject.GetComponent<RuneManager>().Unlocked = true;
    }
}
