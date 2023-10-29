using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Dialogue;

public class Welder : GenericCharacter
{
    public Pie p;
    public DialogueManager dManager;
    public Cook cook;
    public QueueController queue;
    public CameraPan pan;
    public Weld weld;

    string localname = "Lucy";
    string playerName = "Player";

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void Day5Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(D5Start());
    }

    // Update is called once per frame
    void Update()
    {
        if (weld.weldFinish)
        {

            FindObjectOfType<DialogueManager>().StartDialogue(PostWeld());
            weld.weldFinish = false;
        }
        if (dManager.goodChoice == 1)
        {
            pan.start = false;
            dManager.goodChoice = 2;
        }
        if (cook.PieCompleted() == true && queue.currentCharacter == 1)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(PieTalk());
        }
    }

    public DialogueSection PieTalk()
    {
        Monologue end = new Monologue(localname, "Next");
        Monologue line119 = new Monologue(playerName, "Have a good one.", end);
        Monologue line18 = new Monologue(localname, "Bye bye!", line119);
        Monologue line17 = new Monologue(localname, "I’m glad you find it interesting, this will have to wait though. I need \nto go meet Hannah again for a progress \nreport.", line18);
        Monologue line16 = new Monologue(playerName, "Sounds fascinating.", line17);
        Monologue line15 = new Monologue(localname, "For sure, but we use computers to aid us in the design and cutting \nprocesses when we make the tools. It’s all \npretty cool to be honest.", line16);
        Monologue line14 = new Monologue(playerName, "I never even realised that tools themselves need someone to make them. \nI guess it makes sense, can’t robots \ndo that though?", line15);
        Monologue line13 = new Monologue(localname, "We even make tools that other trades use.", line14);
        Monologue line12 = new Monologue(localname, "From welding vehicles, like cars and planes, to making jewellery. \nAny work that requires fusing metal is a welders job.", line13);
        Monologue line11 = new Monologue(localname, "Of course. There’s the skill of soldering and welding becomes \nvery specific.", line12);

        Monologue line10 = new Monologue(playerName, "Are there similar jobs that require different styles of finesse?", line11);
        Monologue line9 = new Monologue(localname, "Why thank you. Welding does have a finesse to it that takes time \nto develop.", line10);
        Monologue line8 = new Monologue(playerName, "I could say the same to you, working so hard to master your craft, \nafter what I’m sure has been years of practice.", line9);
        Monologue line7 = new Monologue(localname, "So coming this far is quite the achievement.", line8);
        Monologue line6 = new Monologue(localname, "I certainly hope so, that would be amazing. I knew this place was \npretty rundown a couple years ago.", line7);
        Monologue line5 = new Monologue(playerName, "On Monday, so very soon. Hopefully it’s a successful opening.", line6);
        Monologue line4 = new Monologue(localname, "When do you open by the way?", line5);
        Monologue line3 = new Monologue(localname, "This is the best pie I’ve ever had. I will definitely come back once \nyou’re open.", line4);
        Monologue line2 = new Monologue(localname, "Mmmmmm", line3);

        Monologue line1 = new Monologue(playerName, "One pie, as requested.", line2);

        return line1;
    }
    public DialogueSection PostWeld()
    {



        Monologue line12 = new Monologue(localname, "");
        
        Monologue line8 = new Monologue(playerName, "Good.", line12);
        Monologue line7 = new Monologue(localname, "So anything without peas please.", line8);
        Monologue line6 = new Monologue(localname, "My kids have been eating an abundance of peas lately and I’m sick \nof them.", line7);
        Monologue line5 = new Monologue(localname, "Oh mate! What a bargain this is.", line6);
        Monologue line4 = new Monologue(playerName, "Well, let me repay the favour and show you my field of expertise, \nwhat kind of pie do you like?", line5);
        Monologue line3 = new Monologue(localname, "No worries mate. Glad to help out in my field of expertise.", line4);
        Monologue line2 = new Monologue(playerName, "It looks amazing! Thank you for showing me that.", line3);
        Monologue line1 = new Monologue(localname, "How good is that!", line2);

        return line1;
    }
    public DialogueSection D5Start()
    {
        Monologue line23 = new Monologue(localname, "Next");
        Monologue line26 = new Monologue(localname, "No worries mate, see ya around.",line23);
        Monologue line25 = new Monologue(playerName, "That might be best, sorry.", line26);
        Monologue line24 = new Monologue(localname, "Damn, I guess I can look somewhere else to practise then.", line25);
        
        
        Monologue line14 = new Monologue(localname, "");
        Monologue line13 = new Monologue(localname, "Weld", line14);

        Monologue line12 = new Monologue(playerName, "Let’s get to it.", line13);
        Monologue line11 = new Monologue(localname, "I agree! I saw some of your window stools are broken? Those bases \ncan be welded to the seats to fix them.", line12);
        Choices line10 = new Choices(localname, "I’m a welder. I work with metal and repair or fuse parts together.", ChoiceList(Choice("Oh, well that’s quite useful.", line11), Choice("I have no idea how that would be useful", line24)));
        Monologue line9 = new Monologue(playerName, "Well, what do you do?", line10);
        Monologue line8 = new Monologue(localname, "Anything would be good for me, I’m not too stressed.", line9);
        Monologue line7 = new Monologue(playerName, "I’m not sure how much experience you’d get here.", line8);
        Monologue line6 = new Monologue(playerName, "Work experience? Well this isn’t exactly a construction site but I am renovating, that’s correct.", line7);
        Monologue line5 = new Monologue(localname, "I know. My manager, Hannah, told me about the renovations going on \nhere and said I could potentially get some work \nexperience here?", line6);
        
        Monologue line3 = new Monologue(playerName, "Oh yes, I saw that as well. Quite the shoutout to be on the news \nbefore even opening.", line5);
        Monologue line2 = new Monologue(playerName, "Oh, hello. I’m not open.", line3);
        Monologue line1 = new Monologue(localname, "Mornin’", line2);

        return line1;
    }
}
