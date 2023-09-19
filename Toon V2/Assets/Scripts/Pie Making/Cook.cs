using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : MonoBehaviour
{

    [Header("Ingredients")]
    public GameObject pieBase;
    public GameObject pieFilling;
    public GameObject pieTop;

    [Header("Current Ingredients")]
    private GameObject currBase;
    private GameObject currFilling;
    private GameObject currTop;

    [Header("Classes")]
    public Ingredient ingredient;
    public Pie pie;
    public CameraPan cameraPan;

    [Header("GameObjects")]
    public GameObject pieObject;
    public GameObject cookingArea;


    private Vector3 pieSpawn = new Vector3 (0, 0.5f, 0);
    private Vector3 offset = new Vector3(0f, 0.75f, 0f);
    //change to false
    private bool isCooked = true;
    // Start is called before the first frame update
    void Start()
    {
        pie = pieObject.GetComponent<Pie>();
        pie.pbase = "Default";
        pie.filling = "Default";
        pie.top = "Default";
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // If pie is complete, instantiate the pie & reset values of prefab
       if(PieCompleted())
        {
            
            Destroy(currBase);
            Destroy(currFilling);
            GameObject p = Instantiate(pieObject, cookingArea.transform.position + pieSpawn, Quaternion.identity);
            //p.transform.position -= new Vector3(2.7f,-1,2f);
            pie.pbase = "Default";
            pie.filling = "Default"; 
            pie.top = "Default";
            cameraPan.start = true;
            cameraPan.Invoke("StartRotate", 5);
            Debug.Log("Complete");
        } 
    }
    
    public void OnTriggerEnter(Collider other)
    {
        ingredient = other.GetComponent<Ingredient>();
        if (other.gameObject.tag == "Ingredient")
        {
            string category = ingredient.category;
            AssemblePie(category);
            Destroy(other.gameObject);
        }


    }
    public void OnMouseDown()
    {
        Debug.Log($"{pie.pbase}, {pie.filling}, {pie.top}");
    }
    public void AssemblePie(string category)
    {
        
            switch (category)
            {
                case "Base":
                    // If pie already has a base
                    if (pie.pbase != "Default")
                    {
                        Debug.Log($"Base already present");
                        break;
                    }
                    else
                    {
                        pie.pbase = ingredient.name; 
                        Debug.Log($"New Base : {pie.pbase}");
                       currBase =  Instantiate(pieBase, cookingArea.transform.position + offset, Quaternion.identity);
                    }

                    break;

                case "Filling":
                    // If Pie already contains filling
                    if (pie.filling != "Default")
                    {
                        Debug.Log($"Filling already present");
                        break;
                    }
                    // If Pie has base
                    if (pie.pbase != "Default")
                    {
                        pie.filling = ingredient.name;
                        Debug.Log($"New Filling : {pie.filling}");
                        currFilling = Instantiate(pieFilling, cookingArea.transform.position + offset, Quaternion.identity);
                }
                    else
                    {
                        Debug.Log("Add a base first");
                    }
                    break;

                case "Top":
                    // If Pie already contains a top
                    if (pie.top != "Default")
                    {
                        Debug.Log($"Top already present");
                    }
                    // If Pie has base & filling
                    if (pie.pbase != "Default" && pie.filling != "Default")
                    {
                        pie.top = ingredient.name;
                        Debug.Log($"New Top : {pie.top}");
                    }
                    else
                    {
                        Debug.Log("Add a base and filling first");
                    }
                    break;
            }
        }
    // If pie is complete, returns true
    public bool PieCompleted()
    {
        if(pie.pbase != "Default" && pie.filling != "Default" && pie.top != "Default")
        {
            if (isCooked)
            {
                return true;
            }
            else { return false; }
            
        }
        else { return false; }
    }
    }
