using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using static Dialogue;

public class Plumber : GenericCharacter
{
    public MovementController Controller;
    public bool startGuide = false;
    public InstallPipe installPipe;
    public Cook cook;
    public QueueController queue;
    public CharacterRandomisation characterRandomisation;
    public CustomerOrder order;
    public SaveFileManagement SFM;
    public DialogueManager dManager;
    public CameraPan pan;
    public Pie p;
    public Button nextButton;
    public DayController dayController;

    private string localName = "Sarah";
    private string playerName = SaveFileManagement.saveFile.playerName;

    private void Start()
    {
        dManager.goodChoice = 0;
        dManager.badChoice = 0;
        order.CreateOrder();
        localName = characterRandomisation.name;
    }


    public void Update()
    {
        if (startGuide == true)
        {
            startGuide = false;
            
            FindObjectOfType<DialogueManager>().StartDialogue(Guide());
        }
        if (installPipe.eventComplete)
        {
            installPipe.eventComplete = false;
            EventComplete();
        }
        if (dManager.goodChoice == 1)
        {
            pan.start = false;
            dManager.goodChoice = 2;
        }
        if (dManager.goodChoice == 4)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(Finish());
            dManager.goodChoice = 5;
        }
        if (dManager.goodChoice > 6)
        {
            queue.Next();
            dManager.goodChoice = -1;

        }
        if (cook.PieCompleted() == true && queue.currentCharacter == 2 && dayController.day == 2)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(PieTalk());
        }




    }

    public override void Day2Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(D2Start());
    }
    public override void Day3Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(D3Start());
    }
    public void EventComplete()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(EventCompleted());
    }

    public DialogueSection Finish()
    {

        Monologue end = new Monologue(localName, "");
        Monologue line8 = new Monologue(localName, "Next");
        Monologue line7 = new Monologue(localName, "Bye bye.", line8);
        Monologue line6 = new Monologue(playerName, "Of course, goodbye.", line7);
        Monologue line5 = new Monologue(localName, "Well! I best be heading off, got a life to live ya know?", line6);
        Monologue line4 = new Monologue(playerName, "Noted…", line5);

        return line4;
    }
    public DialogueSection D2Start()
    {
        Controller.GoToTarget(0);
        //Monologue end = new Monologue(playerName, "Next");
        Monologue end = new Monologue(playerName, "Next");
        //Bad Choice 
        Monologue bad2 = new Monologue(localName, "Have a good one.", end);
        Monologue bad1 = new Monologue(localName, "Oh, no worries then mate.\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nSad..", bad2);

        //Good Choice
        Monologue good29 = new Monologue(playerName, "I always wondered who installed fire hydrants…", end);
        //Plumber Leaves
        Monologue good28 = new Monologue(localName, "Have a good one!", good29);
        Monologue good27 = new Monologue(localName, "Thank you for helping me out, I’ll catch ya around \nsome time.", good28);
        Monologue good26 = new Monologue(localName, "Anyway! I need to get to work.", good27);
        Monologue good25 = new Monologue(localName, "For sure.\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nLaugh..", good26);
        Monologue good24 = new Monologue(playerName, "Always a plus.", good25);
        Monologue good23 = new Monologue(localName, "It also pays well.", good24);
        Monologue good22 = new Monologue(localName, "Then there’s sanitary plumbers, water plumbers and more \nso it’s quite a nice field to dive into.", good23);
        Monologue good21 = new Monologue(localName, "such as plumbers for fire services which do things like \nfire hydrants and the sprinklers I mentioned.", good22);
        Monologue good19 = new Monologue(localName, "It does go into more specific fields,", good21);
        Monologue good18 = new Monologue(localName, "Yeah I guess it is quite broad.", good19);
        Monologue good17 = new Monologue(playerName, "Oh wow, I didn’t realise it was that broad.", good18);
        Monologue good16 = new Monologue(localName, "but yes, also toilets.\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nLaugh..", good17);
        Monologue good15 = new Monologue(localName, "Things like fire sprinklers are also a plumber's job…", good16);
        Monologue good14 = new Monologue(localName, "Any system that requires water I also maintain.", good15);
        Monologue good13 = new Monologue(localName, "Whether it’s for drainage or gas, that’s me.", good14);
        Monologue good12 = new Monologue(localName, "I’m in charge of installing, repairing and maintaining \npipes of any kind.", good13);
        Monologue good11 = new Monologue(localName, "It’s a bit more than just that.", good12);
        Monologue good10 = new Monologue(playerName, "So you do toilets and things like that?", good11);
        Monologue good9 = new Monologue(localName, "So not the most glorious job but hey, it pays very well.", good10);
        Monologue good8 = new Monologue(localName, "I’m a plumber.", good9);
        Monologue good7 = new Monologue(playerName, "I’m trying to learn a little bit myself.", good8);
        Monologue good6 = new Monologue(playerName, "No worries, what do you do in construction?", good7);
        Monologue good5 = new Monologue(localName, "You’re a lifesaver.", good6);
        Monologue good4 = new Monologue(localName, "Oh cheers mate.", good5);
        Monologue good3 = new Monologue(playerName, "Well good news, the centre of town is about two blocks \nto the right when you walk out the door.", good4);
        Monologue good2 = new Monologue(localName, "Which way would that happen to be?", good3);
        Monologue good1 = new Monologue(localName, "I’m looking for a construction site in the centre of town,", good2);
        Choices line3 = new Choices(localName, "Reckon you could send me the right way?", ChoiceList(Choice("I’ll try, where are you headed?", good1), Choice("I’m horrible with directions, sorry.", bad1)));
        Monologue line2 = new Monologue(localName, "I’m just a bit lost since I only got here last night for work.", line3);
        Monologue line1 = new Monologue(localName, "Oh, sorry mate.", line2);
        Monologue line0 = new Monologue(playerName, "Sorry I’m not open.", line1);
        return line0;

    }

    public DialogueSection Conversation2()
    {

        Monologue end = new Monologue(localName, "");
        Monologue startEvent = new Monologue(localName, $"Start", end);
        Monologue respones2a = new Monologue(localName, $"Lets get to it then.", startEvent);

        Choices response1a = new Choices(localName, $"Im a plumber so I can give you a hand with fixing that up, on the house.", ChoiceList(Choice("Yes please!", respones2a)));
        Choices sink1 = new Choices(localName, $"I noticed that your sink back there doesnt seem to be working.", ChoiceList(Choice("Yeah the store has seen better days.", response1a)));
        return sink1;
    }
    public DialogueSection Guide()
    {
        nextButton.interactable = false;
        Monologue guide5 = new Monologue(localName, $"Now we just need to fit the new pipe in and solder it with the welder.");
        Monologue guide4 = new Monologue(localName, $"Now that we have cut the pipe, remove the pipe.", guide5);
        Monologue guide3 = new Monologue(localName, $"Secondly, you will need to fit the pipe cutter to the pipe.", guide4);
        Monologue guide2 = new Monologue(localName, "", guide3);
        Monologue guide1 = new Monologue(localName, $"Firstly, {SaveFileManagement.saveFile.playerName} make sure the water supply is switched off.", guide2);
        return guide1;
    }
    public DialogueSection PieTalk()
    {
        Monologue end = new Monologue(localName, "");

        Monologue good = new Monologue(localName, "Good.", end);




        //Pie Check
        Monologue pie1 = new Monologue();
        Monologue pie2 = new Monologue();
        Monologue pie3 = new Monologue();



        if (p.filling == "Beef Filling")
        {
            pie1 = new Monologue(localName, "Hmm… I’d like some vege next time I think but it’s still delicious.", good);
        }
        else
        {
            pie2 = new Monologue(localName, "Keep up the good work.", good);
            pie1 = new Monologue(localName, "Definitely an upgrade.", pie2);

        }
        //Monologue line3 = new Monologue(localName, "Now that sounds fantastic, reckon I could try one?", pie1);
        Monologue line2 = new Monologue(localName, "Mmmmmm", pie1);
        Monologue line1 = new Monologue(playerName, "What do you think?", line2);

        return line1;
    }

    public DialogueSection EventCompleted()
    {
        nextButton.interactable = true;
        startGuide = false;


        Monologue line10 = new Monologue();
        Monologue line9 = new Monologue();
        Monologue line8 = new Monologue();
        Monologue line7 = new Monologue();
        Monologue line6 = new Monologue(localName, "");
        Monologue line5 = new Monologue(playerName, "Good.", line6);
        Monologue line4 = new Monologue(playerName, "For sure! Consider it a thanks for helping.", line5);
        Monologue line3 = new Monologue(localName, "Now that sounds fantastic, reckon I could try one?", line4);
        Monologue line2 = new Monologue(playerName, "This is fantastic, thank you. I can now clean vegetables for the pies.", line3);
        Monologue line1 = new Monologue(localName, "There ya’ go mate. Good as new.", line2);

        return line1;
    }
    public DialogueSection D3Start()
    {



        Monologue line16 = new Monologue();

        Monologue line15 = new Monologue();
        Monologue line14 = new Monologue();
        Monologue line13 = new Monologue();


        Monologue line12 = new Monologue(localName, "");

        Monologue line11 = new Monologue(localName, "Next", line12);
        Monologue line10 = new Monologue(localName, "Have a good one.", line11);
        Monologue line9 = new Monologue(localName, "No worries then mate. I won’t be a bother.", line10);

        Monologue line8 = new Monologue(playerName, "");

        Monologue eventstart = new Monologue(playerName, "Start", line8);
        Monologue line7 = new Monologue(playerName, "Yes! Right this way.", eventstart);
        Monologue line6 = new Monologue(localName, "Yep! Do you have any pipes or waterworks that need looking at?", line7);
        Monologue line5 = new Monologue(playerName, "Are you sure? I would love all the help I can get! You’re a plumber \nright?", line6);
        Monologue line4 = new Monologue(localName, "Did you need any help?", line5);

        Monologue line3 = new Monologue(localName, "Oh? Now that you mention it, this place is a little beat up.", line4);
        Choices line2 = new Choices(localName, "Sorry mate! I know you’re not open. I actually came to ask for your \nopening hours?", ChoiceList(Choice("I actually need to renovate first.", line3), Choice("I’m not sure, I haven’t thought about it.", line9)));
        Monologue line1 = new Monologue(playerName, "Hello I-", line2);
        return line1;
    }
}