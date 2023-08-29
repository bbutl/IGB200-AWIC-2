using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBurst : Event
{
    // Start is called before the first frame update
    void Start()
    {
        
        occupationList = eventManager.avaliableOccupations;
        if (ContainsOccupation(occupationList))
        {
            Debug.Log("contains");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool ContainsOccupation(List<string> list)
    {
        if (list.Contains(associatedOccupation))
        {
            return true;
        }
        else return false;
    }
    public void InitialiseEvent()
    {
        // Add check for current day and target day number
        if (ContainsOccupation(occupationList))
        {

        }
        else
        {
            return;
        }
    }
}
