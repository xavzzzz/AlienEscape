using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightOutput : MonoBehaviour
{
    public GameObject Main;
    public GameObject Right;
    public GameObject Left;
    public Color RuneUnlock;

    public void UpdateColorOut()
    {
        Color combined = CombineColors(Right.GetComponent<Renderer>().material.color, Left.GetComponent<Renderer>().material.color);
        this.gameObject.GetComponent<Light>().color = combined;
        Main.GetComponent<Renderer>().material.color = combined;    


       if (ColorToHex(combined) == ColorToHex(RuneUnlock))  this.gameObject.GetComponent<RuneManager>().Unlocked = true;

        
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

    string ColorToHex(Color color)
    {
        int red = Mathf.RoundToInt(color.r * 255);
        int green = Mathf.RoundToInt(color.g * 255);
        int blue = Mathf.RoundToInt(color.b * 255);

        string hexColor = "#" + red.ToString("X2") + green.ToString("X2") + blue.ToString("X2");

        return hexColor;
    }
}
