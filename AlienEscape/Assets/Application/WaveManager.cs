using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public LineRenderer myLineRenderer;
    public int points; 
    public float amplitude = 1;
    public float frequency = 1;
    public float movementSpeed = 1;
    public Vector2 Limit = new Vector2(0, 1);

    public void Awake()
    {
        myLineRenderer = GetComponent<LineRenderer>();
    }

    public void Draw()
    {

        float Start =  Limit.x;
        float Tau  = 2 * Mathf.PI;
        float Finish = Limit.y;
        myLineRenderer.positionCount = points;

        for (int currentPoint = 0; currentPoint < points; currentPoint++) {

            float progress = (float)currentPoint / (points - 1); 
            float x = Mathf.Lerp(Start, Finish, progress);
            float y = amplitude * Mathf.Sin((Tau * frequency * x) + (Time.timeSinceLevelLoad* movementSpeed)); 
            
            myLineRenderer.SetPosition(currentPoint, new Vector3(x, y, 0));
        }

    }

    public void FixedUpdate() {
        Draw();
    }

    public void EditAmpli(float newAmp) {

        amplitude = newAmp;
    }

    public void EditFrequency(float newFreq)
    {

        frequency = newFreq;
    }


    private bool isLerping = false;
    private float originalAmplitude;
    public float lerpDuration = 1.0f; // The duration of the lerp in seconds

    public void StartLerpToZero()
    {
        if (isLerping) return; // Don't start a new lerp if one is already in progress

        originalAmplitude = amplitude;
        StartCoroutine(LerpToZero());
    }

    private IEnumerator LerpToZero()
    {
        isLerping = true;

        float elapsedTime = 0f;

        while (elapsedTime < lerpDuration)
        {
            float t = elapsedTime / lerpDuration;
            amplitude = Mathf.Lerp(originalAmplitude, 0f, t);

            // Redraw the wave with the updated amplitude
            Draw();

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the amplitude is set to exactly zero at the end
        amplitude = 0f;

        // Redraw the wave with the final amplitude (zero)
        Draw();

        isLerping = false;
    }
}

