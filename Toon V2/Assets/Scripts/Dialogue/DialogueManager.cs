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
    [Header("Events")]
    public PipeBurst pipeBurst;
    public Plumber plumber;
    public FuseBox fuseBox;

    public CameraPan cameraPan;
    public CustomerOrder customerOrder;
    public GameObject currentCharacter;

    public int badChoice = 0;
    public int goodChoice = 0;

    [SerializeField] MovementController[] customers;
    public List<string> historyNames = new List<string>();
    public List<string> historyContent = new List<string>();
    [SerializeField] TextMeshProUGUI textSpeedText;
    [SerializeField] TextMeshProUGUI autoText;
    private bool isTyping = false;

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

        if (Input.GetKeyDown("space"))
        {
            ProceedToNext();
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
        if (contentsText.text == "Fuse")
        {
            ProceedToNext();
            fuseBox.eventStarted = true;
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
        if (!isTyping)
        {
            if (displayingChoices)
            {
                return;
            }

            if (currentSection.GetNextSection() != null)
            {

                customers[0].StartTalking();
                currentSection = currentSection.GetNextSection();
                //customers[SaveFileManagement.saveDataList.currentCustomer].StartTalking();
                DisplayDialogue();
            }
            else
            {
                customers[0].StopTalking();
                EndDialogue();
            }
        }
        else
        {
            isTyping = false;
        }
    }

    public void DisplayDialogue()
    {
        if (currentSection == null)
        {
            //customers[SaveFileManagement.saveDataList.currentCustomer].StopTalking();
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

        historyNames.Add($"{currentSection.GetSpeakerName()}:");
        
        contentsArray = currentSection.GetSpeechContents().ToCharArray();

        historyContent.Add($"{currentSection.GetSpeechContents()}");

        StartCoroutine(DisplayLine(currentSection.GetSpeechContents()));
    }
    
    private IEnumerator DisplayLine(string line)
    {
        if (typingSpeed == 0.0f)
        {
            contentsText.text = line;
        }
        else
        {
            isTyping = true;

            contentsText.text = "";
            foreach (char c in line.ToCharArray())
            {
                if (isTyping)
                {
                    contentsText.text += c;
                    yield return new WaitForSeconds(typingSpeed);
                }
                else
                {
                    contentsText.text = line;
                    break;
                }
            }

            if (SaveFileManagement.saveGame.otherOptions[0] == 1)
            {
                ProceedToNext();
            }

            isTyping = false;
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

    public void ChangeTextSpeed(int speed)
    {
        typingSpeed = new float[] { 0.06f, 0.03f, 0.01f }[speed];
        textSpeedText.text = $"Text Speed ({new string[] {"Fast", "Medium", "Slow"}[speed]})";
    }

    public void ToggleAuto()
    {
        if (SaveFileManagement.saveGame.otherOptions[0] == 1)
        {
            SaveFileManagement.saveGame.otherOptions[0] = 0;
            autoText.text = "";
        }
        else
        {
            SaveFileManagement.saveGame.otherOptions[0] = 1;
            autoText.text = "Auto";
            //ProceedToNext();
        }
    }
}