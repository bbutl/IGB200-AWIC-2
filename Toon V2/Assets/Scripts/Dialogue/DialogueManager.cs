using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Dialogue;
using Unity.VisualScripting;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public DialogueSection currentSection;

    [Header("Text Components")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI contentsText;
    public TextMeshProUGUI playerName;
    public char[] contentsArray;
    private float typingSpeed = 0.03f;
    [Header("Dialogue Choice")]
    public GameObject proceedConverstaionObject;
    public GameObject dialogueChoiceObject;
    public Transform parentChoicesTo;

    [Header("Fade")]
    public float canvasGroupFadeTime = 5F;
    bool canvasGroupDisplaying;
    
    public CanvasGroup dialogueCanvasGroup;
    public QueueController queue;
    public PipeBurst pipeBurst;
    public Plumber plumber;
    public CameraPan cameraPan;
    public CustomerOrder customerOrder;
    public GameObject currentCharacter;

    public int badChoice = 0;
    public int goodChoice = 0;

    //public GameObject DialogueBox;
   // public Sprite playerImage;
   // public Sprite otherImage;
    private void Start()
    {
        InitalizePanel();
    }

    private void InitalizePanel()
    {
        dialogueCanvasGroup.alpha = 0F;
    }

    private void Update()
    {
        //ChangeBox();
        UpdateCanvasOpacity();
        PrepareForOptionDisplay();
        DisplayDialogueOptions();
        TextCommands();
        if(cameraPan.hasOrderded == true)
        {
            cameraPan.hasOrderded = false;
        }
        
    }

    public void TextCommands()
    {
        currentCharacter = GameObject.FindGameObjectWithTag("Character");
        
        if (contentsText.text == "Next")
        {
            
            EndDialogue();
            queue.Next();
        }
        if (contentsText.text == "Start")
        {
            ProceedToNext();
            plumber.startGuide = true;
            pipeBurst.eventStarted = false;
        }
        if (contentsText.text == "Order")
        {
            cameraPan.hasOrderded = true;
            ProceedToNext();
            EndDialogue();
        }
        if(contentsText.text == "Bad.")
        {
            badChoice += 1;
            ProceedToNext();
        }
        if (contentsText.text == "Good.")
        {
            goodChoice += 1;
            ProceedToNext();
        }
        
    }
    private void UpdateCanvasOpacity()
    {
        dialogueCanvasGroup.alpha = Mathf.Lerp(dialogueCanvasGroup.alpha, canvasGroupDisplaying ? 1F : 0F, Time.deltaTime * canvasGroupFadeTime);
    }

    private void PrepareForOptionDisplay()
    {
        if (optionsBeenDisplayed)
        {
            return;
        }

        if (typeof(Choices).IsInstanceOfType(currentSection))
        {
            ResetDisplayOptionsFlags();
        }
    }

    public void StartDialogue(DialogueSection start)
    {
        
        canvasGroupDisplaying = true;
        ClearAllOptions();
        currentSection = start;
        DisplayDialogue();
    }

    public void ProceedToNext()
    {
        if (displayingChoices)
        {
            return;
        }

        if (currentSection.GetNextSection() != null)
        {
            currentSection = currentSection.GetNextSection();
            DisplayDialogue();
        }
        else
        {
            EndDialogue();
        }
    }

    public void DisplayDialogue()
    {
        if (currentSection == null)
        {
            EndDialogue();
            return;
        }

        bool isMonologue = typeof(Monologue).IsInstanceOfType(currentSection);
        StopAllCoroutines();
        proceedConverstaionObject.SetActive(isMonologue);

        ClearAllOptions();

        DisplayText();
    }

    private void DisplayText()
    {
        // Implement scrolling text effect so text doesnt appear all at once
        optionsBeenDisplayed = false;

        nameText.text = $"{currentSection.GetSpeakerName()}:";
        
        contentsArray = currentSection.GetSpeechContents().ToCharArray();


        StartCoroutine(DisplayLine(currentSection.GetSpeechContents()));
    }
    
    private IEnumerator DisplayLine(string line)
    {
        contentsText.text = "";
        foreach (char c in line.ToCharArray())
        {
            contentsText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void EndDialogue()
    {
        customerOrder.CreateOrder();
        if (cameraPan.start == true && cameraPan.hasOrderded == true )
        {
            
            cameraPan.start = false;
        }
        canvasGroupDisplaying = false;
        ClearAllOptions();
        
    }

    private void ClearAllOptions()
    {
        GameObject[] currentDialogueOptions = GameObject.FindGameObjectsWithTag("DialogueChoice");

        foreach (var entry in currentDialogueOptions)
        {
            Destroy(entry);
        }
    }

    int indexOfCurrentChoice = 0;
    [HideInInspector] public bool displayingChoices;
    private bool optionsBeenDisplayed;

    public void ResetDisplayOptionsFlags()
    {
        optionsBeenDisplayed = true;
        displayingChoices = true;
        indexOfCurrentChoice = 0;
    }
    /*
    public void ChangeBox()
    {
        if(currentSection.GetSpeakerName() == "Player")
        {
            Image playerImage = DialogueBox.GetComponent<Image>();

        }
    }
    */
    public void DisplayDialogueOptions()
    {
        if(!typeof(Choices).IsInstanceOfType(currentSection))
        {
            return;
        }

        Choices choices = (Choices)currentSection;

        if (displayingChoices)
        {
            if(indexOfCurrentChoice < choices.choices.Count)
            {
                Tuple<string, DialogueSection> option = choices.choices[indexOfCurrentChoice];

                GameObject s = Instantiate(dialogueChoiceObject, Vector3.zero, Quaternion.identity);
                s.transform.SetParent(parentChoicesTo);
                s.GetComponent<RectTransform>().localScale = Vector3.one;

                DialogueOptionDisplay optionDisplayBehavior = s.GetComponent<DialogueOptionDisplay>();

                optionDisplayBehavior.SetDisplay(option.Item1, option.Item2);

                indexOfCurrentChoice++;
            }
            else
            {
                displayingChoices = false;
            }
        }
    }
}