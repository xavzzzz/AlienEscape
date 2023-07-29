using System.Collections;
using UnityEngine;

public class RaygunManager : MonoBehaviour
{
    private bool shooting;
    private bool canShootDecals = true;

    public bool Constructed, BatteryOn, EndOn, BatteryConstruct;
    public Collider Laser;

    public Transform laserOrigin;
    public float gunRange;
    public float fireRate;
    public float laserDuration;
    public Animator FinalBlowAnim;

    private FMOD.Studio.EventInstance Burn;
    private bool flag; 

    LineRenderer laserLine;
    float fireTimer;
    RaycastHit previousHit;

    void Awake()
    {
        laserLine = this.GetComponentInChildren<LineRenderer>();
        laserOrigin = laserLine.GetComponent<Transform>();
        Burn = FMODUnity.RuntimeManager.CreateInstance("event:/LaserCutter/LaserCutter_Cutting");
    }

    public void AddEnd()
    {
        EndOn = true;
    }

    public void AddBat()
    {
        BatteryOn = true;
    }

    public void CheckFullConstruct()
    {
        if(BatteryOn && EndOn)
        {
            Constructed = true;
        }
    }

    public void Shoot()
    {
        if (Constructed && BatteryConstruct) 
        { 
            //SHOOTING SOUND HERE
        shooting = true;
        }
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
                Burn.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(hit.point));
                if (canShootDecals)
                {
                    //startsoundof burn
                    if (flag == false)
                    {
                        Burn.start();
                        flag = true;
                    }

                    StartCoroutine(DoDecals(previousHit, hit));
                }
                else
                {
                    //stopburnsoundif (flag == true)
                    if (flag == true)
                    {
                        //Burn.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                        flag = false;
                    }
                    

                }
                previousHit = hit;
                var hitObj = hit.collider.gameObject;

                laserLine.SetPosition(1, hit.point);
                if (hitObj.CompareTag("LightLink"))
                {
                    FinalBlowAnim.SetBool("Explode", true);
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
        if (!shooting)
        {
            Burn.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
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
