using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Dialogue;

public class NewsMan : GenericCharacter
{
    private string localName = "James";
    public Image newsImage;
    public DialogueManager dManager;
    public EventTally tally;
    // Start is called before the first frame update
    void Start()
    {
       // FindObjectOfType<DialogueManager>().StartDialogue(Day1News());
    }
    public override void StartConversation()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Day1News());
    }
    public override void Day2Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Day2News());
    }
    public override void Day3Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Day3News());
    }
    public override void Day4Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Day4News());
    }
    public override void Day5Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Day5News());
    }
    public override void Day6Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Day6News());
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public DialogueSection Day1News()
    {
        Monologue end = new Monologue(localName, "Next");
        Monologue line3 = new Monologue(localName, "Some are here just for their careers, some to prove themselves in \ntheir trade and some just want the work experience.", end);
        Monologue line2 = new Monologue(localName, "Coming from many different paths in life.", line3);
        Monologue line1 = new Monologue(localName, "Construction projects in Awicville have taken off as the rural town \nhas been flooded with a new wave of labour workers.", line2);
        return line1;
    }

    public DialogueSection Day2News()
    {
        Monologue end = new Monologue(localName, "Next");
        Monologue line2 = new Monologue(localName, "In the heart of it all, a local pie store has seen some life after \nbeing practically abandoned for eleven years.", end);
        Monologue line1 = new Monologue(localName, "Awicville jobs skyrocket as small businesses open amidst \nconstruction boom.", line2);
        return line1;
    }

    public DialogueSection Day3News()
    {
        Monologue end = new Monologue(localName, "Next");
        Monologue line2 = new Monologue(localName, "This is one of many small businesses that have become active during \nthe recent construction boom in town.", end);
        Monologue line1 = new Monologue(localName, "Renovations have begun for a small pie store in Awicville with a \ngrand reopening planned for next week.", line2);
        return line1;
    }
    public DialogueSection Day4News()
    {
        Monologue end2 = new Monologue(localName, "");
        Monologue end = new Monologue(localName, "Next", end2);
        Monologue line3 = new Monologue(localName, "This pie store is in a prime location if it can successfully open\n the coming week.", end);
        Monologue line2 = new Monologue(localName, "As a potential hot spot for all the construction workers in the area.", line3);
        Monologue line1 = new Monologue(localName, "Word is spreading that the small pie store in the centre of town is \nalready developing a reputation amongst the community.", line2);
        return line1;
    }


    public DialogueSection Day5News()
    {
        Monologue end2 = new Monologue(localName, "");
        Monologue end = new Monologue(localName, "Next", end2);
        Monologue line3 = new Monologue(localName, "Which have begun opening to drive the economy, lifestyle \nand culture of Awicville.\r\n", end);
        Monologue line2 = new Monologue(localName, "These include restaurants, shops and tourist attractions.", line3);
        Monologue line1 = new Monologue(localName, "Awicville’s population spikes as smaller construction projects begin finishing.", line2);
        return line1;
    }
    public DialogueSection Day6News()
    {
        if(tally.tally >= 2)
        {
            Monologue end2 = new Monologue(localName, "");
            Monologue end = new Monologue(localName, "Next", end2);
            Monologue line3 = new Monologue(localName, "With a grand opening, Pie Stop is opening its doors after years of being rundown.", end);
            Monologue line2 = new Monologue(localName, "Especially the small pie store in the middle of it all.", line3);
            Monologue line1 = new Monologue(localName, "Awicville’s construction boom has been a major success for the \ntown.", line2);
            return line1;
        }
        else
        {
            Monologue end2 = new Monologue(localName, "");
            Monologue end = new Monologue(localName, "Next", end2);
            
            Monologue line2 = new Monologue(localName, "This has meant that many smaller businesses are struggling to finish renovations.", end);
            Monologue line1 = new Monologue(localName, "Awicville’s construction projects have hit a sudden slump as workers strike for better working conditions.", line2);
            return line1;
        }
       
    }
}
