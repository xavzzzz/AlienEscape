using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public List<GameObject> Reds;
    public List<GameObject> Blues;
    public List<GameObject> Yellows;


    public void TurnRedObjects(float angle)
    {

        foreach (var r in Reds)
        {
            r.transform.Rotate(0f, angle, 0f);
        }
    }

    public void TurnBlueObjects(float angle)
    {

        foreach (var r in Blues)
        {
            r.transform.Rotate(0f, angle, 0f);
        }
    }

    public void TurnYellowObjects(float angle)
    {

        foreach (var r in Yellows)
        {
            r.transform.Rotate(0f, angle, 0f);
        }

    }
}
