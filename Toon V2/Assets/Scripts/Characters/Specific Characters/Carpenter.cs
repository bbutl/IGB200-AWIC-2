using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Dialogue;

public class Carpenter : GenericCharacter
{
    
    public CharacterRandomisation characterRandomisation;
    string localname = "Sean";
    string playerName = "Player";
    // Start is called before the first frame update
    void Start()
    {
        localname = characterRandomisation.name;
    }
    public override void Day2Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(D2Start());
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Monologue line16 = new Monologue(localname , "He can make the most boring piece of wood turn into the most \nbreathtaking nightstand you’ll ever see.", line17);
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
