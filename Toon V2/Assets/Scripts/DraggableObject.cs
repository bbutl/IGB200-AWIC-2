using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour
{
    [Header("Mouse Position")]
    private Vector3 mousePosOffset;
    Vector3 mousePosition;
    public Vector3 goTransform;
    float yPos;
    float xPos;
    public bool lockY = true;
    public bool isDraggable = true;
    private GameObject duplicateObject;
    private float timer = 0;
    private bool timerStart = false;

    [SerializeField] private TooltipLocation tooltip;
    [SerializeField] private int tooltipNumber;

    // Start is called before the first frame update
    void Start()
    {
        goTransform = gameObject.transform.position;

        yPos = gameObject.transform.position.y;
        xPos = gameObject.transform.position.x;
    }

    void Update()
    {
        if (!isDraggable)
        {
            timer += Time.deltaTime;
        }
        if (timer > 1)
        {
            timer = 0;
            isDraggable = true;
        }
        if (Camera.main.transform.localEulerAngles.x > 80)
        {
            lockY = true;
        }
        else
        {
            lockY = false;
        }
        LockX();
        LockY();
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
            /*
            duplicateObject = this.gameObject;
            mousePosOffset = gameObject.transform.position - GetMousePos();
            Instantiate(duplicateObject, GetMousePos() + mousePosOffset, transform.rotation);
            */
        }
        else
        {
            mousePosOffset = gameObject.transform.position - GetMousePos();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Ingredient")
        {
            isDraggable = false;
            gameObject.transform.position = goTransform;
        }

    }
    private void OnMouseDrag()
    {
        if (isDraggable)
        {
            //Object transform position is equal to cursor position
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        }


    }
    public void OnMouseUp()
    {
        //If the object is an ingredient, destroy game object on mouse button up
        if (this.gameObject.tag == "Ingredient")
        {
            this.gameObject.transform.position = goTransform;
            //Destroy(gameObject);
        }
    }

    public void OnMouseOver()
    {
        tooltip.ShowTooltip(tooltipNumber);
    }

    public void OnMouseExit()
    {
        tooltip.HideTooltip();
    }
}
