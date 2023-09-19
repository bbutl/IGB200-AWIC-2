using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBurstOld : Event
{
    Vector3 direction = new Vector3(1, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
        occupationList = eventManager.avaliableOccupations;
        //If conditions for event to occur are met
        if (InitialiseEvent())
        {
            Debug.Log("Event Started");
            this.gameObject.transform.Rotate(direction, 25);
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
