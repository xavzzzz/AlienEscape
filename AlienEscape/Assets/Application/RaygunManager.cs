using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RaygunManager : MonoBehaviour
{
    private bool shooting;

    public bool Constructed;
    public Collider Laser;

    public Transform laserOrigin;
    public float gunRange;
    public float fireRate;
    public float laserDuration;


    LineRenderer laserLine;
    float fireTimer;

    void Awake()
    {
        laserLine = this.GetComponentInChildren<LineRenderer>();
        laserOrigin = laserLine.GetComponent<Transform>();
    }


    public void Shoot()
    {

        shooting = true;
    }

    public void StopShoot()
    {

        shooting = false;
        laserLine.enabled = false;
    }

    public void FixedUpdate()
    {
        fireTimer += Time.deltaTime;
        if (shooting && fireTimer >= fireRate)
        {
            Debug.Log("Shhot");
            fireTimer = 0;
            laserLine.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = laserLine.gameObject.transform.position;
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, laserLine.gameObject.transform.forward, out hit, gunRange))
            {
                var hitObj = hit.collider.gameObject;
                


                laserLine.SetPosition(1, hit.point);
                if (hitObj.CompareTag("LightLink"))
                {
                    var lightRune = hitObj.GetComponent<Rune>();

                    if(!lightRune.locked)hitObj.GetComponentInParent<RuneSequencer>().TrySequence(lightRune);
                    lightRune.locked = true;

                    hitObj.GetComponent<Renderer>().material.color = Color.green;
                }
                
                    this.GetComponent<DecalPainter>().PaintDecal(hit.point, hit.normal, hit.collider);
                
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (laserLine.gameObject.transform.forward * gunRange));
            }
            StartCoroutine(ShootLaser());
        }
    }

    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
    }
}




