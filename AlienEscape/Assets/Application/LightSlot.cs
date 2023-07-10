using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LightSlot : MonoBehaviour
{
    public XRSocketInteractor Interactor;
    public LightManager Manager;

    public void Awake()
    {
       Interactor = GetComponent<XRSocketInteractor>();
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        
        // Store the attached GameObject when an Interactable is grabbed
        Manager.LightReticles.Add(args.interactable.gameObject.GetComponent<LightReticle>());
        Manager.UpdateLight();
    }

    public void OnSelectExited(SelectExitEventArgs args)
    {
        // Store the attached GameObject when an Interactable is grabbed
        Manager.LightReticles.Remove(args.interactable.gameObject.GetComponent<LightReticle>());
        Manager.UpdateLight();
    }
}
