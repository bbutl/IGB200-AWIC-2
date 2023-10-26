using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StateController : MonoBehaviour
{
    [SerializeField] private GameObject saveStateIcon;
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private TextMeshProUGUI timeText;

    public void UpdateSaveStateSlot(int day, int hour, int minute, bool isEmpty)
    {
        if (isEmpty)
        {
            saveStateIcon.SetActive(false);
            dayText.text = "";
            timeText.text = "";
        }
        else
        {
            saveStateIcon.SetActive(true);
            dayText.text = $"Day {day}";
            if (minute < 10)
            {
                timeText.text = $"{hour % 12}:0{minute}";
            }
            else
            {
                timeText.text = $"{hour % 12}:{minute}";
            }
        }
    }
}
