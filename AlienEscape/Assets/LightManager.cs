using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public List<Collider> LightSlots;
    public Light LightSource;
    public LightReticle Manipulated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLight() {

        LightSource.color = CombineColors(LightSource.color, Manipulated.ReticleColor);
        Debug.Log(Manipulated.ReticleColor);
    }

    public void RemoveLight()
    { 
        LightSource.color -= Manipulated.ReticleColor;
        Debug.Log("RemoveLight");
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
}
