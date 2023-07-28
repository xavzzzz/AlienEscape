using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeRotator : MonoBehaviour
{

        public int rotationPos;

        public void TurnLeft()
        {
        if (rotationPos == 0) rotationPos = 3;
        else if (rotationPos == 3) rotationPos--;
        else if (rotationPos == 2) rotationPos--;
        else if (rotationPos == 1) rotationPos--;
    }

        public void TurnRight()
        {
        if (rotationPos == 3) rotationPos = 0;
        else if (rotationPos == 0) rotationPos++;
        else if (rotationPos == 2) rotationPos++;
        else if (rotationPos == 1) rotationPos++;
    }
    

}
