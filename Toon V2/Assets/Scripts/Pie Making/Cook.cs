using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : MonoBehaviour
{

    [Header("Ingredients")]
    public GameObject pieBase;
    public GameObject pieFilling;
    public GameObject meatCubes;
    public GameObject peas;
    public GameObject mushroom;
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


    private Vector3 pieSpawn = new Vector3(0, 0.5f, 0);
    private Vector3 offset = new Vector3(0f, 0.75f, 0f);
    public Vector3 goTransform;
    private Vector3 fillingPos = new Vector3(-66.3949966f, 2.477f, 2.54099989f);
    //change to false
    private bool isCooked = true;

    // Start is called before the first frame update
    void Start()
    {

        mushroom = Instantiate(mushroom, new Vector3(-66.4710007f, 3.06299996f, 3.41199994f), Quaternion.identity);
        mushroom.transform.localScale = new Vector3(0.375f, 0.375f, 0.375f);


        peas = Instantiate(peas, new Vector3(-66.4710007f, 3.06299996f, 3.41199994f), Quaternion.identity);
        peas.transform.localScale = new Vector3(0.375f, 0.375f, 0.375f);


        meatCubes = Instantiate(meatCubes, fillingPos, Quaternion.identity);
        meatCubes.transform.localScale = new Vector3(0.375f, 0.375f, 0.375f);

        mushroom.gameObject.SetActive(false);
        meatCubes.gameObject.SetActive(false);
        peas.gameObject.SetActive(false);


        goTransform = gameObject.transform.position;
        pie = pieObject.GetComponent<Pie>();
        pie.pbase = "Default";
        pie.filling = "Default";
        pie.top = "Default";
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // If pie is complete, instantiate the pie & reset values of prefab
        if (PieCompleted())
        {
            if (meatCubes != null)
            {
                meatCubes.gameObject.SetActive(false);
            }

            if (peas != null)
            {
                peas.gameObject.SetActive(false);
            }
            if (mushroom != null)
            {
                mushroom.gameObject.SetActive(false);
            }
            Destroy(currBase);
            Destroy(currFilling);
            GameObject p = Instantiate(pieObject, cookingArea.transform.position + pieSpawn, Quaternion.identity);
            //p.transform.position -= new Vector3(2.7f,-1,2f);
            pie.pbase = "Default";
            pie.filling = "Default";
            pie.top = "Default";
            cameraPan.start = true;
            //cameraPan.Invoke("StartRotate", 2.5f);
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
            //other.gameObject.transform.position = goTransform;
            //Destroy(other.gameObject);
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
                    currBase = Instantiate(pieBase, cookingArea.transform.position + offset, Quaternion.identity);
                    currBase.transform.localScale = new Vector3(0.375f, 0.375f, 0.375f);
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
                    currFilling.transform.localScale = new Vector3(0.375f, 0.375f, 0.375f);
                    if (ingredient.name == "Beef Filling")
                    {
                        meatCubes.gameObject.SetActive(true);
                    }
                    if (ingredient.name == "Peas")
                    {
                        peas.gameObject.SetActive(true);
                    }
                    if (ingredient.name == "Mushrooms")
                    {
                        mushroom.gameObject.SetActive(true);
                    }
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
                if (pie.pbase != "Default")
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
        if (pie.pbase != "Default" && pie.top != "Default")
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
