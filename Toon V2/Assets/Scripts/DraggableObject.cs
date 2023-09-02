using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    [Header("Mouse Position")]
    private Vector3 mousePosOffset;
    Vector3 mousePosition;
    float yPos;
    float xPos;
    public bool lockY = true;
    private GameObject duplicateObject;
    
    // Start is called before the first frame update
    void Start()
    {
        yPos = gameObject.transform.position.y;
        xPos = gameObject.transform.position.x;
    }

    void Update()
    {
        LockY();
        LockX();
    }

    private void LockX()
    {
        if (lockY == false)
        {


            if (transform.position.x != xPos)
            {
                transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
            }
        }
    }
    //Stop object from moving on the y axis
    private void LockY()
    {
        if (lockY)
        {
            if (transform.position.y != yPos)
            {
                transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
            }
        }
    }

    Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
        //If the object is an ingredient, instantiate a clone of the object on click
        if (this.gameObject.tag == "Ingredient")
        {
            duplicateObject = this.gameObject;
            mousePosOffset = gameObject.transform.position - GetMousePos();
            Instantiate(duplicateObject, GetMousePos() + mousePosOffset, Quaternion.identity);
        }
        else
        {
            mousePosOffset = gameObject.transform.position - GetMousePos();
        }
    }
    private void OnMouseDrag()
    {
        //Object transform position is equal to cursor position
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }
    public void OnMouseUp()
    {
        //If the object is an ingredient, destroy game object on mouse button up
        if (this.gameObject.tag == "Ingredient")
        {
            Destroy(gameObject);
        }
    }
}
