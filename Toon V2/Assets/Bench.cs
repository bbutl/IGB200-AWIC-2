using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bench : MonoBehaviour
{
    public GameObject cam;
    public bool startBench = false;
    public CameraPan pan;
    public GameObject hammer;
    public bool startHammer = false;
    public bool hammerDirection = false;
    private int stepNumber = 0;
    public GameObject hammr;
    public GameObject plank;
    public GameObject bench;
    public GameObject newWood;
    public Fade fade;
    public bool benchFinish = false;
    public GameObject peas;
    public GameObject mushrooms;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startBench)
        {
            Camera.main.transform.position = cam.transform.position;
            Camera.main.transform.rotation = cam.transform.rotation;
            hammr.SetActive(true);
            plank.SetActive(true);
            pan.start = false;

            startBench = false;
        }
        if (startHammer)
        {

            if (hammerDirection == false)
            {
                hammer.gameObject.transform.Rotate(new Vector3(0, 0, (-100 * Time.deltaTime)));
            }
            if (hammerDirection == true)
            {
                hammer.gameObject.transform.Rotate(new Vector3(0, 0, (100 * Time.deltaTime)));
            }
        }
    }
    public void switchHammer()
    {
        if (hammerDirection == true)
        {
            hammerDirection = false;

        }
        else if (hammerDirection == false)
        {
            hammerDirection = true;

        }

    }
    public void OnTriggerEnter(Collider other)
    {
        if (stepNumber == 0 && other.gameObject.name == "Plank (1)")
        {
            other.gameObject.GetComponent<DraggableObject>().isDraggable = false;
            other.gameObject.transform.position = new Vector3(-64.2900009f, 2.79699993f, -0.709999979f);
            stepNumber++;

        }
        if (stepNumber == 1 && other.gameObject.name == "Hammer (1)")
        {
            other.gameObject.GetComponent<DraggableObject>().isDraggable = false;
            hammer.gameObject.transform.position = new Vector3(-63.8330002f, 3.35400009f, -0.186000004f);
            hammer.gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
            hammerDirection = false;
            startHammer = true;
            InvokeRepeating("switchHammer", 1, 0.6f);
            Invoke("FadeStart", 5);
            Invoke("CamBack", 6);
            stepNumber++;
        }

    }

    public void FadeStart()
    {
        fade.startFade = true;
    }
    private void CamBack()
    {
        hammr.SetActive(false);
        plank.SetActive(false);
        bench.GetComponent<MeshRenderer>().enabled = false;
        newWood.GetComponent<MeshRenderer>().enabled = true;
        Camera.main.transform.position = new Vector3(-66.677002f, 4.4000001f, 3.56999993f);
        Camera.main.transform.rotation = new Quaternion(0, 0.707106829f, 0, 0.707106829f);
        pan.start = true;
        peas.gameObject.SetActive(true);
        mushrooms.gameObject.SetActive(true);
        benchFinish = true;

    }

}
