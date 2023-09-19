using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public int bakeTime;
    public int currentTime = 0;
    public int burnTime;
    public bool isBaking = false;

    public float timer = 0f;
    public float delayAmount = 1f;
    // Start is called before the first frame update
    void Start()
    {
        bakeTime = Random.Range(5, 10);
        burnTime = bakeTime + 10;

    }

    // Update is called once per frame
    void Update()
    {
        
        
            if(isBaking)
        {
            Bake();
        }
            
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pie" && isBaking == false) 
        {

            InputPie(other.gameObject);

            
            
           
        }
        
    }
    public void Bake()
    {
        timer += Time.deltaTime;
        if (currentTime >= bakeTime)
        {
            isBaking = false;
            Debug.Log($"Pie Complete");
        }
        else
        {
            if (timer >= delayAmount)
            {
                timer = 0f;
                currentTime += 1;
                
            }
            
        }   
    }
    public void InputPie(GameObject pie)
    {
        pie.gameObject.GetComponent<SphereCollider>();
        pie.gameObject.transform.position = gameObject.transform.position;
        pie.gameObject.transform.position += new Vector3(0, 1, 0);
    }
}
