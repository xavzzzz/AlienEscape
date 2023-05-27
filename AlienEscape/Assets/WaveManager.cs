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
}
