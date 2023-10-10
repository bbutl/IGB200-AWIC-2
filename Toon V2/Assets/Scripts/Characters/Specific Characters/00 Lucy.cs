using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Dialogue;
using UnityEngine.UI;

public class Lucy : GenericCharacter
{
    public bool startGuide = false;
    public Button nextButton;
    public Cook cook;
    public QueueController queue;
    public CharacterRandomisation characterRandomisation;
    public CustomerOrder order;

    private string localName = "Lucy";

    private void Awake()
    {
        order.CreateOrder();
        localName = characterRandomisation.name;
    }
    public void Update()
    {
        if (cook.PieCompleted() == true && queue.currentCharacter == 0)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(LucyThanks());
        }

    }
    public override void StartConversation()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Conversation());
    }

    private DialogueSection LucyThanks()
    {
        Monologue b = new Monologue(localName, $"Next");
        Monologue a = new Monologue(localName, $"Thanks for the pie", b);
        return a;
    }
    private DialogueSection Conversation()
    {
     
        
        Monologue order1 = new Monologue(localName, "Order");
        Monologue sure = new Monologue(localName, "Thanks", order1);
        Choices d = new Choices(localName, $"Can I get a Pie with {order.orderFilling}?", ChoiceList(Choice("Sure thing", sure)));
        Monologue fine = new Monologue(localName, "That's nice to hear.", d);
        Monologue not_fine = new Monologue(localName, "That's too bad... hope it improves!", d);
        Monologue bad = new Monologue(localName, "Sorry to hear that.", d);
        
        
        Choices b = new Choices(localName, "How are you today?", ChoiceList(Choice("Fine", fine), Choice("Not so fine...", not_fine), Choice("Bad", bad)));
        
        Monologue a = new Monologue(localName, $"Good morning, I'm {localName}.", b);
        
        return a;

    }

}