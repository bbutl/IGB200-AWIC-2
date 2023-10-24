using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ipod : MonoBehaviour
{
    private bool moveDown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();
    }
    
    public void OnMouseOver()
    {
        moveDown = false;
        if(gameObject.transform.position.y < 3.5f)
        {
            gameObject.transform.position += new Vector3(0, 1 * Time.deltaTime, 0);
        }
    }
    public void OnMouseExit()
    {
        moveDown = true; ;
    }
    public void MoveDown()
    {
        if(moveDown && gameObject.transform.position.y > 3f)
        {
            gameObject.transform.position -= new Vector3(0, 1 * Time.deltaTime, 0);
        }
    }
}
