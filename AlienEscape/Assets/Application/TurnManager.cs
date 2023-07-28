using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public List<GameObject> Reds;
    public List<GameObject> Blues;
    public List<GameObject> Yellows;


    public void CheckValidRotations()
    {



        if ((Blues[0].transform.rotation.y == -180) && Blues[1].transform.rotation.y == 90.038 && Blues[2].transform.rotation.y == -90.038)
        {
            Debug.Log("winnnnner");
            if (Reds[0].transform.rotation.y == -180 && Reds[1].transform.rotation.y == 0 && Reds[2].transform.rotation.y == 90.038)
            {

                if (Yellows[0].transform.rotation.y == 0 && Yellows[1].transform.rotation.y == -180 && Yellows[2].transform.rotation.y == 0)
                {
                    Debug.Log("winnnnner");
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
