using System.Collections;
using UnityEngine;

public class RaygunManager : MonoBehaviour
{
    private bool shooting;
    private bool canShootDecals = true;

    public bool Constructed;
    public Collider Laser;

    public Transform laserOrigin;
    public float gunRange;
    public float fireRate;
    public float laserDuration;

    LineRenderer laserLine;
    float fireTimer;
    RaycastHit previousHit;

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
        canShootDecals = false;
    }

    public void Update()
    {
        fireTimer += Time.deltaTime;
        if (shooting && fireTimer >= fireRate)
        {
            fireTimer = 0;
            laserLine.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = laserLine.gameObject.transform.position;
            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, laserLine.gameObject.transform.forward, out hit, gunRange))
            {
                if(canShootDecals)StartCoroutine(DoDecals(previousHit, hit));
                previousHit = hit;
                var hitObj = hit.collider.gameObject;

                laserLine.SetPosition(1, hit.point);
                if (hitObj.CompareTag("LightLink"))
                {
                    var lightRune = hitObj.GetComponent<Rune>();

                    if (!lightRune.locked) hitObj.GetComponentInParent<RuneSequencer>().TrySequence(lightRune);
                    lightRune.locked = true;

                    hitObj.GetComponent<Renderer>().material.color = Color.green;
                }

                canShootDecals = true;
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

    IEnumerator DoDecals(RaycastHit previousHit, RaycastHit hit)
    {
        float duration = 0.05f;
        int numSteps = 10;
        float stepDelay = duration / numSteps;

        for (int i = 0; i < numSteps; i++)
        {
            float lerpAmount = (float)i / (numSteps - 1);
            Vector3 decalPosition = Vector3.Lerp(previousHit.point, hit.point, lerpAmount);

            this.GetComponent<DecalPainter>().PaintDecal(decalPosition, hit.normal, hit.collider);

            yield return new WaitForSeconds(stepDelay);
        }

        

    }
}
