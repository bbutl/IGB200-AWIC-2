using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public DialogueManager manager;
    private Vector3 playerPos = new Vector3(70.000061f, -350f, -20);
    public Sprite playerImage;
    private Vector3 otherPos = new Vector3(-450, 25, -20);
    public Sprite otherImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        if(manager.currentSection.GetSpeakerName() == "Player")
        {
            rectTransform.localPosition = playerPos;
            gameObject.GetComponent<Image>().sprite = playerImage;
        }
        else
        {
            rectTransform.localPosition = otherPos;
            gameObject.GetComponent<Image>().sprite = playerImage;
        }
    }
}
