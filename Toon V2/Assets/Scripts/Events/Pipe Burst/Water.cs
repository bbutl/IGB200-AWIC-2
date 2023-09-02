using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private int rotationGoal = 75;
    private int angle = 20;
    public bool hasClicked = false;
    // Start is called before the first frame update
    void Update()
    {
        if (gameObject.transform.localEulerAngles.x < rotationGoal && hasClicked)
        {
            
            gameObject.transform.Rotate(0, angle * (Time.deltaTime * 2), 0);
        }
       
    }

   public void OnMouseDown()
    {
        hasClicked = true;
    }
}
