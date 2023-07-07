using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneSequencer : MonoBehaviour
{
    public List<Rune> Runes;
    public int MaxSequence;


    private int counter;


    public void Awake()
    {
        counter = 0;
    }

    public void TrySequence(Rune a)
    {
        
        if (a.OrderInSequence-1 == counter){

            if(counter+1 == MaxSequence) { Debug.Log("T TRO FORT SALE RACISTE"); counter = 0; return;  }

            Debug.Log("Can continue");
            counter++;
        }
        else
        {
            Debug.Log("T UN GROS NUL"); counter = 0;
        }
    }
}
