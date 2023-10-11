using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    Vector3 direction = new Vector3(0, 1, 0);
    private float angle = 10f;
    public float targetAngle = 240;
    public bool s = false;
    public Camera FuseCamera;
   
    void Update()
    {
        if (s)
        {
            FuseCamera.gameObject.SetActive(true);
        }
        if(gameObject.transform.eulerAngles.y < targetAngle)
        {
            Open();
        }
        
    }
    public void Open()
    {
        gameObject.transform.Rotate(direction, angle * (Time.deltaTime * 4f));
    }
}
