using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day : MonoBehaviour
{
    // TO DO add getter setter
    public int currentDay;
    public bool nextDay = false;
    
    void Awake()
    {
        currentDay = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextDay)
        {
            NextDay();
        }
    }
    public int NextDay()
    {
        currentDay += 1;
        nextDay = false;
        return currentDay;
        
    }
}
