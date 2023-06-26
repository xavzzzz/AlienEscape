using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public List<Collider> LightSlots;
    public Light LightSource;
    public LightReticle Manipulated;
    public List<LightReticle> LightReticles;
    private Color originalColor;

    private void Awake()
    {
        originalColor = Color.clear;
        LightSource.color = originalColor;

    }

    public void AddLight()
    {
        if (Manipulated != null)
        {
            this.GetComponent<LightManager>().LightReticles.Add(Manipulated);

            LightSource.color = CombineColors(LightSource.color, Manipulated.Color);
            Debug.Log(Manipulated.Color);

            Manipulated = null;
        }
    }

    public void RemoveLight()
    {
        if (Manipulated != null)
        {
            this.GetComponent<LightManager>().LightReticles.Remove(Manipulated);

            new WaitForSeconds(1f);
            LightSource.color = originalColor;
            Color[] colors = new Color[LightReticles.Count + 1];

            int x = 0;
            foreach (LightReticle i in LightReticles)
            {
                colors.SetValue(i.Color, x);
                x++;
                Debug.Log("For");
            }

            colors.SetValue(LightSource.color, x);
            LightSource.color = CombineColors(colors);
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
