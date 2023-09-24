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

    private string localName = "Katie";

    private void Start()
    {

        localName = characterRandomisation.name;

    }

    public override void StartConversation()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Conversation());
    }

    private DialogueSection Conversation()
    {
        // Occupation tied to possible events.
        string occupation = "Plumber";
        Monologue sure = new Monologue(localName, "");
        Choices d = new Choices(localName, "Can I get an X Pie?", ChoiceList(Choice("Sure thing", sure)));
        Monologue fine = new Monologue(localName, "That's nice to hear.", d);
        Monologue not_fine = new Monologue(localName, "That's too bad... hope it improves!", d);
        Monologue bad = new Monologue(localName, "Sorry to hear that.", d);
        
        
        Choices b = new Choices(localName, "How are you today?", ChoiceList(Choice("Fine", fine), Choice("Not so fine...", not_fine), Choice("Bad", bad)));
        
        Monologue a = new Monologue(localName, $"Good morning, I'm {localName}.", b);
        
        return a;

    }

}