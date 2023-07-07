using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightReticle : MonoBehaviour
{
    public List<LightManager> Sidelights;
    public Color Color;
    public LightManager CurrentSide;

    public void NewManipulate() {
       
        }

    public void RemoveManipulate() { 

    }

    public void Awake()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color;
    }
}
