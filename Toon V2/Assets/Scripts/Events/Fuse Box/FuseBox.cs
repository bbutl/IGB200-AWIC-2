using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : MonoBehaviour
{
    public OpenDoor door;
    public Camera cam;
    public Camera mainCam;
    //public GameObject Plate;
    private Vector3 orignalPos = new Vector3(-66.677002f, 4.4000001f, 3.56999993f);
    private Quaternion originalRotation = new Quaternion(0, 0.707106829f, 0, 0.707106829f);
    public bool eventStarted = false;
    public bool eventFinished = false;
    void Awake()
    {
        door.enabled = false;
    }
    

    // Update is called once per frame
    void Update()
    {
        CamHandler();
        
    }
    private void CamHandler() 
    {
        if (eventStarted)
        {
            mainCam.transform.position = cam.transform.position;
            mainCam.transform.rotation = cam.transform.rotation;
            door.enabled = true;
            eventStarted = false;
        }
        if (eventFinished)
        {
            Camera.main.transform.position = orignalPos;
            Camera.main.transform.rotation = originalRotation;
            eventFinished = false;
        }
    }
        
    
}
