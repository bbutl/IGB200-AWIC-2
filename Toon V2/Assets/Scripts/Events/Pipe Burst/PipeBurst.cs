using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Dialogue;

public class PipeBurst : Event
{

    public bool stepComplete = false;
    public int stepNumber = 1;
    public DialogueManager d;
    public Camera cam;
    public Camera mainCam;
    public Button panButton;
    public DraggableObject drag;
    public bool waterOn = true;
    public bool pipeRemoved = false;
    public Transform originalPos;
    Vector3 stopMove;
    private bool eventStarted = false;
    


    [Header("Pipe Event Objects")]
    public GameObject welder;
    public GameObject holder;
    public GameObject waterSupply;
    public GameObject newPipe;

    void Awake()
    { 
        stopMove = gameObject.transform.position;
        originalPos = mainCam.transform;
    }
    void Start()
    {
        panButton = panButton.GetComponent<Button>();
        
        occupationList = eventManager.avaliableOccupations;
        
    }
    void Update()
    {
        StartEvent();
        if (stepNumber < 2) { gameObject.transform.position = stopMove; }
        
        StepCompleted();
    }
   
    
    public DialogueSection Guide()
    {
        string localName = "Sarah";
        string playerName = "Player";
        Monologue guide4 = new Monologue(localName, $"Now we just need to fit the new pipe in and solder it with the welder.");
        Monologue guide3 = new Monologue(localName,$"Now that we have cut the pipe, remove the pipe.", guide4 );
        Monologue guide2 = new Monologue(localName, $" Secondly, you will need to fit the pipe cutter to the pipe.", guide3);

        Monologue guide1 = new Monologue(localName, $"Firstly, {playerName} make sure the water supply is switched off.", guide2);
        return guide1;
    }

    public void OnTriggerExit(Collider other)
    {
        //Removing old pipe
        if (other.gameObject.name == "Sink" && pipeRemoved == false)
        {
            pipeRemoved = true;
            stepNumber += 1;
            d.ProceedToNext();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.name == "Holder(Clone)" )
        {
            
            //Goes around the pipe before welding

            //Make holder non draggable & set in place
            Destroy(other.gameObject);
            GameObject h = Instantiate(holder, gameObject.transform.position + new Vector3(0.2f, 0, 0.7f), Quaternion.Euler(0,90,0));
            h.gameObject.GetComponent<BoxCollider>().enabled = false;

            stepNumber += 1;
            Instantiate(newPipe, cam.transform.position + new Vector3(-2, -0.1f, 3), Quaternion.Euler(90, 0, 0));
            //Next monologue
            d.ProceedToNext();
        }
        
        


    }
    public void StartEvent()
    {
        if (InitialiseEvent() && eventStarted == false)
        {
            eventStarted = true;
            cam.transform.position -= new Vector3(0, 1, 0);
            
            mainCam.transform.position = cam.transform.position;
            mainCam.transform.rotation = cam.transform.rotation;
            
            
            Debug.Log("Event Started");
            InstantiateEventObjects();
            panButton.gameObject.SetActive(false);
            FindObjectOfType<DialogueManager>().StartDialogue(Guide());


        }
    }
    //Instantiate the objects required for the event
    public void InstantiateEventObjects()
    {
        
        Instantiate(welder, cam.transform.position + new Vector3(-1.3f, 0.3f, -1.1f), Quaternion.identity);
        Instantiate(holder, cam.transform.position + new Vector3(-1.3f, -0.1f, -1.1f), Quaternion.identity);
        
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
