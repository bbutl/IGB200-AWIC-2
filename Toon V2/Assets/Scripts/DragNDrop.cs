using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour 
{
    static public GameObject draggedObject;
    

    private Vector3 mousePosOffset;
    private bool isClicked = false;
    private GameObject duplicateObject;
    private Transform parentAfterDrag;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector3 GetMouseWorldPos()
    {
        
        return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, Camera.main.transform.position.z));

    }
    public void OnMouseDown()
    {
        if (this.gameObject.tag == "Ingredient") 
        {
            duplicateObject = this.gameObject;
            mousePosOffset = gameObject.transform.position - GetMouseWorldPos();

            Instantiate(duplicateObject, GetMouseWorldPos() + mousePosOffset, Quaternion.identity);
        }
        else
        {
            mousePosOffset = gameObject.transform.position - GetMouseWorldPos();
        }
    }
    public void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mousePosOffset;
        Debug.Log($"{GetMouseWorldPos() + mousePosOffset}");
    }
    
    public void OnMouseUp()
    {
        if (this.gameObject.tag == "Ingredient")
        {
            //Destroy(gameObject);
        }
        else
        {

        }
    }
    


}
