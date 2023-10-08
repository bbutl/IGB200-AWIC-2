using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Counter : MonoBehaviour
{
    private DraggableObject drag;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "Ingredient")
        {
            drag = other.GetComponent<DraggableObject>();
            drag.isDraggable = false;

        }
    }
}
