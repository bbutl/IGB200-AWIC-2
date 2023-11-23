using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cal : MonoBehaviour
{
    private GameObject x;
    public Sprite finishedX;
    public DayController dayController;
    private int d = -1;
    private Animator animator;
    public GameObject sun;
    public GameObject open;
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
            if (dayController.day == 5)
            {
                sun.gameObject.GetComponent<Image>().enabled = true;
                sun.gameObject.GetComponent<Image>().sprite = finishedX;


                open.gameObject.GetComponent<Image>().enabled = true;
                open.gameObject.GetComponent<Image>().sprite = finishedX;
                d = dayController.day + 2; 
            }
            else { d = dayController.day; }
            x = GameObject.Find($"X ({d})");
            Debug.Log($"X ({dayController.day})");
            x.gameObject.GetComponent<Image>().enabled = true;
            animator = x.GetComponent<Animator>();
            animator.SetBool("Start", true);
            Invoke("Gif", 1.8f);
            d = dayController.day;
        }
        
        
    }
    private void Gif()
    {
        animator.SetBool("Start", false);
        animator.enabled = false;
        x.gameObject.GetComponent<Image>().sprite = finishedX;
    }
    private void Gif2()
    {
        animator.SetBool("Start", false);
        animator.enabled = false;
        sun.gameObject.GetComponent<Image>().sprite = finishedX;
    }
    private void Gif3()
    {
        animator.SetBool("Start", false);
        animator.enabled = false;
        open.gameObject.GetComponent<Image>().sprite = finishedX;
    }
}
