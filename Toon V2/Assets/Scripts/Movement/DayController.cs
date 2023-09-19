using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayController : MonoBehaviour
{
    public int day = 0;
    public int finalDay = 7;
    public QueueController[] dayQueues;

    private string[] dayNames = new string[] { "Day 1", "Day 2", "Day 3", "Day 4", "Day 5", "Day 6", "Day 7", "Day 8" };

    void Start()
    {
    }

    void Update()
    {
        
    }
}
