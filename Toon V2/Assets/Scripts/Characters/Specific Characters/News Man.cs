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
        FindObjectOfType<DialogueManager>().StartDialogue(Day1News());
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
}
