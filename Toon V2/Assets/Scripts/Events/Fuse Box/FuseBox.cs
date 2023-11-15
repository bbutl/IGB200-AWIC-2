using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Dialogue;

public class FuseBox : MonoBehaviour
{
    public OpenDoor door;
    public Camera cam;
    public Camera mainCam;
    public Sean sean;
    public GameObject light;

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
            FindObjectOfType<DialogueManager>().StartDialogue(Tut());
            mainCam.transform.position = cam.transform.position;
            mainCam.transform.rotation = cam.transform.rotation;
            door.enabled = true;
            eventStarted = false;
        }
        if (eventFinished)
        {
            Camera.main.transform.position = orignalPos;
            Camera.main.transform.rotation = originalRotation;

            sean.finished = true;
            eventFinished = false;
            Invoke("Finish", 0.5f);
        }
    }
    private void Finish()
    {
        light.gameObject.transform.position = new Vector3(-59.3300018f, 6.36999989f, -3);
        light.gameObject.transform.eulerAngles = new Vector3(0, 90, 0);


        Camera.main.transform.position = orignalPos;
        Camera.main.transform.rotation = originalRotation;
    }

    public DialogueSection Tut()
    {
        Monologue line2 = new Monologue("Tutorial", "You are encouraged to explore and figure out what each of these \nare and how they function.");
        Monologue line1 = new Monologue("Tutorial", "Welcome to an 'event'. This is the electrician event. Press on the \nscreen on different aspects of the fuse box to progress the event \nand learn about this task. " +
            "Throughout Pie Stop there are many \nchances to do different events.", line2);
        return line1;

    }


}
