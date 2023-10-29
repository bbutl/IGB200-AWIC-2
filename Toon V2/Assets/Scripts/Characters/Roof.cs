using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Dialogue;
public class Roof : GenericCharacter
{
    public Pie p;
    public DialogueManager dManager;
    public Cook cook;
    public QueueController queue;
    public CameraPan pan;
    public Roofer roofer;


    string localname = "Karen";
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
        if (roofer.roofFinished)
        {
            
            FindObjectOfType<DialogueManager>().StartDialogue(PostRoof());
            roofer.roofFinished = false;
        }
        if (dManager.goodChoice == 1)
        {
            pan.start = false;
            dManager.goodChoice = 2;
        }
        if (cook.PieCompleted() == true && queue.currentCharacter == 2)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(PieTalk());
        }
    }
    public DialogueSection PieTalk()
    {
        Monologue line10 = new Monologue();
        Monologue line9 = new Monologue();
        Monologue line8 = new Monologue();
        Monologue line7 = new Monologue(localname, "Next");
        Monologue line6 = new Monologue(localname, "Bye bye.", line7);
        Monologue line5 = new Monologue(playerName, "Have a good one.", line6);
        Monologue line4 = new Monologue(playerName, "Glad you like it.", line5);
        Monologue line3 = new Monologue(localname, "This is perfect mate, I’ll certainly be back after your renovations.", line4);
        Monologue line2 = new Monologue(localname, "Mmmmmm", line3);

        Monologue line1 = new Monologue(localname, "Oh, you bloody ripper, how awesome is this.", line2);

        return line1;
    }
    public DialogueSection PostRoof()
    {




        Monologue line12 = new Monologue(localname, "");
        Monologue line11 = new Monologue(localname, "Good.", line12);
        Monologue line10 = new Monologue(localname, "I can’t say no to that.", line11);
        Monologue line9 = new Monologue(playerName, "Well as a thank you, I’d like to offer you a meat pie!", line10);
        Monologue line8 = new Monologue(playerName, "That’s amazing.", line9);
        Monologue line7 = new Monologue(localname, "It’s all interconnected.", line8);
        Monologue line6 = new Monologue(localname, "Gotta work with carpenters to get the cross beams in and roof \nplumbers to install things like gutters, downward pipes and rain \nwater tanks.", line7);
        Monologue line5 = new Monologue(localname, "Yeah, waterproofing, insulation, tiling on the top or whatever \nmaterial the client is using for the outer layer.", line6);
        Monologue line4 = new Monologue(playerName, "So you put waterproofing in and other stuff?", line5);
        Monologue line3 = new Monologue(localname, "Pretty much, depending on what the situation is. Like this was a \nrepair job but sometimes I’m installing brand new roofs but the \nactual construction process is relatively similar.", line4);
        Monologue line2 = new Monologue(playerName, "It looks like a million bucks mate. Is the roofing process the same \nfor every roof?", line3);
        Monologue line1 = new Monologue(localname, "Perfect. New roof installed.", line2);

        return line1;
    }
    public DialogueSection D4Start()
    {
        Monologue line24 = new Monologue();
        Monologue line23 = new Monologue(localname, "Next");
        Monologue line22 = new Monologue(localname , "Goodbye.", line23);
        Monologue line21 = new Monologue(localname, "Fair mate, I’ll catch ya around then.", line22);
        Monologue line20 = new Monologue(localname, "");
        Monologue line19 = new Monologue(localname, "Roof", line20);
        Monologue line18 = new Monologue(localname, "Let me go get my equipment.", line19);
        Monologue line17 = new Monologue(localname, "I sure am. Let’s do this.", line18);
        Monologue line16 = new Monologue(playerName, "Are you sure? I would love to learn what to do if you’re willing \nto help.", line17);
        Monologue line15 = new Monologue(localname, "In that case, let’s sort it out.", line16);
        Monologue line14 = new Monologue(playerName, "I’m glad you decided to pop by, but I won’t be open until that hole \nis fixed to be honest.", line15);
        Monologue line13 = new Monologue(localname, "Sure do mate. Currently got some spare time to kill so thought \nI’d check this place out.", line14);

        Monologue line12 = new Monologue(playerName, "So you work in town then I’m guessing?", line13);
        Monologue line11 = new Monologue(localname, "Indeed!.\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nLaugh..", line12);
        Monologue line10 = new Monologue(playerName, "Well that’s convenient.", line11);
        Monologue line9 = new Monologue(localname, "I’d sure hope I do, I am a roofer afterall.", line10);
        Monologue line8 = new Monologue(playerName, "Oh wow, you know quite a lot about this.", line9);
        Monologue line7 = new Monologue(localname, "Well you’ll need some tools, insulation, waterproofing and some \nshingles for a start.", line8);
        Monologue line6 = new Monologue(playerName, "Ah yes. I have no idea what to do about that.", line7);
        Monologue line5 = new Monologue(localname, "That makes sense, I noticed the hole in the roof.", line6);
       Choices line4 = new Choices(localname, "Oh, you’re not open?", ChoiceList(Choice("No, I am currently just renovating.", line5), Choice("No, not yet.", line21)));
        Monologue line3 = new Monologue(playerName, "Oh yes, I saw that as well. Quite the shoutout to be on the news \nbefore even opening.", line4);
        Monologue line2 = new Monologue(localname, "I saw on the news that this place is a potential hot spot and I love \npies so I thought I’d check it out.", line3);
        Monologue line1 = new Monologue(localname, "Hey mate, sorry to disturb you.", line2);

        return line1;
    }
}
