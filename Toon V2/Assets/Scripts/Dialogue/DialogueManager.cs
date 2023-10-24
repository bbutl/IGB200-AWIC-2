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
    private string pName = "Player:";
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
    public Animator animator;

    [Header("Fade")]
    public float canvasGroupFadeTime = 5F;
    bool canvasGroupDisplaying;
    private bool hasMoved = false;
    public CanvasGroup dialogueCanvasGroup;
    public QueueController queue;
    [Header("Events")]
    public PipeBurst pipeBurst;
    public Plumber plumber;
    public FuseBox fuseBox;

    public CameraPan cameraPan;
    public CustomerOrder customerOrder;
    public GameObject currentCharacter;
    public Camera newsCam;
    public Image newsImage;
    public int badChoice = 0;
    public int goodChoice = 0;

   

    public string fullText;
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
        currentCharacter = GameObject.FindGameObjectWithTag("Character");
        animator = currentCharacter.GetComponent<Animator>();
       
        UpdateCanvasOpacity();
        PrepareForOptionDisplay();
        DisplayDialogueOptions();
        TextCommands();
        NewsControl();
        if(cameraPan.hasOrderded == true)
        {
            cameraPan.hasOrderded = false;
        }

       
        if (contentsText.text != fullText && nameText.text != pName)
                                          
        {
            animator.SetBool("isTalking", true);
            
        }
        else
        {
            
            animator.SetBool("isTalking", false);
        }
    }

    public void NewsControl()
    {
       
        if (currentCharacter.name == "James")
        {
            if (newsImage.enabled != true)
            {
                Camera.main.transform.position = newsCam.transform.position;
                Camera.main.transform.rotation = newsCam.transform.rotation;
                newsImage.enabled = true;
            }
        } 
        else if (currentCharacter.name != "James" && !hasMoved)
        {
            Camera.main.transform.position = new Vector3(-66.677002f, 4.4000001f, 3.56999993f);
            Camera.main.transform.rotation = Quaternion.Euler(0, 90, 0);
            newsImage.enabled = false;
            hasMoved = true;
        }
    }
    public void TextCommands()
    {
        currentCharacter = GameObject.FindGameObjectWithTag("Character");
        
       
        if (fullText == "Next")
        {
            
            EndDialogue();
            queue.Next();
        }
        if (fullText == "Start")
        {
            ProceedToNext();
            plumber.startGuide = true;
            pipeBurst.eventStarted = false;
        }
        if (fullText == "Fuse")
        {
            ProceedToNext();
            fuseBox.eventStarted = true;
        }
            if (fullText == "Order")
        {
            cameraPan.hasOrderded = true;
            ProceedToNext();
            EndDialogue();
        }
        if(fullText == "Bad.")
        {
            badChoice += 1;
            ProceedToNext();
        }
        if (fullText == "Good.")
        {
            goodChoice += 1;
            ProceedToNext();
        }
        if(fullText == "Mmmmmm")
        {
            animator.SetBool("isTaking", true);
            Invoke("PlayTalk", 3);
            
        }
        
        else
        {
            animator.SetBool("isTaking", false);
        }
        
    }
    public void PlayTalk()
    {
        animator.SetBool("isTalking", true);
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
        StartCoroutine(DisplayLine(currentSection.GetSpeechContents()));
        
        fullText = currentSection.GetSpeechContents();

        optionsBeenDisplayed = false;

        nameText.text = $"{currentSection.GetSpeakerName()}:";
        
        contentsArray = currentSection.GetSpeechContents().ToCharArray();


        
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