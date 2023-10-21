using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cal : MonoBehaviour
{
    private GameObject x;
    public Sprite finishedX;
    public DayController dayController;
    private int d = -1;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //x = GameObject.Find($"X({dayController.day})");
    }

    // Update is called once per frame
    void Update()
    {
        if(d != dayController.day)
        {
            d = dayController.day;
            x = GameObject.Find($"X ({dayController.day})");
            Debug.Log($"X ({dayController.day})");
            x.gameObject.GetComponent<Image>().enabled = true;
            animator = x.GetComponent<Animator>();
            animator.SetBool("Start", true);
            Invoke("Gif", 1.8f);
        }
        
    }
    private void Gif()
    {
        animator.SetBool("Start", false);
        animator.enabled = false;
        x.gameObject.GetComponent<Image>().sprite = finishedX;
    }
}
