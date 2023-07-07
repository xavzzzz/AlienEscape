using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightReticle : MonoBehaviour
{
    public List<LightManager> Sidelights;
    public Color Color;
    public LightManager CurrentSide;

    public void NewManipulate() { 
        
        foreach (LightManager x in Sidelights)
        {
            x.ClearManipulated(); x.Manipulated = this;
        }
        Debug.Log("selected"); }

    public void RemoveManipulate() { CurrentSide.LightReticles.Remove(this); }

    public void Awake()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color;
    }
}
