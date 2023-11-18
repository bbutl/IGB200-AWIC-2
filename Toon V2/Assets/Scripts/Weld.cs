using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weld : MonoBehaviour
{
    public Fade fade;
    public bool startWeld = false;
    public Camera cam;
    public GameObject welder;
    public GameObject seat;
    private int stepNumber = 0;
    public GameObject w;
    public bool weldFinish = false;
    public GameObject newSeat;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (startWeld)
        {
            Camera.main.transform.position = cam.transform.position;
            Camera.main.transform.rotation = cam.transform.rotation;
            welder.SetActive(true);
            startWeld = false;
            seat.GetComponent<BoxCollider>().enabled = true;
        }
        if (stepNumber == 5)
        {
            newSeat.gameObject.SetActive(true);
            gameObject.SetActive(false);
            seat.gameObject.SetActive(false); ;
            w.gameObject.SetActive(false);
            seat.GetComponent<BoxCollider>().enabled = false;
            Camera.main.transform.position = new Vector3(-66.677002f, 4.4000001f, 3.56999993f);
            Camera.main.transform.rotation = new Quaternion(0, 0.707106829f, 0, 0.707106829f);
            weldFinish = true;
            stepNumber++;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (stepNumber++ == 0 && other.gameObject.name == "pasted__BrokenTop")
        {
            seat.GetComponent<DraggableObject>().isDraggable = false;
            seat.GetComponent<BoxCollider>().enabled = false;
            seat.transform.position = new Vector3(-56.6329994f, 2.80699992f, -4.05700016f);
            seat.transform.eulerAngles = new Vector3(291.065643f, 230.671555f, 37.4002228f);
            stepNumber++;

        }
        if (stepNumber++ == 3 && other.gameObject.name == "Welder")
        {
            
            welder.GetComponent<DraggableObject>().isDraggable = false;
            
            w.transform.position = new Vector3(-56.4539986f, 1.66999996f, -4.36600018f);
            stepNumber++;
        }
    }
}
