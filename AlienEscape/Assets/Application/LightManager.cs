using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Hardware;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LightManager : MonoBehaviour
{
    
    public List<Collider> LightSlots;
    public GameObject Bulb;
    public LightOutput LightSource;
    public LightReticle Manipulated;
    public List<LightReticle> LightReticles;


    private Color originalColor;

    private XRSocketInteractor Interactor;

    private void Awake()
    {
        LightSource.GetComponent<Light>().color = Color.clear;

    }

    public void UpdateLight()
    {
        var NewColor = Color.clear;
        foreach(LightReticle x in LightReticles)
        {
            NewColor = CombineColors(NewColor, x.Color);   
        }

        Bulb.GetComponent<Renderer>().material.color = NewColor;
        LightSource.UpdateColorOut();
    }


    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Store the attached GameObject when an Interactable is grabbed
        Debug.Log(args.interactorObject);
    }



    public void ClearManipulated() { Manipulated = null; }

    public void RemoveLight()
    {
        if (Manipulated != null)
        {
            var output = Color.grey;
            Debug.Log("2");
            if (LightReticles[0].Color != null) { output = LightReticles[0].Color; }
                
            Bulb.GetComponent<Renderer>().material.color = output;
            LightSource.UpdateColorOut();
        }
    }
        public static Color GetComplementaryColor(Color color)
        {
            Color.RGBToHSV(color, out float h, out float s, out float v);
            h = (h + 0.5f) % 1f;
            return Color.HSVToRGB(h, s, v);
        }

        public static Color CombineColors(params Color[] aColors)
        {
            Color result = new Color(0, 0, 0, 0);
            foreach (Color c in aColors)
            {
                result += c;
            }
            result /= aColors.Length;
            return result;
        }

        public static Color RemoveColors(params Color[] aColors)
        {
            Color result = new Color(0, 0, 0, 0);
            foreach (Color c in aColors)
            {
                result -= c;
            }
            result /= aColors.Length;
            return result;
        }
    
}
