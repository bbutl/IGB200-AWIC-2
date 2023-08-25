using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Dialogue;

public class DialogueOptionDisplay : MonoBehaviour
{
    public TextMeshProUGUI contentText;
    public DialogueSection leadsTo;

    private DialogueManager manager;

    private void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
    }
    // Display text contents on TMPro GUI
    public void SetDisplay(string optionText, DialogueSection nextDialogueSection)
    {
        contentText.text = optionText;
        leadsTo = nextDialogueSection;
    }

    public void ProceedOnClick()
    {
        if (manager.displayingChoices)
        {
            return;
        }

        manager.currentSection = leadsTo;
        manager.DisplayDialogue();
    }
}