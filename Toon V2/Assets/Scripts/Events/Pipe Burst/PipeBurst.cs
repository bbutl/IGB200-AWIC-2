using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Dialogue;

public class PipeBurst : Event
{

    public bool stepComplete = false;
    private int stepNumber = 1;
    public DialogueManager d;
    public Camera cam;
    public Camera mainCam;
    public Button nextButton;
    public DraggableObject drag;
    public bool waterOn = true;


    Vector3 direction = new Vector3(1, 0, 0);


    [Header("Pipe Event Objects")]
    public GameObject welder;
    public GameObject holder;
    public GameObject waterSupply;
    public GameObject newPipe;

    void Awake()
    {
        
        drag = gameObject.GetComponent<DraggableObject>();
        drag.enabled = false;
        
    }
    void Start()
    {
        nextButton = nextButton.GetComponent<Button>();
        occupationList = eventManager.avaliableOccupations;
        StartEvent();
    }
    void Update()
    {
        StepCompleted();
    }
   
    
    public DialogueSection Guide()
    {
        string localName = "Sarah";
        string playerName = "Player";
        Monologue guide2 = new Monologue(localName, $" Secondly,");

        Monologue guide1 = new Monologue(localName, $"Firstly, {playerName} make sure the water supply is switched off.", guide2);
        return guide1;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Holder" )
        {
            Debug.Log($"{other.gameObject.name}");
            //Goes around the pipe before welding

            //Make holder non draggable & set in place
            Destroy(other.gameObject);
            GameObject h = Instantiate(holder, gameObject.transform.position + new Vector3(0.2f, 0, 0.4f), Quaternion.Euler(0,90,0));
            

            stepNumber += 1;
            //Next monologue
            d.ProceedToNext();
        }
        if (other.gameObject.name == "Welder" && stepNumber == 2)
        {
            stepNumber += 1;
            // Cut old pipe and drag out
            drag.enabled = true;
            
        }
        if (other.gameObject.name == "New Pipe" && stepNumber == 3)
        {

            //Drag new pipe into place after old pipe has been removed
        }


    }
    public void StartEvent()
    {
        if (InitialiseEvent())
        {
            cam.transform.position -= new Vector3(0, 1, 0);
            // nextButton.enabled = false;
            mainCam.transform.position = cam.transform.position;
            mainCam.transform.rotation = cam.transform.rotation;
            
            
            Debug.Log("Event Started");
            InstantiateEventObjects();
            FindObjectOfType<DialogueManager>().StartDialogue(Guide());


        }
    }
    //Instantiate the objects required for the event
    public void InstantiateEventObjects()
    {
        
        Instantiate(welder, cam.transform.position + new Vector3(-0.9f, 0.3f, -0.8f), Quaternion.identity);
        Instantiate(holder, cam.transform.position + new Vector3(-0.9f, 0, -0.8f), Quaternion.identity);
        
    }
    public bool StepCompleted()
    {
        if (stepComplete)
        {
            d.ProceedToNext();
            stepComplete = false;
        }
        return stepComplete;
    }
}
