using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public DialogueManager manager;
    public Sprite playerImage;
    public Sprite otherImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.currentSection.GetSpeakerName() == "Player")
        {
            gameObject.GetComponent<Image>().sprite = playerImage;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = otherImage;
        }
    }
}
