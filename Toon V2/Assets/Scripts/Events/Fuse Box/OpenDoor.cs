using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    Vector3 direction = new Vector3(0, 1, 0);
    private float angle = 10f;
    public float targetAngle = 240;
    public ScrewPulse pulse;
    public bool close = false;
    
   
    void Update()
    {
        
        if (gameObject.transform.eulerAngles.y > 90 && close)
        {
            Close();
        }
        if(gameObject.transform.eulerAngles.y < targetAngle && !close)
        {
            Open();
        }
        if (gameObject.transform.eulerAngles.y > 200)
        {
            pulse.enabled = true;
        }
  
    }
    public void Open()
    {
        gameObject.transform.Rotate(direction, angle * (Time.deltaTime * 4f));
    }
    public void Close()
    {
        gameObject.transform.Rotate(-direction, angle * (Time.deltaTime * 4f));
    }
}
