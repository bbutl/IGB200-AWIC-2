using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public DialogueManager manager;
    public Sprite playerImage;
    public Sprite otherImage;
    public Material playerColour;
    public Material[] customerColours;

    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.currentSection.GetSpeakerName() == "Player")
        {
            image.sprite = playerImage;
            image.color = playerColour.color;
        }
        else
        {
            image.sprite = otherImage;
            image.color = customerColours[0].color;
        }
    }
}
