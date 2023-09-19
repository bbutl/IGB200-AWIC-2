using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Dialogue;

public class Sarah : MonoBehaviour
{

    public Button eventButton;
    public Cook cook;
    public CameraPan pan;
    public QueueController queue;
    string localName = "Sarah";
    string playerName = "Player";
    public CharacterRandomisation characterRandomisation;

    public CameraPan cam;
    private void Start()
    {
        
        FindObjectOfType<DialogueManager>().StartDialogue(Conversation());
        
    }

    public void Update()
    {
        if (cook.PieCompleted() == true && queue.order[queue.currentCharacter] == 1)
        {
            pan.start = true;
            FindObjectOfType<DialogueManager>().StartDialogue(Conversation2());
        }

    }

    public void StartConversation()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Conversation());
    }

    public DialogueSection Conversation()
    {
        localName = characterRandomisation.name;


        Monologue sure = new Monologue(localName, "Thank you.");
        Choices d = new Choices(localName, "Can I get a steak Pie?", ChoiceList(Choice("Sure thing", sure)));
        Monologue fine = new Monologue(localName, "That's nice to hear.", d);
        Monologue not_fine = new Monologue(localName, "That's too bad... hope it improves!", d);
        Monologue bad = new Monologue(localName, "Sorry to hear that.", d);
        
        
        Choices b = new Choices(localName, "How are you today?", ChoiceList(Choice("Fine", fine), Choice("Not so fine...", not_fine), Choice("Bad", bad)));
        
        Monologue a = new Monologue(localName, $"Good morning, I'm {localName}.", b);
        //pBurst.StartEvent();
        return a;

    }
    public DialogueSection Conversation2()
    {
        eventButton.gameObject.SetActive(true);
        Monologue respones2a = new Monologue(localName, $"Lets get to it then.");
        
        Choices response1a = new Choices(localName, $"Im a plumber so I can give you a hand with fixing that up, on the house.", ChoiceList(Choice("Yes please!", respones2a)));
        Choices sink1 = new Choices(localName, $"I noticed that your sink back there doesnt seem to be working.", ChoiceList(Choice("Yeah the store has seen better days.", response1a)));
        return sink1;
    }
}