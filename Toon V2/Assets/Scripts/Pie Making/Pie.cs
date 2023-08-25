using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pie : MonoBehaviour
{
    
    public string pbase;
    
    public string filling;
    
    public string top;

    // Pie Constructor
    public Pie(string pbase = "Default",  string filling = "Default", string top = "Default")
    {
        this.pbase = pbase;
        this.filling = filling;
        this.top = top;
    }
    public void Start()
    {
        
    }

}
