using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public DialogueManager manager;
    private Vector3 newsPos = new Vector3(-199, -396, -20);
    private Vector3 playerPos = new Vector3(70.000061f, -350f, -20);
    public Sprite playerImage;
    private Vector3 otherPos = new Vector3(-450, 25, -20);
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
        RectTransform rectTransform = GetComponent<RectTransform>();
        if(manager.currentSection.GetSpeakerName() == "Player")
        {
/*
            image.sprite = playerImage;
            image.color = playerColour.color;
*/
            rectTransform.localPosition = playerPos;
            gameObject.GetComponent<Image>().sprite = playerImage;
        }
        else if(manager.currentSection.GetSpeakerName() == "James")
        {
            rectTransform.localPosition = newsPos;
            gameObject.GetComponent<Image>().sprite = otherImage;
        }
        else
        {
/*
            image.sprite = otherImage;
            image.color = customerColours[0].color;
*/
            rectTransform.localPosition = otherPos;
            gameObject.GetComponent<Image>().sprite = playerImage;
        }
    }
}
