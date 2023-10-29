using System.Collections;
using System.Collections.Generic;
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
    string playerName = "Player";
    // Start is called before the first frame update
    void Start()
    {
        hannah.pieMade = true;
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
    }
    public DialogueSection D5Start()
    {
        if (hannah.pieMade)
        {
            Monologue end = new Monologue(localname, "");
            Monologue line35 = new Monologue(localname, "Good.", end);
            Monologue line34 = new Monologue(localname, "A classic meat pie would be great right now.", line35);
            Monologue line33= new Monologue(playerName, "No, but I can make one for you. Any preferences?", line34);
            Monologue line32 = new Monologue(localname, "True, and talking about pies and strengthening relationships, do you have any pies for sale?", line33);
            Monologue line31 = new Monologue(playerName, "It’s always good to strengthen relationships.", line32);
            Monologue line30 = new Monologue(localname, "That’s awesome, maybe I owe Hannah an apology for being so pushy against her…", line31);
            Monologue line23 = new Monologue(localname, "Oh! I did not know that", line30);
            Monologue line26 = new Monologue(playerName, "She’s also made a new plan to get this very pie store involved by giving out pies at work to boost morale a bit.", line23);
            Monologue line25 = new Monologue(localname, "That’s true. I guess she does try to motivate us to stay on our deadlines. In all honesty, some people do slack off and I’m happy she’s there to help out otherwise my job would be even worse.", line26);
            Monologue line24 = new Monologue(playerName, "I understand that you’re not robots and need breaks but think about her position as well.", line25);


            Monologue line14 = new Monologue(playerName, "I don’t think she’s blaming you. I think it’s because her job is to stay on track and when people don’t work she thinks the project might fall behind.", line24);
            Monologue line13 = new Monologue(localname, "Yeah and she blames us.", line14);

            Monologue line12 = new Monologue(playerName, "She was actually in here trying to find some calm as well. She’s stressed out.", line13);
            Monologue line11 = new Monologue(localname, "Yes! She’s been here? What a small world we live in.", line12);
            Monologue line10 = new Monologue(playerName, "Is your manager Hannah?", line11);
            Monologue line9 = new Monologue(playerName, "Oh… a site manager was in here yesterday saying that people don’t listen to her and slack off.", line10);
            Monologue line8 = new Monologue(localname, "She’s burning us out and blames us for slacking off.", line9);
            Monologue line7 = new Monologue(playerName, "What’s wrong with your manager?", line8);
            Monologue line6 = new Monologue(localname, "No. I’m just hiding from my manager for a second. I’ll be out of here soon.", line7);
            Monologue line5 = new Monologue(playerName, "Hello David… may … I help you…?", line6);

            Monologue line3 = new Monologue(playerName, "…", line5);
            Monologue line2 = new Monologue(playerName, "…", line3);
            Monologue line1 = new Monologue(localname, "Sup. I’m David.", line2);
            return line1;
        }

        else
        {

            Monologue line1 = new Monologue(localname, "Mornin’");
            return line1;
        }
        
    }
}
