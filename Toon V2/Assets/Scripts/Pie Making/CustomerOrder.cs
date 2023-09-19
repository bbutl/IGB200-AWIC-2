using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    [Header("Lists")]
    public List<Ingredient> allIngredients;
    public List<Ingredient> baseIngredients;
    public List<Ingredient> fillingIngredients;
    public List<Ingredient> topIngredients;

    public string orderBase;
    public string orderFilling;
    public string orderTop;
    public CameraPan cameraPan;
    // Start is called before the first frame update
    void Start()
    {
        PopulateList();
        FilterIngredients();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Populate allIngredients list with all current ingredients
    public void PopulateList()
    {
        foreach(GameObject ingredient in GameObject.FindGameObjectsWithTag("Ingredient"))
        {
             
            allIngredients.Add(ingredient.GetComponent<Ingredient>());
        }
    }
    public void FilterIngredients()
    {
        foreach(Ingredient ing in allIngredients)
        {
            if(ing.category == "Base")
            {
                baseIngredients.Add(ing);
            }
            if(ing.category == "Filling")
            {
                fillingIngredients.Add(ing);
            }
            if (ing.category == "Top")
            {
                topIngredients.Add(ing);
            }
        }
    }
    public void CreateOrder()
    {
        orderBase = baseIngredients[Random.Range(0, baseIngredients.Count - 1)].name;
        orderFilling = fillingIngredients[Random.Range(0, fillingIngredients.Count)].name;
        orderTop = topIngredients[Random.Range(0, topIngredients.Count - 1)].name;
        
    }

}
