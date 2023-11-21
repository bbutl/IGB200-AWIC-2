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
    private Vector3 tutPos = new Vector3(-341, 310, -20);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        if (manager.nameText.text == ":")
        {
            rectTransform.localPosition = playerPos;
            gameObject.GetComponent<Image>().sprite = playerImage;
        }
        else if (manager.currentSection.GetSpeakerName() == "James")
        {
            rectTransform.localPosition = newsPos;
            gameObject.GetComponent<Image>().sprite = otherImage;
        }
        else if (manager.currentSection.GetSpeakerName() == "Tutorial")
        {
            rectTransform.localPosition = tutPos;
        }
        else
        {
            rectTransform.localPosition = otherPos;
            gameObject.GetComponent<Image>().sprite = playerImage;
        }
    }
}
