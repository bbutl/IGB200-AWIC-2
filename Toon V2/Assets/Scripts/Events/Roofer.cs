using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roofer : MonoBehaviour
{
    private int stepNumber = 0;
    public Camera cam;
    public CameraPan pan;
    public GameObject[] roofs;
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.transform.position = cam.transform.position;
        Camera.main.transform.rotation = cam.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(stepNumber == 5) 
        {
            Camera.main.transform.position = new Vector3(-66.677002f, 4.4000001f, 3.56999993f);
            Camera.main.transform.rotation = new Quaternion(0, 0.707106829f, 0, 0.707106829f);
            pan.start = true;
            stepNumber = 0;

        }
    }
    public void OnTriggerEnter(Collider other)
    {
        switch(stepNumber)
        {
            case 0:
                
                if (other.gameObject.name == "Hammer")
                {
                    Destroy(other.gameObject);
                    stepNumber++;
                }
                break;
            case 1:
                if (other.gameObject.name == "SawGuard2")
                {
                    Destroy(other.gameObject);
                    roofs[0].SetActive(false);
                    roofs[1].SetActive(true);
                    stepNumber++;
                }
                break;
            case 2:
                if (other.gameObject.name == "Plank")
                {
                    Destroy(other.gameObject);
                    roofs[1].SetActive(false);
                    roofs[2].SetActive(true);
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
                }
                break;
                
                
        }





    }
}
