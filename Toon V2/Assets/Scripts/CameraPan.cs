using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public Camera cam;
    private bool hasPanned = false;
    public bool start = true;
    
    Vector3 direction = new Vector3 (1, 0, 0);
    public int rotationGoal = 85;
    public int fovGoal = 80;
    public float angle = 10f;
    public float fovChange = 40f;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
            if ( start == false && cam.transform.localEulerAngles.x < rotationGoal)
            {
                cam.transform.position += new Vector3(0, 0.5f * Time.deltaTime, 0);
                cam.transform.Rotate(direction, angle * Time.deltaTime);

            }
        if(start == true && cam.transform.position.y > 4)
        {
            cam.transform.position -= new Vector3(0, 0.5f * Time.deltaTime, 0);
            cam.transform.Rotate((direction * -1), angle * Time.deltaTime);
        }
        
        
    }
    public void StartPan()
    {
        start = false;
    }
    
}
