using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Oven : MonoBehaviour
{
    private Vector3 pos = new Vector3 (-65.6f, 4, 3.8f);
    public float targetTime = 60.0f;
    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<DraggableObject>().enabled = false;
        other.gameObject.transform.position = pos;
    }
    
}
