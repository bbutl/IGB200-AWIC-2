using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject pBase;
    public GameObject pFilling;
    public GameObject pTop;
    public Pie pie;
    public bool startTutorial = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startTutorial)
        {
            pBase.GetComponent<OutlinePulse>().startPulse = true;
            if (pie.pbase != "Default")
            {
                pBase.GetComponent<OutlinePulse>().startPulse = false;
                pFilling.GetComponent<OutlinePulse>().startPulse = true;
                if (pie.filling != "Default")
                {
                    pFilling.GetComponent<OutlinePulse>().startPulse = false;
                    pTop.GetComponent<OutlinePulse>().startPulse = true;
                    startTutorial = false;
                }
            }
        }
    }
}
        

