using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Rendering.CameraUI;

public class LightOutput : MonoBehaviour
{
    public GameObject Right;
    public GameObject Left;

    public void UpdateColorOut()
    {
        this.gameObject.GetComponent<Light>().color = Right.GetComponent<Renderer>().material.color + Left.GetComponent<Renderer>().material.color;
    }
}
