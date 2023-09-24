using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayController : MonoBehaviour
{
    public int day = 0;
    public int finalDay = 7;
    public QueueController[] dayQueues;
    public TextMeshProUGUI dayText;

    private string[] dayNames = new string[] { "Day 1", "Day 2", "Day 3", "Day 4", "Day 5", "Day 6", "Day 7", "Day 8" };

    void Start()
    {
        UpdateText();
    }

    void Update()
    {
        
    }

    private void UpdateText()
    {
        dayText.text = dayNames[day];
    }

    public void NextDay()
    {
        day += 1;
        UpdateText();
    }
}
