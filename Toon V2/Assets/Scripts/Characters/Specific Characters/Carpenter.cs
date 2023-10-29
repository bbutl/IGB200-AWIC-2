using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using static Dialogue;

public class Carpenter : GenericCharacter
{

    public CharacterRandomisation characterRandomisation;
    string localname = "Sean";
    string playerName = "Player";
    public Bench bench;
    public DialogueManager dManager;
    public CameraPan pan;
    public Pie p;
    public QueueController queue;
    public Cook cook;
    public DayController dayController;
    // Start is called before the first frame update
    void Start()
    {
        dManager.goodChoice = 0;
        dManager.badChoice = 0;
        localname = characterRandomisation.name;

    }
    public override void Day2Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(D2Start());
    }
    public override void Day3Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(D3Start());
    }

    // Update is called once per frame
    void Update()
    {
        if (bench.benchFinish)
        {
            bench.benchFinish = false;
            FindObjectOfType<DialogueManager>().StartDialogue(BenchFinished());
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
    public DialogueSection PieTalk()
    {





        Monologue end = new Monologue(localname, "");
        Monologue good = new Monologue(localname, "Good.", end);
        //Pie Check
        Monologue pie1 = new Monologue();
        Monologue pie2 = new Monologue();
        Monologue pie3 = new Monologue();



        if (p.filling == "Beef Filling")
        {
            pie1 = new Monologue(localname, "Hmm… I’d like some vege next time I think but it’s still delicious.", good);
        }
        else
        {
            pie2 = new Monologue(localname, "Keep up the good work.", good);
            pie1 = new Monologue(localname, "Definitely an upgrade.", pie2);

        }
        //Monologue line3 = new Monologue(localName, "Now that sounds fantastic, reckon I could try one?", pie1);
        Monologue line2 = new Monologue(localname, "Mmmmmm", pie1);
        Monologue line1 = new Monologue(playerName, "What do you think?", line2);

        return line1;
    }
    public DialogueSection Finish()
    {

        Monologue end = new Monologue(localname, "");
        Monologue line8 = new Monologue(localname, "Next");
        Monologue line7 = new Monologue(localname, "Bye bye.", line8);
        Monologue line6 = new Monologue(playerName, "Of course, goodbye.", line7);
        Monologue line5 = new Monologue(localname, "Well! I best be heading off, got a life to live ya know?", line6);
        Monologue line4 = new Monologue(playerName, "Noted…", line5);

        return line4;
    }
    public DialogueSection BenchFinished()
    {
        Monologue lin7 = new Monologue(localname, "");
        Monologue line6 = new Monologue(localname, "Good.", lin7);
        Monologue line5 = new Monologue(playerName, "Yes actually! Here, I’ll make you a pie as a thanks.", line6);
        Monologue line4 = new Monologue(localname, "Oh yeah? Have you got any veggies here now?", line5);
        Monologue line3 = new Monologue(playerName, "Which means I can make new pies.", line4);
        Monologue line2 = new Monologue(playerName, "Thank you for helping out. Now I can put vegetables on the counter \nwithout worrying about any gross stuff getting anywhere.", line3);
        Monologue line1 = new Monologue(localname, "There, that should now be up to health and safety standards.", line2);

        return line1;
    }
    public DialogueSection D3Start()
    {
        Monologue line14 = new Monologue(localname, "");

        Monologue line13 = new Monologue(localname, "Next", line14);
        Monologue line12 = new Monologue(localname, "Have a good one.", line13);
        Monologue line11 = new Monologue(localname, "No worries then mate. I won’t be a bother.", line12);

        Monologue line10 = new Monologue(localname, "");
        Monologue line9 = new Monologue(localname, "Carpent", line10);
        Monologue line8 = new Monologue(localname, "That’s no good, let’s sort this out then.", line9);
        Monologue line7 = new Monologue(playerName, "Yeah… I think it’s rotting.", line8);
        Monologue line6 = new Monologue(localname, "Yep, that’s me. This countertop looks rough.", line7);
        Monologue line5 = new Monologue(playerName, "That would be fantastic, you’re a carpenter right?", line6);
        Monologue line4 = new Monologue(localname, "Did you need any help?", line5);

        Monologue line3 = new Monologue(localname, "Oh? Now that you mention it, this place is a little beat up.", line4);
        Choices line2 = new Choices(localname, "Sorry mate! I know you’re not open. I actually came to ask for your \nopening hours?", ChoiceList(Choice("I actually need to renovate first.", line3), Choice("I’m not sure, I haven’t thought about it.", line11)));
        Monologue line1 = new Monologue(playerName, "Hello I-", line2);

        return line1;
    }
    public DialogueSection D2Start()
    {
        Monologue end = new Monologue(playerName, "Next");

        Monologue bad2 = new Monologue(localname, "Have a good one.", end);
        Monologue bad1 = new Monologue(localname, "Oh, no worries then mate.\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nSad..", bad2);

        Monologue line22 = new Monologue(playerName, "Maybe I should try and make a nightstand sometime…", end);
        Monologue line21 = new Monologue(playerName, "Have a good one!", line22);
        Monologue line20 = new Monologue(localname, "Anyway! I need to get to work. Thank you for helping me out, I’ll \ncatch ya around some time.", line21);
        Monologue line19 = new Monologue(localname, "It never gets old mate. A trade as old as time.", line20);
        Monologue line18 = new Monologue(playerName, "I see, that’s quite a nice trade then. You get to see your work come \nto life in front of you.", line19);
        Monologue line17 = new Monologue(localname, "But the moment he tries to fit some beams into a roof, he may \nstruggle. It’s just not his area of expertise.", line18);
        Monologue line16 = new Monologue(localname, "He can make the most boring piece of wood turn into the most \nbreathtaking nightstand you’ll ever see.", line17);
        Monologue line15 = new Monologue(localname, "However, my friend is a cabinet maker so he only builds furniture \nand he’s really good at it.", line16);
        Monologue line14 = new Monologue(localname, "I’m what’s called a framer, so I install the framework for buildings \nbefore they throw on the walls and roof.", line15);
        Monologue line13 = new Monologue(localname, "No, definitely not. There are different types of carpenters,", line14);
        Monologue line12 = new Monologue(playerName, "Is it only for buildings?", line13);
        Monologue line11 = new Monologue(localname, "Simply put, it’s my job to install and maintain the timber.", line12);
        Monologue line10 = new Monologue(localname, "You wouldn’t want to fall through your own floor or have a roof\n flop onto your head, now would ya?", line11);

        Monologue line9 = new Monologue(localname, "Anything from beams in a roof to making sure the wooden supports\n underneath a building’s floor don’t rot away.", line10);
        Monologue line8 = new Monologue(localname, "It’s about shaping and preparing any wooden components of a \nconstruction project.", line9);
        Monologue line7 = new Monologue(localname, "You could say that.", line8);
        Monologue line6 = new Monologue(playerName, "Oh very nice. So is that just carving things from wood?", line7);

        Monologue line5 = new Monologue(localname, "I’m a carpenter.", line6);
        Monologue line4 = new Monologue(playerName, "No worries, what do you do in construction? I’m trying to learn a \nlittle bit myself.", line5);
        Monologue line3 = new Monologue(localname, "Oh cheers mate, you’re a lifesaver.", line4);
        Monologue line2 = new Monologue(playerName, "Well good news, the centre of town is about two blocks to the right \nwhen you walk out the door.", line3);
        Monologue line1 = new Monologue(localname, "I’m looking for a construction site in the centre of town, which way \nwould that happen to be?", line2);

        Choices start2 = new Choices(localname, "Reckon you could send me the right way?", ChoiceList(Choice("I’ll try, where are you headed?", line1), Choice("I’m horrible with directions, sorry.", bad1)));
        Monologue start1 = new Monologue(localname, "Oh, sorry mate.", start2);
        return start1;
    }
    public DialogueSection D2Good()
    {
        Monologue end = new Monologue(playerName, "Next");

        Monologue line22 = new Monologue(playerName, "Maybe I should try and make a nightstand sometime…", end);
        Monologue line21 = new Monologue(playerName, "Have a good one!", line22);
        Monologue line20 = new Monologue(localname, "Anyway! I need to get to work. Thank you for helping me out, I’ll \ncatch ya around some time.", line21);
        Monologue line19 = new Monologue(localname, "It never gets old mate. A trade as old as time.", line20);
        Monologue line18 = new Monologue(playerName, "I see, that’s quite a nice trade then. You get to see your work come \nto life in front of you.", line19);
        Monologue line17 = new Monologue(localname, "But the moment he tries to fit some beams into a roof, he may \nstruggle. It’s just not his area of expertise.", line18);
        Monologue line16 = new Monologue(localname, "He can make the most boring piece of wood turn into the most \nbreathtaking nightstand you’ll ever see.", line17);
        Monologue line15 = new Monologue(localname, "However, my friend is a cabinet maker so he only builds furniture \nand he’s really good at it.", line16);
        Monologue line14 = new Monologue(localname, "I’m what’s called a framer, so I install the framework for buildings \nbefore they throw on the walls and roof.", line15);
        Monologue line13 = new Monologue(localname, "No, definitely not. There are different types of carpenters,", line14);
        Monologue line12 = new Monologue(playerName, "Is it only for buildings?", line13);
        Monologue line11 = new Monologue(localname, "Simply put, it’s my job to install and maintain the timber.", line12);
        Monologue line10 = new Monologue(localname, "You wouldn’t want to fall through your own floor or have a roof\n flop onto your head, now would ya?", line11);

        Monologue line9 = new Monologue(localname, "Anything from beams in a roof to making sure the wooden supports\n underneath a building’s floor don’t rot away.", line10);
        Monologue line8 = new Monologue(localname, "It’s about shaping and preparing any wooden components of a \nconstruction project.", line9);
        Monologue line7 = new Monologue(localname, "You could say that.", line8);
        Monologue line6 = new Monologue(playerName, "Oh very nice. So is that just carving things from wood?", line7);

        Monologue line5 = new Monologue(localname, "I’m a carpenter.", line6);
        Monologue line4 = new Monologue(playerName, "No worries, what do you do in construction? I’m trying to learn a \nlittle bit myself.", line5);
        Monologue line3 = new Monologue(localname, "Oh cheers mate, you’re a lifesaver.", line4);
        Monologue line2 = new Monologue(playerName, "Well good news, the centre of town is about two blocks to the right \nwhen you walk out the door.", line3);
        Monologue line1 = new Monologue(localname, "I’m looking for a construction site in the centre of town, which way \nwould that happen to be?", line2);
        return line1;
    }
}
