using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Dialogue;

public class Sarah : MonoBehaviour
{
    public GameObject eventObject;
    public PipeBurst pBurst;
    

    public CameraPan cam;
    private void Start()
    {
        pBurst = eventObject.GetComponent<PipeBurst>();
        //FindObjectOfType<DialogueManager>().StartDialogue(Conversation());
        
    }

    public DialogueSection Conversation()
    {
        string localName = "Sarah";
        string playerName = "Player";

        
        Monologue sure = new Monologue(localName, "");
        Choices d = new Choices(localName, "Can I get an X Pie?", ChoiceList(Choice("Sure thing", sure)));
        Monologue fine = new Monologue(localName, "That's nice to hear.", d);
        Monologue not_fine = new Monologue(localName, "That's too bad... hope it improves!", d);
        Monologue bad = new Monologue(localName, "Sorry to hear that.", d);
        
        
        Choices b = new Choices(localName, "How are you today?", ChoiceList(Choice("Fine", fine), Choice("Not so fine...", not_fine), Choice("Bad", bad)));
        
        Monologue a = new Monologue(localName, $"Good morning, I'm {localName}.", b);
        //pBurst.StartEvent();
        return a;

    }

}