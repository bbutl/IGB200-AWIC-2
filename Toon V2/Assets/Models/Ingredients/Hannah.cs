using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Dialogue;


public class Hannah : GenericCharacter
{
    public Pie p;
    public DialogueManager dManager;
    public Cook cook;
    public QueueController queue;
    public CameraPan pan;
    public bool pieMade = false;


    string localname = "Hannah";
    string playerName = "Player";
    // Start is called before the first frame update
    void Start()
    {
        dManager.goodChoice = 0;
        dManager.badChoice = 0;

    }

    public override void Day4Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(D4Start());
    }


    // Update is called once per frame
    void Update()
    {
        if (dManager.goodChoice == 1)
        {
            pan.start = false;
            dManager.goodChoice = 2;
        }

        if (cook.PieCompleted() == true && queue.currentCharacter == 1)
        {
            pieMade = true;
            FindObjectOfType<DialogueManager>().StartDialogue(Pietalk());
        }
    }


    public DialogueSection Pietalk()
    {
        Monologue end = new Monologue(localname, "Next");

        Monologue good = new Monologue(localname, "Good.", end);

        Monologue line19 = new Monologue();
        Monologue line18 = new Monologue();
        Monologue line17 = new Monologue();
        Monologue line16 = new Monologue(playerName, "Bye bye!");
        Monologue line15 = new Monologue(localname, "Goodbye!", line16);
        Monologue line14 = new Monologue(localname, "That would be quite ironic haha!\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nLaugh..", line15);

        Monologue line13 = new Monologue(localname, "I should be going now though, otherwise I’ll get in trouble from \nmy manager.", line14);
        Monologue line12 = new Monologue(localname, "Not without your help. Thank you.", line13);
        Monologue line11 = new Monologue(playerName, "I think you just found the solution to your problem.", line12);
        Monologue line10 = new Monologue(localname, "Pit stop pies sound perfect, and on a Wednesday is great. Right in \nthe middle of the week.", line11);
        Monologue line9 = new Monologue(playerName, "Come have a pit stop here at Pie Stop every Wednesday perhaps?", line10);
        Monologue line8 = new Monologue(playerName, "That sounds fantastic.", line9);
        Monologue line7 = new Monologue(localname, "Maybe I can add in free pie lunches for them from this place.", line8);
        Monologue line6 = new Monologue(localname, "Oh! I have an idea. You were talking about motivating the \nconstruction workers earlier.", line7);
        Monologue line5 = new Monologue(localname, "Hahaha!\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nLaugh..", line6);
        Monologue line4 = new Monologue(playerName, "Mushrooms… equal… success…", line5);
        Monologue line3 = new Monologue(playerName, "You got it, boss. I’ll write this down.", line4);
        //Pie Check
        Monologue pie1 = new Monologue();
        Monologue pie2 = new Monologue();
        Monologue pie3 = new Monologue();



        if (p.filling == "Mushrooms")
        {
            pie1 = new Monologue(localname, "That hit the spot. Thank you so much.", line3);
        }
        else
        {
            
            pie1 = new Monologue(localname, "Hmm… it’s good, but mushrooms would have been a great addition.", line3);

        }
        //Monologue line3 = new Monologue(localName, "Now that sounds fantastic, reckon I could try one?", pie1);
        Monologue line2 = new Monologue(localname, "Mmmmmm", pie1);
        Monologue line1 = new Monologue(playerName, "Here you go.", line2);

        return line1;
    }
    public DialogueSection D4Start()
    {

        Monologue line41 = new Monologue(localname, "Next");
        Monologue line40 = new Monologue(playerName, "Have a good day, come back next week!", line41);
        Monologue line39 = new Monologue(localname, "My apologies, I’ll get out of your hair right away.", line40);

        Monologue line38 = new Monologue(localname, "");
        Monologue line37 = new Monologue(localname, "Good.", line38);
        Monologue line36 = new Monologue(localname, "Anything with mushrooms. I love mushrooms.", line37);
        Monologue line35 = new Monologue(playerName, "Perfect, what pie would you like?", line36);
        Monologue line34 = new Monologue(localname, "Deal!\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nSmile..", line35);
        Monologue line33 = new Monologue(playerName, "One condition, promise to be here on Monday.", line34);
        Monologue line32 = new Monologue(localname, "I’m intrigued…", line33);
        Monologue line31 = new Monologue(playerName, "Maybe, giving one of my pies a taste test could spike your energy?", line32);
        Monologue line30 = new Monologue(playerName, "Hahaha. Sounds rough for you managers huh?", line31);
        Monologue line29 = new Monologue(localname, "Just please, listen to us when we manage the projects.", line30);
        Monologue line28 = new Monologue(localname, "A lot of times it’s fellow colleagues, mentors or managers who can \ngive you a helping hand.", line29);
        Monologue line27 = new Monologue(localname, "Knowing who to go to when you’re looking for work or opportunities \nis key to success.", line28);
        Monologue line26 = new Monologue(localname, "Of course, networking is one of the most important aspects of \nengaging in construction.", line27);
        Monologue line25 = new Monologue(playerName, "Fantastic! I’m happy to make connections, especially in the \nconstruction industry.", line26);
        Monologue line24 = new Monologue(localname, "At this rate, I certainly will. You’ve been very friendly to me so \nI’ll put it in my calendar.", line25);
        Monologue line23 = new Monologue(playerName, "This coming Monday is the grand opening. You are welcome to come \nby if you’d wish.", line24);
        Monologue line22 = new Monologue(localname, "That’s great, when is the store set up?\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nSmile..", line23);
        Monologue line21 = new Monologue(localname, "It’s okay. I don’t mind meeting new people as I set the store up.", line22);
        Monologue line20 = new Monologue(localname, "Really? That makes me feel slightly less stupid.\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nLaugh..", line21);
        Choices line19 = new Choices(localname, "I am so sorry! I’m literally rambling about work issues to you in \nyour closed store!", ChoiceList(Choice("It happens more than you’d think.", line20), Choice("I was quite confused when you came in, I won’t lie.", line39)));
        Monologue line18 = new Monologue(localname, "OH!", line19);
        Monologue line17 = new Monologue(playerName, "Sort of, this store is currently closed for renovations but it will \nopen soon and it is, indeed, a pie store.", line18);
        Monologue line16 = new Monologue(localname, "You said you’re a pie maker?", line17);
        Monologue line15 = new Monologue(localname, "I’ll figure something out. Sorry for just complaining to you.", line16);
        Monologue line14 = new Monologue(localname, "I try my best but nothing works", line15);
        Monologue line13 = new Monologue(playerName, "I see, well can’t you motivate them somehow?", line14);
        Monologue line12 = new Monologue(localname, "We’re going to fall behind schedule if they keep slacking off.", line13);
        Monologue line11 = new Monologue(localname, "Some of the people just don’t listen.", line12);
        Monologue line10 = new Monologue(localname, "It’s quite stressful. The job is a great managerial position but,", line11);
        Monologue line9 = new Monologue(playerName, "Why? Isn’t it interesting?", line10);
        Monologue line8 = new Monologue(localname, "I’m a site manager for the construction site down the road. I wish \nI wasn’t", line9);
        Monologue line7 = new Monologue(playerName, "Are you a manager of some kind?", line8);
        Monologue line6 = new Monologue(playerName, "Well as a soon-to-be pie maker, I probably can’t do that.", line7);
        Monologue line5 = new Monologue(localname, "Unless you know how to manage construction workers then I’m \nafraid not.", line6);
        Monologue line4 = new Monologue(playerName, "Hello Hannah, do you need help?", line5);
        Monologue line3 = new Monologue(localname, "Hi there, my apologies. I’m Hannah.", line4);
        Monologue line2 = new Monologue(playerName, "Oh, hello… I’m sorry what?", line3);
        Monologue line1 = new Monologue(localname, "Why would she do that?!", line2);

        return line1;
    }

}
