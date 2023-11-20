using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static Dialogue;
public class David : GenericCharacter
{
    public Pie p;
    public DialogueManager dManager;
    public Cook cook;
    public QueueController queue;
    public CameraPan pan;
    
    public Hannah hannah;
    string localname = "David";
    string playerName = SaveFileManagement.saveFile.playerName;
    // Start is called before the first frame update
    void Start()
    {
        dManager.goodChoice = 0;
    }
    public override void Day5Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(D5Start());
    }

    // Update is called once per frame
    void Update()
    {
        if (dManager.goodChoice == 1)
        {
            pan.start = false;
            dManager.goodChoice = 2;
        }
        // change to 2
        if (cook.PieCompleted() == true && queue.currentCharacter == 2)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(PieTalk());
        }
    }
    public DialogueSection D5Start()
    {
        dManager.goodChoice = 0;
        if (hannah.pieMade)
        {
            Monologue end = new Monologue(localname, "");
            Monologue line35 = new Monologue(localname, "Good.", end);
            Monologue line34 = new Monologue(localname, "A classic meat pie would be great right now.", line35);
            Monologue line33= new Monologue(playerName, "No, but I can make one for you. Any preferences?", line34);
            Monologue line32 = new Monologue(localname, "True, and talking about pies and strengthening relationships, \ndo you have any pies for sale?", line33);
            Monologue line31 = new Monologue(playerName, "It’s always good to strengthen relationships.", line32);
            Monologue line30 = new Monologue(localname, "That’s awesome, maybe I owe Hannah an apology for being so \npushy against her…", line31);
            Monologue line23 = new Monologue(localname, "Oh! I did not know that", line30);
            Monologue line26 = new Monologue(playerName, "She’s also made a new plan to get this very pie store involved by \ngiving out pies at work to boost morale a bit.", line23);
            Monologue line25 = new Monologue(localname, "That’s true. I guess she does try to motivate us to stay on our \ndeadlines. In all honesty, some people do slack off and I’m happy \nshe’s nthere to help out otherwise my job would be even \nworse.", line26);
            Monologue line24 = new Monologue(playerName, "I understand that you’re not robots and need breaks but \nthink about her position as well.", line25);


            Monologue line14 = new Monologue(playerName, "I don’t think she’s blaming you. I think it’s because her job is to stay \non track and when people don’t work she thinks the project might \nfall behind.", line24);
            Monologue line13 = new Monologue(localname, "Yeah and she blames us.", line14);

            Monologue line12 = new Monologue(playerName, "She was actually in here trying to find some calm as well. She’s \nstressed out.", line13);
            Monologue line11 = new Monologue(localname, "Yes! She’s been here? What a small world we live in.", line12);
            Monologue line10 = new Monologue(playerName, "Is your manager Hannah?", line11);
            Monologue line9 = new Monologue(playerName, "Oh… a site manager was in here yesterday saying that people don’t \nlisten to her and slack off.", line10);
            Monologue line8 = new Monologue(localname, "She’s burning us out and blames us for slacking off.", line9);
            Monologue line7 = new Monologue(playerName, "What’s wrong with your manager?", line8);
            Monologue line6 = new Monologue(localname, "No. I’m just hiding from my manager for a second. I’ll be out of \nhere soon.", line7);
            Monologue line5 = new Monologue(playerName, "Hello David… may … I help you…?", line6);

            Monologue line3 = new Monologue(playerName, "…", line5);
            Monologue line2 = new Monologue(playerName, "…", line3);
            Monologue line1 = new Monologue(localname, "Sup. I’m David.", line2);
            return line1;
        }

        else
        {
            Monologue end = new Monologue(localname, "Next");
            Monologue line31 = new Monologue(localname, "Cya around.", end);
            Monologue line30 = new Monologue(localname, "Yeah maybe, anyway I’m going to go back to work.", line31);
            Monologue line23 = new Monologue(playerName, "That’s quite unfortunate. Hopefully you can all figure something \nout and become a team again.", line30);
            Monologue line26 = new Monologue(localname, "I think some people might start complaining to higher ups soon if \nshe keeps pushing us, but I can’t be certain.", line23);
            Monologue line25 = new Monologue(localname, "Sometimes managers just don’t fit with the crew, but we need to \nlive with it and just do what we can.", line26);
            Monologue line24 = new Monologue(localname, "Well, she’s failing. Miserably. The whole site has really low \nmorale right now and people want her out.", line25);


            Monologue line14 = new Monologue(playerName, "She said she was trying to find a way to motivate all of you.", line24);
            Monologue line13 = new Monologue(localname, "Yeah and she blames us for all that stress.", line14);

            Monologue line12 = new Monologue(playerName, "She seemed very stressed out.", line13);


            Monologue line11 = new Monologue(localname, "Yes! She’s been here? What a small world we live in.", line12);
            Monologue line10 = new Monologue(playerName, "Is your manager Hannah?", line11);
            Monologue line9 = new Monologue(playerName, "Oh… a site manager was in here yesterday saying that people don’t \nlisten to her and slack off.", line10);
            Monologue line8 = new Monologue(localname, "She’s burning us out and blames us for slacking off.", line9);
            Monologue line7 = new Monologue(playerName, "What’s wrong with your manager?", line8);
            Monologue line6 = new Monologue(localname, "No. I’m just hiding from my manager for a second. I’ll be out of \nhere soon.", line7);
            Monologue line5 = new Monologue(playerName, "Hello David… may … I help you…?", line6);

            Monologue line3 = new Monologue(playerName, "…", line5);
            Monologue line2 = new Monologue(playerName, "…", line3);
            Monologue line1 = new Monologue(localname, "Sup. I’m David.", line2);
            return line1;
        }
        
    }
    public DialogueSection PieTalk()
    {
        Monologue line8 = new Monologue(localname, "Next");
        Monologue line7 = new Monologue(playerName, "I’m glad to have helped!", line8);
        Monologue line6 = new Monologue(localname, "Thank you for helping me out and putting me in the right direction. \nMy job might have just been saved because of you.", line7);
        Monologue line5 = new Monologue(localname, "Well, sorry to cut this short but I need to go say sorry to Hannah.", line6);
        Monologue line3 = new Monologue(playerName, "I’m glad you like it.", line5 );
        //Pie Check
        Monologue pie1 = new Monologue();
        Monologue pie2 = new Monologue();
        Monologue pie3 = new Monologue();



        if (p.filling == "Beef Filling")
        {
            pie1 = new Monologue(localname, "Oh wow, these are so fresh. I’m definitely looking forward to this new pie plan.", line3);
        }
        else
        {

            pie1 = new Monologue(localname, "Bit of a strange meat pie but I like it nonetheless.", line3);

        }
       
        Monologue line2 = new Monologue(localname, "Mmmmmm", line3);

        Monologue line1 = new Monologue(playerName, "Enjoy.", line2);

        return line1;
    }
}
