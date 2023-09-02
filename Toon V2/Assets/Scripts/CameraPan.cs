using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraPan : MonoBehaviour
{
    [SerializeField] private SpriteState _state;
    [SerializeField] private Button button;
    [SerializeField] private Sprite[] buttonSprites;
    [SerializeField] private Image targetButton;


   public Camera cam;
   
    public bool start = true;

    Vector3 direction = new Vector3(1, 0, 0);
    public float rGoal = 5f;
    public float rotationGoal = 80f;
    public int fovGoal = 80;
    public float angle = 10f;
    public float fovChange = 40f;
    
    // Update is called once per frame
    void Update()
    {
        

        if (start == false && cam.transform.localEulerAngles.x <= rotationGoal)
        {
            cam.transform.position += new Vector3(0, 0.5f * Time.deltaTime, 0);
            cam.transform.Rotate(direction, angle * Time.deltaTime);
            
        }

        if (start == true && cam.transform.localEulerAngles.x > rGoal)
        {
            cam.transform.position -= new Vector3(0, 0.5f * Time.deltaTime, 0);
            cam.transform.Rotate((direction * -1), angle * Time.deltaTime);
        }


    }
    //Method utilised by button to start the pan
    public void StartPan()
    {
        if (start == true)
        { 
            start = false;
            targetButton.sprite = buttonSprites[1];
        }
        else
        {
            start = true;
            targetButton.sprite = buttonSprites[0];
            
        }
    }

}
