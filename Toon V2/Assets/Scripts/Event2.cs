using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event2 : Event
{
    // Start is called before the first frame update
    void Start()
    {
        occupationList = eventManager.avaliableOccupations;
        InitialiseEvent();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
