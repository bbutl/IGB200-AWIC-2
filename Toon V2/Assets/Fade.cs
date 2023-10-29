using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image fadeToBlack;
    public bool startFade = false;
    public bool doneFade = false;
    // Start is called before the first frame update
    void Start()
    {

        //Invoke("UnFade", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (startFade)
        {
            StartFade();
        }
        if (doneFade)
        {
            UnFade();
        }

    }
    public void StartFade()
    {
        var i = fadeToBlack;
        var tempcolor = i.color;

        if (tempcolor.a <= 1.15f)
        {
            tempcolor.a += Time.deltaTime;
            i.color = tempcolor;
        }
        else
        {

            doneFade = true;
            startFade = false;

        }


        // Invoke("UnFade", 1);
    }
    public void UnFade()
    {
        var i = fadeToBlack;
        var tempcolor = i.color;
        if (tempcolor.a > 0)
        {
            tempcolor.a -= Time.deltaTime;
            i.color = tempcolor;
        }
        else
        {
            Debug.Log("Done");
            doneFade = false;
        }
    }

}
