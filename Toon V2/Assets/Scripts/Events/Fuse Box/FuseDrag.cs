using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseDrag : MonoBehaviour
{
    Vector3 mousePosition;
    private Vector3 mousePosOffset;
    public bool isDraggable = true;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
        mousePosOffset = gameObject.transform.position - GetMousePos();
    }
    private void OnMouseDrag()
    {
        if (isDraggable)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        isDraggable = false;
    }
}
