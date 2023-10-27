using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    private bool moveDown = false;
    public GameObject Ipod;
    public IpodController controller;
   
    public void OnMouseDown()
    {
         controller.SkipFoward();
    }
    public void OnMouseOver()
    {
        moveDown = false;
        if (Ipod.transform.position.y < 3.5f)
        {
            Ipod.transform.position += new Vector3(0, 1 * Time.deltaTime, 0);
        }
    }
    public void OnMouseExit()
    {
        moveDown = true; ;
    }
}
