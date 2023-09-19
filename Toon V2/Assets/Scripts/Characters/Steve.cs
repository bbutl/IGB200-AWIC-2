using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using static Dialogue;

public class Steve : MonoBehaviour
{
    public Cook cook;
    public CameraPan pan;
    string localName = "Steve";
    string playerName = "Player";
    public CustomerOrder order;
    public QueueController queue;
    public CharacterRandomisation characterRandomisation;
    GameObject Sarah;
    

    private void Start()
    {
        order.CreateOrder();
        Sarah = GameObject.Find("Sarah");
        
    }
    public void Update()
    {
        if (cook.PieCompleted() == true && queue.currentCharacter == 1)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(Conversation2());
        }

    }
    public void StartConversation()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Conversation());
    }
    private DialogueSection Conversation2()
    {
        Monologue b = new Monologue(localName, $"Next");
        Monologue a = new Monologue(localName, $"Thanks for the pie", b);
        return a;
    }
    private DialogueSection Conversation()
    {
        
        // Occupation tied to possible events.
        string occupation = "Plumber";
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