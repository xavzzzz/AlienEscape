using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public List<GameObject> Reds;
    public List<GameObject> Blues;
    public List<GameObject> Yellows;

    public Collider BatteryRef;


    public void CheckValidRotations()
    {



        if (Blues[0].GetComponent<TubeRotator>().rotationPos == 1 && Blues[1].GetComponent<TubeRotator>().rotationPos == 2 && Blues[2].GetComponent<TubeRotator>().rotationPos == 0)
        {
            
            if (Reds[0].GetComponent<TubeRotator>().rotationPos == 1 && Reds[1].GetComponent<TubeRotator>().rotationPos == 3 && Reds[2].GetComponent<TubeRotator>().rotationPos == 2)
            {

                if (Yellows[0].GetComponent<TubeRotator>().rotationPos == 3 && Yellows[1].GetComponent<TubeRotator>().rotationPos == 1 && Yellows[2].GetComponent<TubeRotator>().rotationPos == 3)
                {
                    BatteryRef.enabled = true;
                }
            }
        }
    }

    public void TurnRedObjects(float angle)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Objets/Object_PipeMovement", GetComponent<Transform>().position);

        foreach (var r in Reds)
        {
            if (angle > 0) {
                r.GetComponent<TubeRotator>().TurnLeft();
            }
            else { r.GetComponent<TubeRotator>().TurnRight(); }
            r.transform.Rotate(0f, angle, 0f);
        }
    }

    public void TurnBlueObjects(float angle)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Objets/Object_PipeMovement", GetComponent<Transform>().position);
        foreach (var r in Blues)
        {
            if (angle > 0)
            {
                r.GetComponent<TubeRotator>().TurnLeft();
            }
            else { r.GetComponent<TubeRotator>().TurnRight(); }
            r.transform.Rotate(0f, angle, 0f);
        }
    }

    public void TurnYellowObjects(float angle)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Objets/Object_PipeMovement", GetComponent<Transform>().position);
        foreach (var r in Yellows)
        {
            if (angle > 0)
            {
                r.GetComponent<TubeRotator>().TurnLeft();
            }
            else { r.GetComponent<TubeRotator>().TurnRight(); }
            r.transform.Rotate(0f, angle, 0f);
        }

    }
}
