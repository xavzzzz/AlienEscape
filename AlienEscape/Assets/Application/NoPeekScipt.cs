using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoPeekScipt : MonoBehaviour
{
    [SerializeField] LayerMask collisionLayer;
    [SerializeField] float fadeSpeed;
    [SerializeField] float sphereCheckSize = .15f;

    private Material cameraFadeMat;
    private bool isCameraFadeOut = false;

    private void Awake() => cameraFadeMat = GetComponent<Renderer>().material;

    private void Update()
    {
        if(Physics.CheckSphere(transform.position, sphereCheckSize, collisionLayer, QueryTriggerInteraction.Ignore))
        {
            CameraFade(1f);

        }
        else 
        {
            
            
            CameraFade(0f);
        }
    }

    public void CameraFade(float targetAlpha) 
    {
        var fadeValue = Mathf.MoveTowards(cameraFadeMat.GetFloat("_AlphaValue"), targetAlpha, Time.deltaTime * fadeSpeed);
        cameraFadeMat.SetFloat("_AlphaValue", fadeValue);
        //cameraFadeMat.SetColor("_OverlayColor", Color.white);
        if (fadeValue <= 0.01f) isCameraFadeOut = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, sphereCheckSize);
    }
}