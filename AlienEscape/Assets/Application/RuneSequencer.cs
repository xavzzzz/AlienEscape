using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneSequencer : MonoBehaviour
{
    public List<Rune> Runes;
    public int MaxSequence;


    private int counter;
    private int tries;


    public void Awake()
    {

        counter = 1;
    }

    public void TrySequence(Rune a)
    {
        tries++;

        if (tries >= MaxSequence) { Debug.Log("Loser let's reset"); }


        if (a.OrderInSequence == counter || a.OrderInSequence == MaxSequence-counter+1)
        {

            if (counter == MaxSequence) { Debug.Log("T TRO FORT SALE RACISTE"); return; } 
            Debug.Log("Can continue");
            counter++;
        }
        else
        {
            Debug.Log("Already Lost");
        }
    }
}
