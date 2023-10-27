using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    private bool moveDown = false;
    public GameObject Ipod;
    public IpodController controller;

    public void OnMouseDown()
    {
        controller.SkipBack();
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
