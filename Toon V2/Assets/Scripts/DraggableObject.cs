using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Vector3 mousePosOffset;
    Vector3 mousePosition;
    private GameObject duplicateObject;
    float yPos;
    // Start is called before the first frame update
    void Start()
    {
        yPos = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        LockY();
    }
    //Stop object from moving on the y axis
    private void LockY()
    {
        if (transform.position.y != yPos)
        {
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }
    }
    
    Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
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
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }
    public void OnMouseUp()
    {
        if (this.gameObject.tag == "Ingredient")
        {
            Destroy(gameObject);
        }
        else
        {

        }
    }
}
