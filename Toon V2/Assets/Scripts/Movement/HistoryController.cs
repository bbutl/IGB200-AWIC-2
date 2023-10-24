using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryController : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private HistoryEntry[] entries;

    public void GenerateHistory()
    {
        for (int entry = 0; entry < dialogueManager.historyNames.Count; entry++)
        {
            entries[entry].ChangeContent(dialogueManager.historyNames[entry], dialogueManager.historyContent[entry]);
            entries[entry].ShowEntry(entry * 120);
        }
    }
}
