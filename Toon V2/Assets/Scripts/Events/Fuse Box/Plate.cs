using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public GameObject Screw1;
    public GameObject Screw2;
    public GameObject Screw3;
    public GameObject Screw4;
    private float speed = 0.75f;
    private bool remove = false;

    private void Update()
    {
        if (Screw1 == null && Screw2 == null && Screw3 == null && Screw4 == null)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
            RemovePanel();
    }
    private void RemovePanel()
    {
        if (remove)
            {
            if (transform.position.z > 21.14f)
            {
                transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
            }
            else
            {
                transform.position += new Vector3((speed * 2) * Time.deltaTime, 0, 0);
                Invoke("Dtroy", 2f);
            }
               
            }
        
    }
    public void OnMouseDown()
    {
        if (Screw1 == null && Screw2 == null && Screw3 == null && Screw4 == null)
        {
            remove = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    public void Dtroy()
    {
        Destroy(gameObject);
    }
}
