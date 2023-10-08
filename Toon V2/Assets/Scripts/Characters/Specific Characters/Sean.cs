using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Dialogue;


public class Sean : MonoBehaviour
{
    public DialogueManager dManager;
    public Cook cook;
    public QueueController queue;
    public GameObject pie;
    string localname = "Sean";
    string playerName = "Player";
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        FindObjectOfType<DialogueManager>().StartDialogue(Conversation());
    }

    // Update is called once per frame
    void Update()
    {
        pie = GameObject.FindGameObjectWithTag("Pie");
       
        if (cook.PieCompleted() == true && queue.currentCharacter == 0)
        {
            if(dManager.goodChoice == 1 && dManager.badChoice == 2)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(ConversationGood3());
            }
            else
            {
                FindObjectOfType<DialogueManager>().StartDialogue(Conversation2());
            }
            
        }
        if(dManager.badChoice == 1 && pie == null)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(ConversationBad());
            dManager.badChoice += 1;
        }
        if (dManager.badChoice == 3)
        {
            if(pie != null)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(ConversationBad2());
            }
            else
            {
                FindObjectOfType<DialogueManager>().StartDialogue(ConversationBad3());
            }
            
            dManager.badChoice += 1;
        }
        if(dManager.goodChoice == 2)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(ConversationGood2());
            dManager.goodChoice += 1;
        }
        if (dManager.goodChoice == 3 && pie != null)
        {
            //FindObjectOfType<DialogueManager>().StartDialogue(ConversationGood2());
            //dManager.goodChoice += 1;
        }
    }

    public DialogueSection Conversation()
    {
        Monologue endBad = new Monologue(localname, "");
        // Sad React
        Monologue notToday = new Monologue(localname, "Bad.", endBad);

        Monologue end = new Monologue(localname, "");
        Monologue good = new Monologue(localname, "Good.", end);
        Monologue ofCourse = new Monologue(localname, "Order", good);

        Choices line18 = new Choices(localname, "That sounds amazing, reckon you could cook one up for me?", ChoiceList(Choice("Of course! Consider it a thanks.", ofCourse), 
            Choice("I’m not sure if I want to cook anything today.", notToday)));
        Monologue line17 = new Monologue(playerName, "I can make a classic meat pie but that’s it right now.", line18);
        Monologue line16 = new Monologue(playerName, "Yes actually!", line17);
        Monologue line15 = new Monologue(localname, "Is there anything here that still works?", line16);
        Monologue line14 = new Monologue(localname, "So tell me...", line15);
        // laugh react
        Monologue line13 = new Monologue(localname, "Ah yes, eleven years. Time flies by when you’re retired!", line14);
        Monologue line12 = new Monologue(playerName, "After you told me that this place hadn’t seen anyone in eleven years \n  I decided it’s time for a makeover.", line13);
        Monologue line11 = new Monologue(playerName, "Yes, there is an official reopening next Monday.", line12);
        Monologue line10 = new Monologue(localname, "I heard there was a grand reopening soon?", line11);
        // laugh react
        Monologue line9 = new Monologue(localname, "Forty-five years in this industry does a number on you when you \n get to my age.", line10);
        Monologue line8 = new Monologue(localname, "Don’t even mention it.", line9);
        Monologue line7 = new Monologue(playerName, "I wouldn’t have a job if it weren’t for you selling this place to me.", line8);
        Monologue line6 = new Monologue(playerName, "You’re welcome here anytime.", line7);
        Monologue line5 = new Monologue(playerName, "Oh, of course!", line6);
        Monologue line4 = new Monologue(localname, "Decided I’d pop in and say hi before I finally hand over the \n store to you.", line5);
        Monologue line3 = new Monologue(localname, "I’m going good mate.", line4);
        Monologue line2 = new Monologue(playerName, "Sean! How are you?", line3);
        Monologue line1 = new Monologue(playerName, "Oh, good morning, I’m not actually open- oh!", line2);

        return line1;
    }
    public DialogueSection Conversation2()
    {
        Monologue bad = new Monologue(localname, "Bad.");
        Monologue good= new Monologue(localname, "Good.");
        Choices line9 = new Choices(localname, "Don’t ya think?", ChoiceList(Choice("Yeah that’s a great idea.", good), Choice("Aw I’m not sure.", bad)));
        Monologue line8 = new Monologue(localname, "I’m sure a pie store like this would be a hot spot once fully opened.", line9);
        Monologue line7 = new Monologue(localname, "Maybe you could find someone to help out with fixing this old place.", line8);
        Monologue line6 = new Monologue(playerName, "Yeah, Awicville has really grown busy the past couple weeks.", line7);
        Monologue line5 = new Monologue(localname, "Have you heard about all the construction going on?", line6);
        Monologue line4 = new Monologue(playerName, "...", line5);
        Monologue line3 = new Monologue(playerName, "I’m glad you enjoyed it.", line4 );
        Monologue line2 = new Monologue(localname, "That is wonderful mate, don’t change a thing.", line3);
        Monologue line1 = new Monologue(playerName, "Here you go, enjoy and let me know what I could improve.", line2);
        return line1;
    }
    public DialogueSection ConversationBad()
    {
        Monologue end2 = new Monologue(localname, "");
        Monologue end = new Monologue(localname, "Order", end2);
        Monologue good = new Monologue(localname, "Good.", end);

        Monologue bad = new Monologue(localname, "Bad.", end);
        Choices line9 = new Choices(localname, "Would you like me to show you some tips and tricks I’ve picked up?", ChoiceList(Choice("That would be wonderful!", good), Choice("Maybe some other time.", bad)));
        Monologue line8 = new Monologue(localname, "Oh mate! Don’t even stress!", line9 );
        Monologue line7 = new Monologue(playerName, "That’s why I didn’t want to cook just yet.", line8 );
        Monologue line6 = new Monologue(playerName, "I was going to learn a bit more before officially opening.", line7);
        Monologue line5 = new Monologue(playerName, "Yeah but I don’t think I’m any good at it.", line6 );
        Monologue line4 = new Monologue(localname, "Do you?", line5);
        Monologue line3 = new Monologue(localname, "As long as you know how to make a pie already, then you’ll be fine.", line4);
        Monologue line2 = new Monologue(localname, "I won’t be a bother on your first day.", line3);
        //Sad React
        Monologue line1 = new Monologue(localname, "Ah no worries.", line2);
        return line1;
    }
    public DialogueSection ConversationBad2()
    {
        dManager.goodChoice = 0;
        Monologue end2 = new Monologue(localname, "Next");
        Monologue end = new Monologue(playerName, "See ya later Sean.", end2);
        Monologue line8 = new Monologue(localname, "Good luck with the renovations, I’ll catch ya around some time.", end);
        Monologue line7 = new Monologue(localname, "Anyway, I best be setting off.", line8);
        Monologue line6 = new Monologue(playerName, "I hope so too.", line7);
        Monologue line5 = new Monologue(localname, "All I can definitively say is that it’s going to be busy so I hope \n you’re ready.", line6);
        Monologue line4 = new Monologue(localname, "I’m sure you’ll be fine.", line5);
        Monologue line3 = new Monologue(localname, "Don’t be worried about that mate.", line4);
        Monologue line2 = new Monologue(playerName, "And what if the store failed?", line3);
        Monologue line1 = new Monologue(playerName, "That sounds like a lot of pressure and work.", line2);
        return line1;
    }
    public DialogueSection ConversationBad3()
    {
        Monologue end = new Monologue(localname, "Next");
        Monologue line3 = new Monologue(localname, "I’ll catch ya around.", end);
        Monologue line2 = new Monologue(localname, "I’d best be heading off then, good luck with the renovations!", line3);
        Monologue line1 = new Monologue(localname, "Ah alright mate.", line2);
        return line1;
    }
    public DialogueSection ConversationGood2()
    {

        Monologue end7 = new Monologue(localname, "Next");
        Monologue line6 = new Monologue(localname, "Good luck with your renovations, I’ll catch ya around.", end7);
        Monologue line5 = new Monologue(localname, "Anyhow, I best be heading off.", line6);
        Monologue line4 = new Monologue(localname, "No worries mate. Anything to help out a fellow pie store owner.", line5);
        Monologue line3 = new Monologue(playerName, "Thanks for the idea Sean.", line4);
        Monologue line2 = new Monologue(playerName, "And once everything’s open I can certainly see this place \n taking off.", line3);
        Monologue line1 = new Monologue(playerName, "I don’t know anything about construction so perhaps some \n networking would help.", line2);
        return line1;
    }
    public DialogueSection ConversationGood3()
    {
        dManager.goodChoice = 0;
        Monologue end2 = new Monologue(localname, "Next");
        Monologue end = new Monologue(playerName, "See ya later Sean.", end2);
        Monologue line16 = new Monologue(localname, "Good luck with the renovations, I’ll catch ya around some time!", end);
        Monologue line15 = new Monologue(localname, "Anyay, I'll be heading off.", line16 );
        //Laugh
        Monologue line14 = new Monologue(localname, "Well with pies like that, I’m sure they’d flock to help you open!", line15 );
        Monologue line13 = new Monologue(playerName, "Maybe I can find some people to help me with the renovations \nsince I know nothing about construction.", line14);
        Monologue line12 = new Monologue(playerName, "Oh yeah for sure.", line13);
        Monologue line11 = new Monologue(localname, "I’m sure a pie store like this would be a hot spot once fully opened.", line12);
        Monologue line10 = new Monologue(localname, "Maybe you could find someone to help out with fixing this old place.", line11);
        Monologue line9 = new Monologue(playerName, "Yeah, Awicville has really grown busy the past couple weeks.", line10);
        Monologue line8 = new Monologue(localname, "Have you heard about all the construction going on?", line9);
        Monologue line7 = new Monologue(localname, "...", line8);
        Monologue line6 = new Monologue(localname, "Oh cheers mate.", line7);
        Monologue line5 = new Monologue(playerName, "Well you certainly are welcome here anytime.", line6);
        //Laugh
        Monologue line4 = new Monologue(localname, "I think I should become your official taste tester if you keep \n making them like this. ", line5 );
        Monologue line3 = new Monologue(localname, "For a newcomer you sure can make a great pie.", line4);
        Monologue line2 = new Monologue(localname, "Fantastic!", line3);
        
        Monologue line1 = new Monologue(playerName, "How’s that?", line2);
        
        return line1;
    }
}

