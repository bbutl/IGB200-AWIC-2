using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Dialogue;
using UnityEngine.UI;
using Unity.Mathematics;

public class Susan : GenericCharacter
{
    public bool startGuide = false;
    
    public Cook cook;
    public QueueController queue;
    public CharacterRandomisation characterRandomisation;
    public CustomerOrder order;
    public EventTally tally;
    private string localName = "Susan";
    private string playerName = SaveFileManagement.saveFile.playerName;
    private void Start()
    {
        order.CreateOrder();
        
    }
    private void Update()
    {
        if (cook.PieCompleted() == true && queue.currentCharacter == 2)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(GoodConvo());
        }
    }
    public override void Day2Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(D2Start());
    }


    public override void Day6Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(D6Start());
    }






        public DialogueSection D6Start()
    {

        if (tally.tally >= 2)
        {
            Monologue line13 = new Monologue(localName, "Next");
            Monologue line12 = new Monologue(playerName, "What a lovely day it is.", line13);
            Monologue line11 = new Monologue(playerName, "Good luck! ", line12);
            Monologue line10 = new Monologue(localName, "Anyway! I’m not finished learning, so I'm going to go back to mingling.\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nLaugh..", line11);
            Monologue line9 = new Monologue(localName, "If there was any conflict between them, I can’t see it now. They’re both wonderful friends.", line10);
            Monologue line8 = new Monologue(playerName, "Oh? They must have figured out their conflicts. That’s wonderful.", line9);
            Monologue line7 = new Monologue(localName, "She was very informative. Her colleague David also gave me some great insight.", line8);
            Monologue line6 = new Monologue(localName, "Likewise, I was even talking to Hannah, the site manager sitting over there.", line7);
            Monologue line5 = new Monologue(playerName, "I’m happy you could learn so much", line6);
            Monologue line4 = new Monologue(localName, "I can tell my daughter about all of them. It’s quite exciting.", line5);
            Monologue line3 = new Monologue(localName, "I’m fantastic. I’ve been talking to all these people and learning about different construction roles.", line4);
            Monologue line2 = new Monologue(playerName, "You look better than you did a couple days ago, how are you?", line3);
            Monologue line1 = new Monologue(localName, "Hi! It’s me again. What a lovely day, congratulations on opening the store!", line2);
            return line1;
        }

        else
        {
            
            Monologue line1 = new Monologue(localName, "Next");
            return line1;

        }


    }

    private DialogueSection D2Start()
    {
        
        Monologue end = new Monologue(localName, "");
        Monologue good15 = new Monologue(localName, "Order", end);
        Monologue good14 = new Monologue(localName, "Well in that case, sure.\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nSmile..", good15);
        Monologue good13 = new Monologue(playerName, "That’s fine, this one’s on the house.", good14);
        Monologue good12 = new Monologue(localName, "I don’t have any money on me right now.", good13);
        Monologue good11 = new Monologue(localName, "Oh! Are you sure?", good12);
        Monologue good10 = new Monologue(playerName, "It would give me some practice.", good11);
        Monologue good9 = new Monologue(playerName, "Would you like a pie?", good10);
        Monologue good8 = new Monologue(playerName, "Infact…", good9);
        Monologue good7 = new Monologue(playerName, "I also want to sharpen up my cooking skills before the reopening.", good8);
        Monologue good6 = new Monologue(playerName, "I might start networking a bit myself to find some help for the store.", good7);
        Monologue good5 = new Monologue(playerName, "Not particularly, but I’m looking to learn.", good6);
        Monologue good4 = new Monologue(localName, "Do you know anything about construction?", good5);
        Monologue good3 = new Monologue(localName, "Oh I see.\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nSmile..", good4);
        Monologue good2 = new Monologue(playerName, "I am actually busy renovating the store for a reopening next week.", good3);
        Monologue good1 = new Monologue(playerName, "Of course.", good2);
        //Worried Reaction
        Monologue good = new Monologue(localName, "Are you sure?", good1);
        Monologue endBad = new Monologue(playerName, "Next");
        Monologue bad2 = new Monologue(localName, "Goodbye!", endBad);
        Monologue bad1 = new Monologue(localName, "In that case I’ll leave.", bad2);
        Monologue bad = new Monologue(localName, "Oh, okay. I understand.\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nSad..", bad1);
        Choices line19 = new Choices(localName, "I saw someone in here earlier and thought you were open.", ChoiceList(Choice("No worries, you’re welcome to stay.", good),
            Choice("That was the previous owner.", bad)));
        Monologue line18 = new Monologue(localName, "I didn’t even realise.", line19);
        // Shocked Reaction
        Monologue line17 = new Monologue(localName, "Oh! I am so sorry!", line18);
        Monologue line16 = new Monologue(playerName, "I’m actually not open at the moment, so that might be difficult.", line17);
        Monologue line15 = new Monologue(localName, "Maybe she can learn from them here?", line16);
        Monologue line14 = new Monologue(localName, "Do you get many construction workers here by any chance?", line15);
        Monologue line13 = new Monologue(localName, "…", line14);
        Monologue line12 = new Monologue(playerName, "Maybe she can find someone to network from?", line13);
        Monologue line11 = new Monologue(playerName, "Well there’s plenty of construction going on in town recently…", line12);
        Monologue line10 = new Monologue(localName, "No. She’s done some research but it tends to overwhelm her.", line11);
        Monologue line9 = new Monologue(playerName, "Well construction is quite a wide industry, does she know \nwhat specific job she’d like to do?", line10);
        Monologue line8 = new Monologue(localName, "She wants to go into construction but I don’t know anything about \nthe industry and I’m just worried for her.", line9);
        Monologue line7 = new Monologue(localName, "I’m just worried about my daughter.", line8);
        Monologue line6 = new Monologue(localName, "Not quite… maybe? I’m not sure right now.", line7);
        Monologue line5 = new Monologue(playerName, "Is everything okay?", line6);
        Monologue line4 = new Monologue(localName, "…Sorry, I just need somewhere to sit for a while.", line5);
        Monologue line3 = new Monologue(playerName, "…", line4);
        // Worried Reaction
        Monologue line2 = new Monologue(localName, "Hi, hello, yes…", line3);
        Monologue line1 = new Monologue(playerName, $"Hello, may I help you?", line2);
        
        return line1;

    }
    private DialogueSection GoodConvo()
    {
        Monologue end = new Monologue(playerName, "Next");
        Monologue line27 = new Monologue(localName, "Best of luck! Goodbye!\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nSmile..", end);
        Monologue line26 = new Monologue(localName, "I think I should get back home and tell her about this.", line27);
        Monologue line25 = new Monologue(localName, "Thank you again, you’ve been very kind.", line26);
        Monologue line24 = new Monologue(playerName, "I’d be happy to share what I learn and potentially introduce \nher to some people I may meet.", line25);
        Monologue line23 = new Monologue(playerName, "That sounds wonderful.", line24);
        Monologue line22 = new Monologue(localName, "I always find her reading about construction in some way \nor another.", line23);
        Monologue line21 = new Monologue(localName, "She also loves it,", line22);
        Monologue line20 = new Monologue(localName, "She’s told me that it’s a big goal of hers to join construction \nand overcome parts of her fears.", line21);
        Monologue line19 = new Monologue(playerName, "Is she sure she would want to do it as a job then?", line20);
        Monologue line18 = new Monologue(playerName, "That’s perfectly fine but…", line19);
        Monologue line17 = new Monologue(localName, "So going to a construction site or anywhere with a lot of people \ntends to give her panic attacks.", line18);
        Monologue line16 = new Monologue(localName, "She suffers from serious anxiety…", line17);
        Monologue line15 = new Monologue(localName, "See…", line16);
        Monologue line14 = new Monologue(localName, "Hopefully it will give some peace to her mind as she goes into \nthe industry.", line15);
        Monologue line13 = new Monologue(localName, "Thank you so much!", line14);
        Monologue line12 = new Monologue(playerName, "Of course.", line13);
        Monologue line11 = new Monologue(localName, "Whether it’s networking related or job related, \nanything would help.", line12);
        Monologue line10 = new Monologue(localName, "Do you think you could show my daughter and I what you learn?", line11);
        Monologue line9 = new Monologue(localName, "You mentioned you were going to learn about construction?", line10);
        Monologue line8 = new Monologue(localName, "Just a quick question about something you said earlier.", line9);
        Monologue line7 = new Monologue(localName, "Of course…", line8);
        Monologue line6 = new Monologue(playerName, "I’m glad you enjoyed it.", line7);
        Monologue line5 = new Monologue(playerName, "Oh certainly, I’ll get some sauces.", line6);
        Monologue line4 = new Monologue(localName, "Only thing better would’ve been some tomato sauce.", line5);
        Monologue line3 = new Monologue(localName, "I like it!\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nSmile..", line4);
        //Thinking reaction
        Monologue line2 = new Monologue(localName, "Mmmmmm", line3);
        Monologue line1 = new Monologue(playerName, "What do you think?", line2);
        return line1;
    }
}