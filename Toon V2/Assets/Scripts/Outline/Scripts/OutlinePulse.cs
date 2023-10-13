using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OutlinePulse : MonoBehaviour
{
    float timer =0;
    float maxTime = 0.25f;
    private bool on = false;
    public bool startPulse = true;
    private int pulses = 0;
    

    void Update()
    {
        if (startPulse)
        {
            Pulse(5);
        }
        

    }
    public void Pulse(int maxPulses)
    {
        
        if (pulses < maxPulses)
        {
            timer += Time.deltaTime;

            if (timer > maxTime && !on)
            {
                on = true;
                gameObject.GetComponent<Outline>().enabled = false;
                timer = 0;

            }
            if (timer > maxTime && on)
            {
                on = false;
                gameObject.GetComponent<Outline>().enabled = true;
                timer = 0;
                pulses++;
            }
        }
        else
        {
            pulses = 0;
            startPulse = false;
        }
    }
}
