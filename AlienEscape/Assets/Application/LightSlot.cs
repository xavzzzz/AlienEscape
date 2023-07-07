using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LightSlot : MonoBehaviour
{
    public XRSocketInteractor Interactor;
    public GameObject CurrentReticle;

    public void Awake()
    {
       Interactor = GetComponent<XRSocketInteractor>();
    }

}
