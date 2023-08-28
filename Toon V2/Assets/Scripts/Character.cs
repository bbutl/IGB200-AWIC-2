using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private string name;
    private string occupation;
    public GameObject dialogue;
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }
    public string Occupation
    {
        get
        {
            return occupation;
        }
        set
        {
            occupation = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartConvo()
    {
        
    }
}
