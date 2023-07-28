using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class BatteriesManager : MonoBehaviour
{
    public bool One, Two, Three, Four, Complete;

    public GameObject GunRef;

    public void CheckComplete()
    {
        if (One && Two && Three && Four) GunRef.GetComponent<RaygunManager>().BatteryConstruct = true;
    }

    public void SetOne(bool x)
    {
        One = x;
        CheckComplete();
    }

    public void SetTwo(bool x)
    {
        Two =  x;
        CheckComplete();
    }
    public void SetThree(bool x)
    {
        Three = x;
        CheckComplete();
    }
    public void SetFour(bool x)
    {
        Four = x;
        CheckComplete();
    }



}
