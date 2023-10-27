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
}
