using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Dialogue;
using UnityEngine.UI;

public class Kate : GenericCharacter
{

    public bool startGuide = false;
    public Button nextButton;
    public Cook cook;
    public QueueController queue;
    public CharacterRandomisation characterRandomisation;
    public CustomerOrder order;

    private string localName;
    string playerName = "Player";
    private void Start()
    {
        order.CreateOrder();
        localName = characterRandomisation.name;

    }
    public void Update()
    {
        if (startGuide == true)
        {
            //nextButton.gameObject.SetActive(false);
            nextButton.gameObject.GetComponent<Button>().enabled = false;
        }
        //Second Conversation
        if (cook.PieCompleted() == true && queue.currentCharacter == 2)
        {


            FindObjectOfType<DialogueManager>().StartDialogue(Conversation2());
        }
        //Third Conversation
        if (startGuide == true)
        {
            startGuide = false;
            FindObjectOfType<DialogueManager>().StartDialogue(Guide());
        }
    }

    public override void StartConversation()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Conversation());
    }

    public DialogueSection Conversation()
    {
        Monologue order1 = new Monologue(localName, "Order");
        Monologue sure = new Monologue(localName, "Thank you.", order1);
        Choices d = new Choices(localName, $"Can I get a Pie with {order.orderFilling}?", ChoiceList(Choice("Sure thing", sure)));
        Monologue fine = new Monologue(localName, "That's nice to hear.", d);
        Monologue not_fine = new Monologue(localName, "That's too bad... hope it improves!", d);
        Monologue bad = new Monologue(localName, "Sorry to hear that.", d);


        Choices b = new Choices(localName, "How are you today?", ChoiceList(Choice("Fine", fine), Choice("Not so fine...", not_fine), Choice("Bad", bad)));

        Monologue a = new Monologue(localName, $"Good morning, I'm {localName}.", b);

        return a;

    }
    public DialogueSection Conversation2()
    {
        Monologue startEvent = new Monologue(localName, $"Start");
        Monologue respones2a = new Monologue(localName, $"Lets get to it then.", startEvent);

        Choices response1a = new Choices(localName, $"Im a plumber so I can give you a hand with fixing that up, on the house.", ChoiceList(Choice("Yes please!", respones2a)));
        Choices sink1 = new Choices(localName, $"I noticed that your sink back there doesnt seem to be working.", ChoiceList(Choice("Yeah the store has seen better days.", response1a)));
        return sink1;
    }
    public DialogueSection Guide()
    {

        Monologue guide5 = new Monologue(localName, $"Now we just need to fit the new pipe in and solder it with the welder.");
        Monologue guide4 = new Monologue(localName, $"Now that we have cut the pipe, remove the pipe.", guide5);
        Monologue guide3 = new Monologue(localName, $"Secondly, you will need to fit the pipe cutter to the pipe.", guide4);
        Monologue guide2 = new Monologue(localName, "", guide3);
        Monologue guide1 = new Monologue(localName, $"Firstly, {playerName} make sure the water supply is switched off.", guide2);
        return guide1;
    }

}