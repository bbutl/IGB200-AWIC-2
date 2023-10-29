using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roofer : MonoBehaviour
{
    private int stepNumber = 0;
    public Camera cam;
    public CameraPan pan;
    public GameObject[] roofs;
    public GameObject nails;
    public Fade fade;
    public bool startRoofer = false;
    public bool roofFinished = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startRoofer)
        {
            Camera.main.transform.position = cam.transform.position;
            Camera.main.transform.rotation = cam.transform.rotation;
            pan.start = false;
            startRoofer = false;
        }
        if (stepNumber == 5)
        {

            roofFinished = true;
            stepNumber = -1;

        }
        if (roofFinished)
        {
            CamBack();
            //Invoke("CamBack", 1);
            
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        switch (stepNumber)
        {
            case 0:

                if (other.gameObject.name == "Hammer")
                {
                    Destroy(other.gameObject);
                    nails.SetActive(false);
                    stepNumber++;
                }
                break;
            case 1:
                if (other.gameObject.name == "SawGuard2")
                {

                    Destroy(other.gameObject);
                    fade.startFade = true;
                    Invoke("Roof1", 1);

                    stepNumber++;
                }
                break;
            case 2:
                if (other.gameObject.name == "Plank")
                {
                    Destroy(other.gameObject);
                    fade.startFade = true;
                    Invoke("Roof2", 1);

                    stepNumber++;
                }
                break;
            case 3:
                if (other.gameObject.name == "TarPaper")
                {
                    Destroy(other.gameObject);
                    stepNumber++;
                }
                break;
            case 4:
                if (other.gameObject.name == "Insulation")
                {
                    Destroy(other.gameObject);
                    stepNumber++;
                    Debug.Log(stepNumber);
                }
                break;


        }


    }
    private void Roof1()
    {
        roofs[0].SetActive(false);
        roofs[1].SetActive(true);

    }
    private void Roof2()
    {
        roofs[1].SetActive(false);
        roofs[2].SetActive(true);
        nails.SetActive(true);
    }
    private void CamBack()
    {
        Camera.main.transform.position = new Vector3(-66.677002f, 4.4000001f, 3.56999993f);
        Camera.main.transform.rotation = new Quaternion(0, 0.707106829f, 0, 0.707106829f);
        pan.start = true;
    }

}
