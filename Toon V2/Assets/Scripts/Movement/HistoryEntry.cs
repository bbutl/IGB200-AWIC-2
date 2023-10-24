using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HistoryEntry : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI contentText;
    public GameObject self;

    public void ChangeContent(string name, string content)
    {
        nameText.text = name;
        contentText.text = content;
    }

    public void ShowEntry(int yPos)
    {
        self.SetActive(true);
        self.transform.position = new Vector3(400, yPos, 0);
    }

    public void HideEntry()
    {
        self.SetActive(true);
    }
}
