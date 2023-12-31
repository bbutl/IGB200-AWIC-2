using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class CameraPan : MonoBehaviour
{
   
    
    
    public bool start = true;
    public bool startRotate = false;
    public bool hasOrderded = false;
    [Header("Camera components")]
    public Camera cam;
    Vector3 direction = new Vector3(1f, 0, 0);
    Vector3 right = new Vector3(0, 1, 0);
    public float rGoal = 5f;
    public float rotationGoal = 80f;
    
    public float angle = 10f;
    
    

    private float currentXRotation;
    private float currentZRotation;
    private Vector3 currentRotation;
    
    private bool firstPan = true;
    public Tutorial tut;
    
    private void Start()
    {
        currentXRotation = cam.transform.localEulerAngles.x;
        currentZRotation = cam.transform.localEulerAngles.z;

    }
    // Update is called once per frame
    void Update()
    {
        
        
       //RotateCam();

       
        // Pans the camera down to cooking view
       if (start == false && cam.transform.localEulerAngles.x <= rotationGoal)
        {
            cam.transform.position += new Vector3(0, 0.5f * (Time.deltaTime * 2f), 0);
            cam.transform.Rotate(direction, angle * (Time.deltaTime * 2f));
            if(firstPan)
            {
                firstPan = false;
                tut.startTutorial = true;
            }
        }

        // Pans the camera up to customer view
        if (start == true && cam.transform.localEulerAngles.x > rGoal)
        {
            cam.transform.position -= new Vector3(0, 0.5f * (Time.deltaTime * 2f), 0);
            cam.transform.Rotate((direction * -1), angle * (Time.deltaTime * 2f));
            
        }
        
       
        
    }
    //Method utilised by button to start the pan
    public void StartPan()
    {
        if (start == true)
        { 
            start = false;
        }
        else
        {
            start = true;
        }
    }
    public void RotateCam()
    {
        if(startRotate == false)
        {
            return;
        }
        
        if(startRotate == true)
        {
            transform.Rotate(transform.localEulerAngles.x, 180, transform.localEulerAngles.z);
            startRotate = false;
        }
      
    }
    public void StartRotate()
    {
        startRotate = true;
    }
    
    
}
