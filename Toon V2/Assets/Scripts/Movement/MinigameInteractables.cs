using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameInteractables : MonoBehaviour
{
    [SerializeField] bool isDraggable;
    [SerializeField] bool isClickable;
    [SerializeField] int buttonNumber;

    private bool beingDragged = false;
    private Vector3 dragOffset;

    void Update()
    {
        if (isDraggable)
        {
            if (beingDragged)
            {
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + dragOffset;
            }
        }
    }

    void OnMouseDown()
    {
        if (isDraggable)
        {
            dragOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            beingDragged = true;
        }
        if (isClickable)
        {

        }
    }

    void OnMouseUp()
    {
        if (isDraggable)
        {
            beingDragged = false;
        }
    }
}
