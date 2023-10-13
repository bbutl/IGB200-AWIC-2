using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewPulse : MonoBehaviour
{
    public GameObject Screw1;
    public GameObject Screw2;
    public GameObject Screw3;
    public GameObject Screw4;

    // Start is called before the first frame update
    void Start()
    {
        Screw1.GetComponent<OutlinePulse>().startPulse = true;
        Screw2.GetComponent<OutlinePulse>().startPulse = true;
        Screw3.GetComponent<OutlinePulse>().startPulse = true;
        Screw4.GetComponent<OutlinePulse>().startPulse = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
